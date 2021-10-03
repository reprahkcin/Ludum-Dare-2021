using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacupArm : MonoBehaviour
{
    [SerializeField]
    private GameObject _teaCupRide;

    [SerializeField]
    private GameObject _littleArm1;

    [SerializeField]
    private GameObject _littleArm2;

    [SerializeField]
    private GameObject _littleArm3;

    [SerializeField]
    private GameObject _littleArm4;



    private void Update()
    {
        float speed = _teaCupRide.GetComponent<TeacupRide>().speed;

        if (_teaCupRide.GetComponent<TeacupRide>().isActive)
        {
            // Rotate main arm around z-axis at speed
            transform.Rotate(0, 0, speed * Time.deltaTime);

            // Rotate little arms opposite
            _littleArm1.transform.Rotate(0, 0, -speed * Time.deltaTime);
            _littleArm2.transform.Rotate(0, 0, -speed * Time.deltaTime);
            _littleArm3.transform.Rotate(0, 0, -speed * Time.deltaTime);
            _littleArm4.transform.Rotate(0, 0, -speed * Time.deltaTime);


        }

    }
}

