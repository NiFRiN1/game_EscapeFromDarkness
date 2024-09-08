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
    public float speed = 1.0f;


    private void Update()
    {
        MoveAlongAxis();
    }

    private void MoveAlongAxis()
    {
        Vector3 movement = Vector3.zero;

        switch (selectedAxis) {
            case Axis.X:
                movement = new Vector3(speed * Time.deltaTime, 0, 0);
                break;
            case Axis.Y:
                movement = new Vector3(0, speed * Time.deltaTime, 0);
                break;
            case Axis.Z:
                movement = new Vector3(0, 0, speed * Time.deltaTime);
                break;
        }

        transform.Translate(movement);
    }
}
