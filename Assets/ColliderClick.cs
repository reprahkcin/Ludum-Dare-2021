using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderClick : MonoBehaviour
{
    public Transform target;

    void OnMouseOver () 
    {
        if(Input.GetMouseButtonDown(1)) {
            GUIManager.instance.SetActionTarget(target);
        }
    }
}
