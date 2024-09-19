using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSens : MonoBehaviour
{
    public CameraController controller;

    void Start()
    {
        
    }

    void Update()
    {
    }

    public void GetSlider(float value) {
        controller.SetSens(value);
    }
}
