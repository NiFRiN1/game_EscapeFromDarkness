using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryRB : MonoBehaviour
{
    public bool useSensorOnTop = false;
    public List<Rigidbody> RigidbodyList = new List<Rigidbody>();

    Vector3 lastEulerRotation;
    Vector3 lastPosition;
    Transform _transform;
    [HideInInspector] public Rigidbody _rb;


    void Start()
    {
        _transform = transform;
        lastEulerRotation = _transform.eulerAngles;
        lastPosition = _transform.position;
        _rb = GetComponent<Rigidbody>();

        if (useSensorOnTop)
        {
            foreach (CarryRBSensor sensor in GetComponentsInChildren<CarryRBSensor>())
            {
                sensor.carrier = this;
            }
        }
    }

    private void FixedUpdate()
    {
        if (RigidbodyList.Count > 0)
        {
            Vector3 velocity = (_transform.position - lastPosition);
            Vector3 angularVelocity = _transform.eulerAngles - lastEulerRotation;
            for (int i = 0; i < RigidbodyList.Count; i++)
            {
                Rigidbody rb = RigidbodyList[i];
                rb.transform.Translate(velocity, Space.World);
                RotateRigidBody(rb, angularVelocity.y);
            }
        }
        lastEulerRotation = _transform.eulerAngles;
        lastPosition = _transform.position;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (useSensorOnTop) return;

        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("Is in contact");
            AddRigidBody(rb);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (useSensorOnTop) return;

        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            RemoveRigidBody(rb);
        }
    }

    public void AddRigidBody(Rigidbody rb)
    {
        if (!RigidbodyList.Contains(rb))
        {
            RigidbodyList.Add(rb);
        }
    }

    public void RemoveRigidBody(Rigidbody rb)
    {
        if (RigidbodyList.Contains(rb))
        {
            RigidbodyList.Remove(rb);
        }
    }

    void RotateRigidBody(Rigidbody rb, float amount)
    {
        rb.transform.RotateAround(_transform.position, Vector3.up, amount);
    }
}
