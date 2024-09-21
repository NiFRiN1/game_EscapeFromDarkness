using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour
{
    public string nextSceneName;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        
    }

    private void LoadNextScene() {
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            LoadNextScene();
        }
    }
}
