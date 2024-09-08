using System.Collections;
using UnityEngine;

// Меняет ракурс камеры в главном меню.
// Changes the camera angle in the main menu.

public class CamerasController : MonoBehaviour
{
    public Camera[] cameras;
    public float[] cameraActiveTimes;

    private int currentCameraIdx = 0;

    private void Start()
    {
        for (int i = 0; i < cameras.Length; i++) {
            cameras[i].gameObject.SetActive(i == currentCameraIdx);
        }

        StartCameraSwitching();
    }

    private void StartCameraSwitching()
    {
        StartCoroutine(SwitchCameras());
    }

    IEnumerator SwitchCameras()
    {
        while (true) {
            yield return new WaitForSeconds(cameraActiveTimes[currentCameraIdx]);

            cameras[currentCameraIdx].gameObject.SetActive(false);

            currentCameraIdx = (currentCameraIdx + 1) % cameras.Length;

            cameras[currentCameraIdx].gameObject.SetActive(true);
        }
    }
}
