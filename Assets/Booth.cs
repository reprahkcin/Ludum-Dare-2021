using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booth : MonoBehaviour
{
    [SerializeField]
    private Transform _queueStart;
    [SerializeField]
    private Transform _exit;

    public Transform GetQueueStart()
    {
        return _queueStart;
    }
}
