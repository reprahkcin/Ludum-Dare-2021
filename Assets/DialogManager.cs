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

}
