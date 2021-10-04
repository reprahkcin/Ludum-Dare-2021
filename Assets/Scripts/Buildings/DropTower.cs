using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTower : Building
{

    public Animator animator;

    void Update()
    {
        if (readyToBegin)
        {
            animator.SetTrigger("isActive");
        }
        else
        {
             animator.SetTrigger("isIdle");
        //    animator.SetBool("isActive", false);
        }
    }

}
