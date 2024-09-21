using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class DestructiblePlatform : MonoBehaviour
{
    public float destructionDelay = 5.0f;

    private bool isPlayerInContact = false;

    Collider thisObject;

    public GameObject brokenPlatformNormal;
    public GameObject brokenPlatformSegments;

    public AudioSource destructPlatformSound;

    private void Start()
    {
        thisObject = GetComponent<Collider>();
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
        brokenPlatformNormal.SetActive(false);
        brokenPlatformSegments.SetActive(true);
        thisObject.enabled = false;
        //Destroy(gameObject);
    }
}
