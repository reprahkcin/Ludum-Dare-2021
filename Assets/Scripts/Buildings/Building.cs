using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int startingHealth;
    protected int currentHealth;
    private List<Patron> queue = new List<Patron>();
    private List<Patron> riders = new List<Patron>();
    public int rideLength = 5; // Seconds
    public int maxRiders = 1; //
    private float queueDistance = 1f;
    public int incomePerRide = 5;
    
    public int degradeAmount = 1; // Health
    private float degradeDelay = 1f; // Seconds


[SerializeField]
    private Transform _queueStart;

    [SerializeField]
    private Transform _exit;

    [SerializeField]
    private Transform _repairSpot;

    [SerializeField]
    private Transform[] intermediatePositions;
    
    public Transform QueuePoint { get { return _queueStart; } }

    public Transform ExitPoint { get { return _exit; } }

    public Transform RepairPoint { get { return _repairSpot; } }


    void OnMouseDown() {
        Debug.Log(gameObject.name + " clicked");
        GUIManager.instance.SetActionTarget(transform);
    }

    public bool NeedsRepair() {

        return currentHealth == startingHealth;
    }

    public bool DoRepair(int amt) {
        currentHealth += amt;

        if(currentHealth >= startingHealth)  { // todo, implement maxhealth
        Debug.Log("DONE!!!");
            currentHealth = startingHealth;
            return false;
        }

        Debug.Log("Not Yet!");

        return true;

    }
    
    protected void Start()
    {
        currentHealth = startingHealth;
        StartCoroutine(DegradeLoop());
        StartCoroutine(RideLoop());
        
    }

    IEnumerator DegradeLoop() {

        while(true) {
            RemoveHealth(degradeAmount);
            yield return new WaitForSeconds(degradeDelay);
        }
    }

    IEnumerator RideLoop() {

        while(true) {

            if(currentHealth == 0) {
                EmptyQueue();
                yield return new WaitForSeconds(1);
            } else {
                LoadRiders();
                yield return new WaitForSeconds(rideLength);
                RemoveHealth(riders.Count);
                UnloadRiders();
                yield return new WaitForSeconds(1);
            }
        }
    }

    public void AddToQueue( Patron patron ) {

        queue.Add( patron );
        float move = -queueDistance * queue.Count;
        patron.transform.Translate(new Vector3(0,0, move ));
    }

    void LoadRiders() { 

        while(riders.Count < maxRiders) {

            // No Queue!
            if(queue.Count == 0) {
                break;
            }

            if(incomePerRide > 0) {
                StateManager.instance.AddIncome(incomePerRide);
            }

            Patron patron = queue[0];
            queue.RemoveAt(0);
            riders.Add(patron);

            shiftRiders();
            shiftQueue();
        }
    }

    void shiftRiders() {
        // todo - move to specific transforms.
        foreach(Patron patron in riders) {
            patron.transform.Translate(new Vector3(queueDistance, 0, 0));

        }
    }

    void shiftQueue() {
        foreach(Patron patron in queue) {
            patron.transform.Translate(new Vector3(0,0, queueDistance ));

        }
    }

    void RemoveHealth(int amount) { 

        currentHealth -= amount;

        if(currentHealth < 0) {
            currentHealth = 0;
        }
    }

    void UnloadRiders() { 

        while(riders.Count > 0) {
            Patron patron = riders[0];
            riders.RemoveAt(0);
            patron.AwardPoints(RideQuality()); // Award points for ride.
            patron.NextTarget(); 
        }
    }

    int RideQuality() {
        // Time in queue?
        // Quality of ride?
        return 3;
    }

    void EmptyQueue() {
        while(queue.Count > 0) {
            Patron patron = queue[0];
            queue.RemoveAt(0);
            patron.AwardPoints(0);  // Ride Quality 0 (Broken)
            patron.NextTarget();
        }
    }
}
