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


    public string[] firstMissionText;

    public void FirstMission()
    {
        ClearCards();
        CanvasManager.instance.StartMission();
        StartCoroutine(first_mission(3.0f));
        //
    }

    IEnumerator first_mission(float time)
    {
        SpeakToYou(0, firstMissionText[0]);
        yield return new WaitForSeconds(time);
        ClearCards();
        YouSpeak(firstMissionText[1]);
        yield return new WaitForSeconds(time);
        ClearCards();
        YouSpeak(firstMissionText[2]);
        yield return new WaitForSeconds(time);
        ClearCards();
        SpeakToYou(0, firstMissionText[3]);
        yield return new WaitForSeconds(time);
        ClearCards();
        YouSpeak(firstMissionText[4]);
        yield return new WaitForSeconds(time);
        ClearCards();
        CanvasManager.instance.EndMission();
        CanvasManager.instance.PostFeedback(firstMissionText[5]);
    }

    public string[] secondMissionText;

    public void SecondMission()
    {
        ClearCards();
        CanvasManager.instance.StartMission();
        StartCoroutine(second_mission(3.0f));
        //
    }

    IEnumerator second_mission(float time)
    {
        SpeakToYou(0, secondMissionText[0]);
        yield return new WaitForSeconds(time);
        ClearCards();
        YouSpeak(secondMissionText[1]);
        yield return new WaitForSeconds(time);
        ClearCards();
        SpeakToYou(0, secondMissionText[2]);
        yield return new WaitForSeconds(time);
        ClearCards();
        YouSpeak(secondMissionText[3]);
        yield return new WaitForSeconds(time);
        ClearCards();
        CanvasManager.instance.EndMission();
        CanvasManager.instance.PostFeedback(secondMissionText[4]);
    }

    public string[] thirdMissionText;

    public void ThirdMission()
    {
        ClearCards();
        CanvasManager.instance.StartMission();
        StartCoroutine(third_mission(3.0f));
        //
    }

    IEnumerator third_mission(float time)
    {
        SpeakToYou(0, thirdMissionText[0]);
        yield return new WaitForSeconds(time);
        ClearCards();
        YouSpeak(thirdMissionText[1]);
        yield return new WaitForSeconds(time);
        ClearCards();
        SpeakToYou(0, thirdMissionText[2]);
        yield return new WaitForSeconds(time);
        ClearCards();
        YouSpeak(thirdMissionText[3]);
        yield return new WaitForSeconds(time);
        ClearCards();
        CanvasManager.instance.EndMission();
        CanvasManager.instance.PostFeedback(thirdMissionText[4]);
    }

}
