using UnityEngine;

public class DistanceAudioController : MonoBehaviour
{
    public Transform targetTransform;
    public AudioSource audioSource;
    public float maxDistance = 70f;
    public float minVolume = 0.1f;
    public float maxVolume = 1f;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, targetTransform.position);
        float normalizedDistance = Mathf.Clamp01(distance / maxDistance);
        float volume = Mathf.Lerp(maxVolume, minVolume, normalizedDistance);

        audioSource.volume = volume;
    }
}
