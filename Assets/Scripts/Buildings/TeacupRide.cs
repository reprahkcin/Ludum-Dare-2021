using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacupRide : Building
{

    public bool isActive = false;

    public float speed = 2.0f;

    public float spinMin = -20.0f;

    public float spinMax = 20.0f;

    void Update() {
        base.Update();

        if(readyToBegin) {
            isActive = true;
        } else {
            isActive = false;
        }
    }
}

