using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaPotty : MonoBehaviour
{
    public Animator anim;

    public void OpenDoor()
    {
        anim.SetTrigger("OpenDoor_Trigger");

    }

}

