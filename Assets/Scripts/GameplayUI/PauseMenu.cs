using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public TextMeshProUGUI gameVersionText;
    public TextMeshProUGUI gameTitleText;

    public GameObject pauseCanvas;

    string gameVersion;
    string gameTitle;

    private void Start()
    {
        SetGameTitle();
        SetGameVersion();

        pauseCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePauseMenu();
        }
    }

    private void SetGameVersion()
    {
        gameVersion = Application.version;
        gameVersionText.text = "v. " + gameVersion;
    }

    private void SetGameTitle()
    {
        gameTitle = Application.productName;
        gameTitleText.text = gameTitle;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void TogglePauseMenu()
    {
        bool isActive = pauseCanvas.activeSelf;
        pauseCanvas.SetActive(!isActive);

        if (pauseCanvas.activeSelf) {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
