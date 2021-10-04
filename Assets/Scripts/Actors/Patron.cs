using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
    private int satisfaction = 0;
    private List<GameObject> destinations = new List<GameObject>();
    private Transform target;
    public float speed = 1;
    public Animator animator;

    
    void Start()
    {
        //Get all destinations.
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        buildings = reshuffle(buildings);

        foreach( GameObject building in buildings) {
            Building b = building.gameObject.GetComponent<Building>();
            destinations.Add(b.QueuePoint.gameObject);
        }

        /* Add Spawn as final destination */
        GameObject[] spawn = GameObject.FindGameObjectsWithTag("Respawn");
        destinations.Add(spawn[0]);

        target = destinations[0].transform;
        Debug.Log("Going to " + destinations[0].name);
    }

    // Update is called once per frame
    void Update()
    {
        if(!target) {
            animator.SetBool("isMoving", false);
            return;
        }

        animator.SetBool("isMoving", true);

        float step =  speed * Time.deltaTime;
        transform.LookAt(target.position);
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            Building building = target.gameObject.GetComponentInParent<Building>();
            
            if(building) {
                building.AddToQueue( this );
                target = null;
            } else {

                PatronSpawn spawn = target.gameObject.GetComponent<PatronSpawn>();
                
                if(spawn) {
                    StateManager.instance.AddPoints(satisfaction);
                    Destroy(gameObject);
                }
            }

        }
    }

    public void AwardPoints( int pts) {
        satisfaction += pts;
    }

    public void NextTarget() {
        destinations.RemoveAt(0);
        target = destinations[0].transform;
        //Debug.Log("Going to " + destinations[0].name);
    }

GameObject[] reshuffle(GameObject[] gos)
    {
        // Knuth shuffle algorithm
        for (int t = 0; t < gos.Length; t++ )
        {
            GameObject tmp = gos[t];
            int r = Random.Range(t, gos.Length);
            gos[t] = gos[r];
            gos[r] = tmp;
        }

        return gos;
    }
 
}
