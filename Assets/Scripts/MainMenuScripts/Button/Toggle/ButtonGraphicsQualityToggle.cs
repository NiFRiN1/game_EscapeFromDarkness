using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicsQualityToggle : MonoBehaviour
{
    public Button qualityButton;
    public TextMeshProUGUI buttonText;

    private int currentQualityIndex = 2;
    private readonly string[] qualityLevels = new string[] {
        "Низкая",
        "Средняя",
        "Высокая"
    };

    private void Start()
    {
        UpdateButtonText();
        qualityButton.onClick.AddListener(ToggleQuality);
    }

    public void ToggleQuality()
    {
        currentQualityIndex = (currentQualityIndex + 1) % qualityLevels.Length;

        QualitySettings.SetQualityLevel(currentQualityIndex, true);

        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        string currentQuality = qualityLevels[currentQualityIndex];
        buttonText.text = $"> Качество графики: {currentQuality}";
    }
}
