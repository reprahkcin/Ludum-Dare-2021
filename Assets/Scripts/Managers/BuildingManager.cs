using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] bathrooms;
    public GameObject[] rides;
    public GameObject[] booths;
    public GameObject[] food;
    public GameObject[] tickets;
    
    void Start() {
        GameObject[] buildingGameObjects = GameObject.FindGameObjectsWithTag("Building");

        foreach( GameObject building in buildingGameObjects) {
          //Building b = building.gameObject.GetComponent<Building>();
          //destinations.Add(b.QueuePoint.gameObject);
        }
    }
}