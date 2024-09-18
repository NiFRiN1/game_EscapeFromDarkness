using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetFlashlight : MonoBehaviour
{
    public Vector3 vectOffset;
    public GameObject objToFollow;
    public float followSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        vectOffset = transform.position - objToFollow.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = objToFollow.transform.position + vectOffset;
        transform.rotation = Quaternion.Slerp (transform.rotation,objToFollow.transform.rotation,followSpeed*Time.fixedDeltaTime);
    }
}
