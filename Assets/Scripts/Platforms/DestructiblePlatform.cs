using UnityEngine;
using System.Collections;

public class DestructiblePlatform : MonoBehaviour {
    public float destructionDelay = 2.1f;
    public float additionalDelayAfterSound = 2.8f;
    private bool isPlayerInContact = false;

    public AudioClip destructionSound1;
    public AudioClip destructionSound2;
    private AudioSource audioSource;

    private MeshRenderer meshRenderer;
    private Collider platformCollider;

    private void Start()
   {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        platformCollider = GetComponent<Collider>();
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
        yield return new WaitForSeconds(destructionDelay);
        PlayDestructionSound();
        HidePlatform();
        yield return new WaitForSeconds(additionalDelayAfterSound);
        Destroy(gameObject);
    }

    private void PlayDestructionSound()
    {
        if (audioSource != null) {
            AudioClip randomSound = Random.value < 0.5f ? destructionSound1 : destructionSound2;
            if (randomSound != null) {
                audioSource.PlayOneShot(randomSound);
            }
        }
    }

    private void HidePlatform()
    {
        if (meshRenderer != null) {
            meshRenderer.enabled = false;
        }
        if (platformCollider != null) {
            platformCollider.enabled = false;
        }
    }
}
