using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booth : Building
{

    public GameObject repairSign;

    void Start()
    {
        base.Start();
        repairSign.SetActive(false);
    }

    void Update()
    {
        if (currentHealth == 0)
        {
            //Turn on the sign
            repairSign.SetActive(true);
        }
        else
        {
            repairSign.SetActive(false);
        }
    }

}
