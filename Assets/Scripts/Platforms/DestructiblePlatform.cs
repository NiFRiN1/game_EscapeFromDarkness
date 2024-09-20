using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class DestructiblePlatform : MonoBehaviour
{
    public float destructionDelay = 5.0f;

    private bool isPlayerInContact = false;

    public AudioSource destructPlatformSound;

    private void Start()
    {
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player")) {
            StartDestruction();
        }
    }

    public void StartDestruction()
    {
        if (!isPlayerInContact) {
            isPlayerInContact = true;
            StartCoroutine(DestroyPlatform());
        }
    }

    private IEnumerator DestroyPlatform()
    {
        destructPlatformSound.Play();
        yield return new WaitForSeconds(destructionDelay);
        Destroy(gameObject);
    }
}
