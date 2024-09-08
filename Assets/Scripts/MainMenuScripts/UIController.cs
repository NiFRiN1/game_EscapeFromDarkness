using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI gameVersionText;
    public TextMeshProUGUI gameTitleText;

    string gameVersion;
    string gameTitle;

    private void Start()
    {
        SetGameTitle();
        SetGameVersion();
    }

    private void Update()
    {
        
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
}
