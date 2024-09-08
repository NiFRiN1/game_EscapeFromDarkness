using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour {
    public int sceneToLoad = 1;
    public AudioClip deathSound;
    public Camera mainCamera;
    public float delayBeforeLoad = 6f;

    private AudioSource audioSource;

    void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = deathSound;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(LoadSceneWithDelay(other.gameObject));
        }
    }

    private IEnumerator LoadSceneWithDelay(GameObject player) {
        audioSource.Play();

        if (mainCamera != null) {
            mainCamera.enabled = false;
        }

        Controller playerController = player.GetComponent<Controller>();
        if (playerController != null) {
            playerController.enabled = false;
        }
        yield return new WaitForSeconds(delayBeforeLoad);

        SceneManager.LoadScene(sceneToLoad);
    }
}
