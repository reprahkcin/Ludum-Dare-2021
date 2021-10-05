using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTower : Building
{

    public Animator animator;

    new void Update()
    {
        base.Update();

        if (readyToBegin)
        {
            animator.SetTrigger("isActive");
        }
        else
        {
            animator.SetTrigger("isIdle");
        }
    }

}
