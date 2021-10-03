using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacupRide : MonoBehaviour
{
    [SerializeField]
    private Transform _queueStart;
    [SerializeField]
    private Transform _exit;



    public Transform QueueStart { get { return _queueStart; } }
    public Transform Exit { get { return _exit; } }

    public bool isActive = false;

    public float speed = 2.0f;


}

