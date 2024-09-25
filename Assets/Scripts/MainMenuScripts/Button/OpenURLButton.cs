using UnityEngine;

public class OpenURLButton : MonoBehaviour
{
    public string url = "https://t.me/";

    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}
