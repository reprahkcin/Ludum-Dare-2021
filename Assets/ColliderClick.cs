using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderClick : MonoBehaviour
{
    public Transform target;

    void OnMouseOver () 
    {
        if(Input.GetMouseButtonDown(0))
            Debug.Log("Left click on this object");
        if(Input.GetMouseButtonDown(1))
            Debug.Log("Right click on this object");
            GUIManager.instance.SetActionTarget(target);
        if(Input.GetMouseButtonDown(2))
            Debug.Log("Middle click on this object");
    }
}
