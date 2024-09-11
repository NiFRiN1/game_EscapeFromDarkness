using UnityEngine;
using System.Collections;

public class DestructiblePlatform : MonoBehaviour
{
    public float destructionDelay = 5.0f;

    public GameObject NormalVersion;
    public GameObject destroyVersion;

    private bool isPlayerInContact = false;

    private void Start()
    {
        destroyVersion.SetActive(false);
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
        Destroy(NormalVersion, destructionDelay);

        yield return new WaitForSeconds(destructionDelay);

        if (destroyVersion != null) {
            destroyVersion.SetActive(true);
        }
    }
}
