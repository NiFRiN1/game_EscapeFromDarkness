using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerTillTrigger : MonoBehaviour
{
    public Transform playerTransform;
    public float ghostDashSpeed = 0.5f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, ghostDashSpeed * Time.deltaTime);
        transform.LookAt(playerTransform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
