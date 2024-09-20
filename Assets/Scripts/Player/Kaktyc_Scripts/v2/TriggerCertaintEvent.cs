using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCertaintEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            onTriggerEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            onTriggerExit.Invoke();
    }
}
