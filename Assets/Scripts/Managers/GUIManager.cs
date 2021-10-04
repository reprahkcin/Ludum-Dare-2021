using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoSingleton<GUIManager>
{
    private GameObject _activeWorker;

    public GameObject[] workers;

    public Transform actionTarget;

    public void SetActionTarget(Transform target) {
        if(_activeWorker) {
            actionTarget = target;
            _activeWorker.GetComponent<Worker>().SetTarget(target);
        }
    }
    void clearAction() {
        actionTarget = null;

    }

    public void SetActiveWorker(GameObject worker) {
        _activeWorker = worker;
        clearAction();
    }
    void OnGUI() {

        IncomeUI();
        PointsUI();
        WorkerUI();
        ActiveWorkerUI();
        AlertsUI();
    }

    void IncomeUI() {
        GUI.BeginGroup(new Rect(0, 0, 260, 80));
        GUI.Box(new Rect(10, 20, 80, 30), "$" + StateManager.instance.GetIncome());
        GUI.EndGroup();
    }

    void PointsUI() {
        GUI.BeginGroup(new Rect(300, 0, 260, 80));
        GUI.Box(new Rect(10, 20, 80, 30), StateManager.instance.GetPoints() + " Points");
        GUI.EndGroup();
    }

    void WorkerUI() {
        GUI.BeginGroup(new Rect(0, Screen.height - 80, 260, 80));
        GUI.Box(new Rect(0, 0, 260, 80), "Select Worker");
        int x = 0;
        foreach(GameObject worker in workers) {
            if (GUI.Button(new Rect(10 + (x * 50), 30, 40, 40), x.ToString()) || Input.GetKeyDown(x.ToString()))
            {
                SetActiveWorker(worker);
            }
            x += 1;
        }
        GUI.EndGroup();
    }

    void ActiveWorkerUI() {
        if(_activeWorker) {

            string targetLabel = "";
            string actionLabel = "";
            Worker workerScript = _activeWorker.GetComponent<Worker>();

            if(workerScript.target) {
                targetLabel = workerScript.target.gameObject.name;
            }

            if(workerScript.isWalking) {
                actionLabel = "walking to " + targetLabel + ".";
            }

            else if(workerScript.isRepairing) {
                actionLabel = "repairing to " + targetLabel + ".";
            } else {
                actionLabel = "idle.";
            }
            GUI.BeginGroup(new Rect(Screen.width - 200, Screen.height - 200, 200, 200));
            GUI.Box(new Rect(0, 0, 200, 200), _activeWorker.name + " Actions");
            GUI.Label(new Rect(10, 30, 200, 200), _activeWorker.name + " is " + actionLabel);
            GUI.Label(new Rect(10, 60, 200, 200), "Speed: " + workerScript.speed);
            GUI.Label(new Rect(10, 90, 200, 200), "Repair: " + workerScript.repairPerSecond);
            GUI.EndGroup();
        }
    }

    void AlertsUI() {
        GUI.BeginGroup(new Rect(Screen.width - 200, 0, 200, 200));

        int x = 0; 

        foreach(string alert in AlertManager.instance.GetAlerts()) {
            GUI.Label(new Rect(10, x * 30, 200, 30), alert);
            x += 1;
        }
        GUI.EndGroup();
    }
}
