using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
  
  void Start() {
    GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        foreach( GameObject building in buildings) {
            Building b = building.gameObject.GetComponent<Building>();
        //    destinations.Add(b.QueuePoint.gameObject);
        }
  }
}