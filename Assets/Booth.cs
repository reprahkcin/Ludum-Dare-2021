using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booth : MonoBehaviour
{
    [SerializeField]
    private Transform _queueStart;
    [SerializeField]
    private Transform _exit;
    [SerializeField]
    private Transform _repairSpot;

    public float health = 100;

    public Transform GetQueueStart()
    {
        return _queueStart;
    }

    public Transform GetRepairSpot()
    {
        return _repairSpot;
    }

    public Transform GetExit()
    {
        return _exit;
    }
}
