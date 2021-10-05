using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheel : Building
{

    // Ferris Wheel Movement
    public GameObject[] cars;

    public GameObject wheel;

    public float speed;


    new void Update()
    {
        if (readyToBegin)
        {
            //Turn the wheel on the z-axis at speed
            wheel.transform.Rotate(Vector3.forward, Time.deltaTime * speed);

            //loop through cars and rotate each car opposite the wheel
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].transform.Rotate(Vector3.forward, Time.deltaTime * -speed);
            }
        }
    }
}
