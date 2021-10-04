using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI textToYou;
    public TextMeshProUGUI textFromYou;

    public GameObject theirCard;
    public GameObject yourCard;
    public GameObject[] cards;

    public GameObject[] otherPeoplePortraits;



    public void SpeakToYou(int portrait, string msg)
    {
        theirCard.SetActive(true);

        // activate the appropriate portrait
        foreach (GameObject img in otherPeoplePortraits)
        {
            img.SetActive(false);
        }

        otherPeoplePortraits[portrait].SetActive(true);
        textToYou.text = msg;
    }

    public void YouSpeak(string msg)
    {
        yourCard.SetActive(true);
        textFromYou.text = msg;
    }

    public void ClearCards()
    {
        theirCard.SetActive(false);
        yourCard.SetActive(false);
    }


    public string[] missionText;

    public void FirstMission()
    {

        ClearCards();
        CanvasManager.instance.StartMission();
        StartCoroutine(SpeechDelay(3.0f));
        //

    }

    IEnumerator SpeechDelay(float time)
    {
        SpeakToYou(0, missionText[0]);
        yield return new WaitForSeconds(time);
        ClearCards();
        YouSpeak(missionText[1]);
        yield return new WaitForSeconds(time);
        ClearCards();
        YouSpeak(missionText[2]);
        yield return new WaitForSeconds(time);
        ClearCards();
        SpeakToYou(0, missionText[3]);
        yield return new WaitForSeconds(time);
        ClearCards();
        YouSpeak(missionText[4]);
        yield return new WaitForSeconds(time);
        ClearCards();
        CanvasManager.instance.PostFeedback(missionText[5]);




    }

}
