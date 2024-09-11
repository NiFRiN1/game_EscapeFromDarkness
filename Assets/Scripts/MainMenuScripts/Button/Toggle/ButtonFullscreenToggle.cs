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
            buttonText.text = "> ������������� �����: ����.";
        }
        else {
            buttonText.text = "> ������������� �����: ���.";
        }

        Screen.fullScreen = !Screen.fullScreen;
    }

    void UpdateButtonText()
    {
        if (Screen.fullScreen) {
            buttonText.text = "> ������������� �����: ���.";
        }
        else {
            buttonText.text = "> ������������� �����: ����.";
        }
    }
}