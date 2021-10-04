using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
    private int satisfaction = 0;
    private List<GameObject> destinations = new List<GameObject>();
    private Transform target;
    private Vector3 subtarget;
    private bool hasSubTarget = false;
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
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
        //MoveToSubTarget();
    }

    void MoveToTarget() {
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
                    StateManager.instance.AddAttendee(1);
                    Destroy(gameObject);
                }
            }
        }
    }

    void MoveToSubTarget() {
        if(!hasSubTarget) {
            animator.SetBool("isMoving", false);
            return;
        }

        animator.SetBool("isMoving", true);

        float step =  speed * Time.deltaTime;
        transform.LookAt(subtarget);
        
        transform.position = Vector3.MoveTowards(transform.position, subtarget, step);
        
        if (Vector3.Distance(transform.position, subtarget) < 0.001f)
        {
            hasSubTarget = false;
        }
    }

    public void AwardPoints( int pts) {
        satisfaction += pts;
    }

    public void NextTarget() {
        destinations.RemoveAt(0);
        target = destinations[0].transform;
    }

    public void SetSubTarget(Vector3 _subtarget) {
        subtarget = _subtarget;
        hasSubTarget = true;
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
