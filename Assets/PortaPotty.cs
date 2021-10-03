using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaPotty : MonoBehaviour
{
    [SerializeField]
    private GameObject _door;

    public float doorDelay = 1f;

    public void OpenDoor()
    {
        //rotate the door 120 degrees
        _door.transform.Rotate(new Vector3(0, 0, -120));
        StartCoroutine(CloseDoor(doorDelay));
    }

    IEnumerator CloseDoor(float delay)
    {
        yield return new WaitForSeconds(delay);
        //rotate the door 120 degrees
        _door.transform.Rotate(new Vector3(0, 0, 120));
    }

}
