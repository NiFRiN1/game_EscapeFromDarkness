using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI gameVersionText;
    public TextMeshProUGUI gameTitleText;

    string gameVersion;
    string gameTitle;

    private void Start()
    {
        Time.timeScale = 1.0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Screen.SetResolution(1920, 1080, true);
        QualitySettings.SetQualityLevel(2);

        SetGameTitle();
        SetGameVersion();
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
