using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScreenResolutionToggle : MonoBehaviour
{
    public Button resolutionButton;
    public TextMeshProUGUI buttonText;

    private int currentResolutionIndex = 1;
    private readonly Resolution[] resolutions = new Resolution[] {
        new Resolution { width = 1280, height = 720 },
        new Resolution { width = 1920, height = 1080 },
        new Resolution { width = 2560, height = 1440 },
        new Resolution { width = 800, height = 600 },
        new Resolution { width = 1024, height = 768 },
        new Resolution { width = 1280, height = 960 }
    };

    private void Start()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        UpdateButtonText();
        resolutionButton.onClick.AddListener(ToggleResolution);
    }

    public void ToggleResolution()
    {
        currentResolutionIndex = (currentResolutionIndex + 1) % resolutions.Length;
        Screen.SetResolution(resolutions[currentResolutionIndex].width, resolutions[currentResolutionIndex].height, Screen.fullScreen);
        UpdateButtonText();
    }

    void UpdateButtonText() {
        Resolution currentResolution = resolutions[currentResolutionIndex];
        buttonText.text = $"> Разрешение экрана: {currentResolution.width}x{currentResolution.height}";
    }
}
