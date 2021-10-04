using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CanvasManager : MonoBehaviour
{
    // -----------------------------------------------------------
    // Singleton
    // -----------------------------------------------------------

    public static CanvasManager instance;

    // ------------------------------------------------------------
    // GameObjects
    // ------------------------------------------------------------

    // Keep track of all canvases
    public Canvas[] canvases;

    public GameObject introCanvas;

    // HUD
    public GameObject hudCanvas;

    public TextMeshProUGUI parkSentimentText;

    public TextMeshProUGUI incomeText;

    public TextMeshProUGUI feedbackStatusText;

    // Dialog Panel
    public GameObject dialogGroup;




    // ------------------------------------------------------------
    // State Variables
    // ------------------------------------------------------------
    // Keep track of the current canvas
    private Canvas currentCanvas;

    // Keep track of the current canvas index
    public int currentCanvasIndex;


    // ------------------------------------------------------------
    // Canvas Control Functions
    // ------------------------------------------------------------
    public void DeactivateCanvases()
    {
        // Deactivate all canvases
        foreach (Canvas canvas in canvases)
        {
            canvas.gameObject.SetActive(false);
        }
    }

    public void NextCanvas()
    {
        // Deactivate the current canvas
        currentCanvas.gameObject.SetActive(false);

        // If current canvas index is less than the length of the canvases array
        if (currentCanvasIndex < canvases.Length - 1)
        {
            // Increment the current canvas index
            currentCanvasIndex++;
        }
        else
        {
            // Set the current canvas index to 0
            currentCanvasIndex = 0;
        }

        // Activate the next canvas
        currentCanvas = canvases[currentCanvasIndex];
        currentCanvas.gameObject.SetActive(true);
    }

    public void PreviousCanvas()
    {
        // Deactivate the current canvas
        currentCanvas.gameObject.SetActive(false);

        // If current canvas index is greater than 0
        if (currentCanvasIndex > 0)
        {
            // Decrement the current canvas index
            currentCanvasIndex--;
        }
        else
        {
            // Set the current canvas index to the length of the canvases array
            currentCanvasIndex = canvases.Length - 1;
        }

        // Activate the previous canvas
        currentCanvas = canvases[currentCanvasIndex];
        currentCanvas.gameObject.SetActive(true);
    }

    public void SetCanvas(int index)
    {
        // Deactivate the current canvas
        currentCanvas.gameObject.SetActive(false);

        // Set the current canvas index to the index
        currentCanvasIndex = index;

        // Activate the canvas at the current canvas index
        currentCanvas = canvases[currentCanvasIndex];
        currentCanvas.gameObject.SetActive(true);
    }

    public void StartMission()
    {
        DeactivateCanvases();
        // activate Dialog group
        dialogGroup.SetActive(true);
    }

    public void EndMission()
    {
        DeactivateCanvases();
        //reactivate HUD
        hudCanvas.SetActive(true);
    }

    public void WinGame()
    {
        SetCanvas(3);
    }

    public void LoseGame()
    {
        SetCanvas(4);
    }

    // ------------------------------------------------------------
    // Unity Methods
    // ------------------------------------------------------------
    void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }


    void Start()
    {

        // Turn off the intro canvas
        introCanvas.SetActive(false);

        // Turn on Intro music
        //AudioManager.instance.PlayIntroMusic();

        // Deactivate all canvases
        foreach (Canvas canvas in canvases)
        {
            canvas.gameObject.SetActive(false);
        }

        // Set the current canvas to the currentCanvasIndex
        currentCanvas = canvases[currentCanvasIndex];

        // Activate the current canvas
        currentCanvas.gameObject.SetActive(true);

    }


    public void UpdateParkSentiment(float parkSentiment)
    {
        parkSentimentText.text = Convert.ToString(Math.Round(parkSentiment, 2)) + "%";
    }

    public void UpdateIncome(float income)
    {
        incomeText.text = "$" + Convert.ToString(Math.Round(income, 2));
    }

    public void PostFeedback(string message, float fadeTime = 30.0f)
    {
        feedbackStatusText.text = message;
        StartCoroutine(FeedbackDelay(fadeTime));
    }

    IEnumerator FeedbackDelay(float time)
    {
        yield return new WaitForSeconds(time);
        feedbackStatusText.text = "";
    }

    public void DisplayStatus(string message)
    {
        feedbackStatusText.text = message;
    }
}

