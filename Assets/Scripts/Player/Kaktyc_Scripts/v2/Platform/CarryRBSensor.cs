using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryRBSensor : MonoBehaviour
{
    public CarryRB carrier;
    
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && rb != carrier._rb)
        {
            Debug.Log("Is in trigger zone");
            carrier.AddRigidBody(rb);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && rb != carrier._rb)
        {
            carrier.RemoveRigidBody(rb);
        }
    }
}
