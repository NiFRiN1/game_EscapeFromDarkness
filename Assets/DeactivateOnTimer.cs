using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnTimer : MonoBehaviour
{
    public Rigidbody[] platformPieces;
    public float timer;
    Rigidbody[] platformPiecesRB;
    Vector3 rndDirection;
    // Start is called before the first frame update
    void Start()
    {
        platformPieces = GetComponentsInChildren<Rigidbody>();
        rndDirection = new Vector3(Random.Range(0, 20), Random.Range(0, 20), Random.Range(0, 20));
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < platformPieces.Length; i++)
        {
            platformPieces[i].AddExplosionForce(200, rndDirection, 200);
            Debug.Log("We are adding force");
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
