using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTower : MonoBehaviour
{
    [SerializeField]
    private Transform _queueStart;

    [SerializeField]
    private Transform _exit;

    [SerializeField]
    private Transform _repairSpot;

    [SerializeField]
    private Transform[] intermediatePositions;

    public GameObject repairSign;

    public bool underRepair = false;

    void Start()
    {

        repairSign.SetActive(false);
    }

    void Update()
    {
        if (underRepair)
        {
            //Turn on the sign
            repairSign.SetActive(true);
        }
        else
        {
            repairSign.SetActive(false);
        }

        if (isActive)
        {
            // slowly bring the hub up to the top, then drop it

        }



    }

    public void Break()
    {
        underRepair = true;
    }

    public void Fix()
    {
        underRepair = false;
    }

    public Transform Queue { get { return _queueStart; } }

    public Transform Exit { get { return _exit; } }

    public Transform Repair { get { return _repairSpot; } }

    // Drop Tower Movement


    public GameObject hub;

    public float dropSpeed;

    public float upSpeed;

    public bool isActive = false;


}
