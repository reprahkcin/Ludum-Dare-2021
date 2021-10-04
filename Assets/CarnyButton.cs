using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnyButton : MonoBehaviour
{
    public GameObject worker;
    
    public void SetActiveWorker() {
        GUIManager.instance.SetActiveWorker(worker);
    }
}
