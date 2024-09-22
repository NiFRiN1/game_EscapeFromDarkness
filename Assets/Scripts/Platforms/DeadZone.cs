using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public int sceneToLoad = 1;
    public AudioClip deathSound;
    public Camera mainCamera;
    public float delayBeforeLoad = 6f;

    public GameObject DeadScreen;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.playOnAwake = false;
        audioSource.clip = deathSound;
        DeadScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) {
            StartCoroutine(LoadSceneWithDelay(other.gameObject));
        }
    }

    private IEnumerator LoadSceneWithDelay(GameObject player)
    {
        audioSource.Play();

        if (mainCamera != null) {
            mainCamera.enabled = false;
            DeadScreen.SetActive(true);
        }

        Controller playerController = player.GetComponent<Controller>();
        if (playerController != null) {
            playerController.enabled = false;

        }
        yield return new WaitForSeconds(delayBeforeLoad);

        SceneManager.LoadScene(sceneToLoad);
    }
}
