using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightSourse;

    public float minTime;
    public float maxTime;
    public float timer;

    public AudioSource audioSource;
    
    void Start()
    {
         timer = Random.Range(minTime, maxTime);
    }

    
    void Update()
    {
        LightFlick();
    }


    public void LightFlick()
    {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                lightSourse.enabled = !lightSourse.enabled;
                timer = Random.Range(minTime, maxTime);
                audioSource.Play();
            }
       
    }
}
