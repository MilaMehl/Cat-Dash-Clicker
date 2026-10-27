using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    [Header("Game Stats")]
    public float totalDistance = 0f;
    public float currentSpeed = 0f;
    public float clickPower = 2f;
    public float speedDecay = 1.5f;

    [Header("UI Elements")]
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI speedText;
    public Slider progressBar;
    public float targetDistance = 100f;

    void Update()
    {
        // Reduz a velocidade gradualmente
        if (currentSpeed > 0)
        {
            currentSpeed -= speedDecay * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0f);
        }

        // Acumula a distância percorrida
        totalDistance += currentSpeed * Time.deltaTime;

        // Atualiza a UI
        UpdateUI();
    }

    public void OnClickDash()
    {
        currentSpeed += clickPower;
    }

    void UpdateUI()
    {
        if (distanceText != null) distanceText.text = $"{totalDistance:F1} km";
        if (speedText != null) speedText.text = $"{currentSpeed:F1} km/h";
        if (progressBar != null) progressBar.value = totalDistance / targetDistance;
    }
}