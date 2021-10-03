using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaPotty : MonoBehaviour
{
    [SerializeField]
    private Transform _queueStart;
    [SerializeField]
    private Transform _seatedPosition;

    public Animator anim;

    public void OpenDoor()
    {
        anim.SetTrigger("OpenDoor_Trigger");

    }

    public Transform GetQueueStart()
    {
        return _queueStart;
    }

    public Transform GetSeatedPosition()
    {
        return _seatedPosition;
    }

}

