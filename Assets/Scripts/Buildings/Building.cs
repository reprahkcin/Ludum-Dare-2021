using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int startingHealth;
    protected int currentHealth;
    private List<Patron> queue = new List<Patron>();
    protected List<Patron> riders = new List<Patron>();
    public int rideLength = 5; // Seconds
    public int maxRiders = 1; //
    private float queueDistance = 1f;
    public int incomePerRide = 5;
    public bool readyToBegin = false;
    private int openSeat = 0;
    
    public int degradeAmount = 1; // Health
    private float degradeDelay = 1f; // Seconds

    public GameObject repairSign;

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
            currentHealth = startingHealth;
            return false;
        }

        return true;

    }
    
    protected void Start()
    {
        
        currentHealth = startingHealth;
        repairSign.SetActive(false);
        StartCoroutine(DegradeLoop());
        StartCoroutine(RideLoop());
        
    }

    protected void Update()
    {
        if (currentHealth == 0)
        {
            //Turn on the sign
            repairSign.SetActive(true);
        }
        else
        {
            repairSign.SetActive(false);
        }
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
                yield return EmptyQueue();
            } else {
            
                yield return LoadRiders();
                if(riders.Count > intermediatePositions.Length / 2) {
                    readyToBegin = true;
                    yield return new WaitForSeconds(rideLength);
                    readyToBegin = false;
                    RemoveHealth(riders.Count);
                    yield return UnloadRiders();
                }
            }
            
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void AddToQueue( Patron patron ) {

        queue.Add( patron );
        float move = -queueDistance * queue.Count;
        patron.transform.Translate(new Vector3(0, 0, -move ));
    }

    IEnumerator LoadRiders() {

        int limit = intermediatePositions.Length;

        if(limit == 0) {
            limit = 1;
        }

        while(queue.Count > 0 && (riders.Count < limit)) {

            if(incomePerRide > 0) {
                StateManager.instance.AddIncome(incomePerRide);
            }

            Patron patron = queue[0];
            queue.RemoveAt(0);
            riders.Add(patron);
            shiftRider(patron, openSeat);
            
            yield return new WaitForSeconds(0.1f);
            
            shiftQueue();

            openSeat += 1;
        }
    }

    void shiftRider( Patron patron, int openSeat ) {
        // todo - move to specific transforms.
        if(intermediatePositions.Length > 0 ) {
            Debug.Log("Shifting rider to seat " + openSeat);
            patron.transform.SetParent(intermediatePositions[openSeat]);
            patron.transform.position = intermediatePositions[openSeat].position; 
            patron.transform.localPosition = Vector3.zero;
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

    IEnumerator UnloadRiders() { 

        while(riders.Count > 0) {
            Patron patron = riders[0];
            riders.RemoveAt(0);
            patron.transform.parent = null;
            patron.transform.position = ExitPoint.position;
            patron.AwardPoints(RideQuality()); // Award points for ride.
            patron.NextTarget();
            yield return new WaitForSeconds(0.2f); 

            
        }

        openSeat = 0;
    }

    int RideQuality() {
        // Time in queue?
        // Quality of ride?
        return 3;
    }

    IEnumerator EmptyQueue() {
        while(queue.Count > 0) {
            Patron patron = queue[0];
            queue.RemoveAt(0);
            patron.AwardPoints(0);  // Ride Quality 0 (Broken)
            patron.NextTarget();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
