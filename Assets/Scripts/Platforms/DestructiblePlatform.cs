using UnityEngine;
using System.Collections;

public class DestructiblePlatform : MonoBehaviour
{
    public float destructionDelay = 5.0f;

    private bool isPlayerInContact = false;

    private void Start()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
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
        yield return new WaitForSeconds(destructionDelay);

        Destroy(gameObject);
    }
}
