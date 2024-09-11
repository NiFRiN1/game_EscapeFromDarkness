using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullscreenToggle : MonoBehaviour
{
    public Button fullscreenButton;
    public TextMeshProUGUI buttonText;

    private void Start()
    {
        fullscreenButton.onClick.AddListener(ToggleFullscreen);
    }

    public void ToggleFullscreen()
    {
        if (Screen.fullScreen) {
            buttonText.text = "> Полноэкранный режим: Выкл.";
        }
        else {
            buttonText.text = "> Полноэкранный режим: Вкл.";
        }

        Screen.fullScreen = !Screen.fullScreen;
    }

    void UpdateButtonText()
    {
        if (Screen.fullScreen) {
            buttonText.text = "> Полноэкранный режим: Вкл.";
        }
        else {
            buttonText.text = "> Полноэкранный режим: Выкл.";
        }
    }
}