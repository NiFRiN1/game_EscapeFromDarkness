using UnityEngine;

public class DarknessMoving : MonoBehaviour
{
    public enum Axis
    {
        X,
        Y,
        Z
    }

    public Axis selectedAxis = Axis.X;
    public float currentSpeed = 1.0f;
    public float kayotSpeed;
    public float backToNormalSpeed;

    private void Start()
    {
        backToNormalSpeed = currentSpeed;
        kayotSpeed = currentSpeed / 2;
    }
    private void Update()
    {
        MoveAlongAxis();
    }

    private void MoveAlongAxis()
    {
        Vector3 movement = Vector3.zero;

        switch (selectedAxis) {
            case Axis.X:
                movement = new Vector3(currentSpeed * Time.deltaTime, 0, 0);
                break;
            case Axis.Y:
                movement = new Vector3(0, currentSpeed * Time.deltaTime, 0);
                break;
            case Axis.Z:
                movement = new Vector3(0, 0, currentSpeed * Time.deltaTime);
                break;
        }

        transform.Translate(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentSpeed = kayotSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentSpeed = backToNormalSpeed;
        }
    }
}
