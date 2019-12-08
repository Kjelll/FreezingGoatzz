using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{
    public Text MurderMasterText;
    public Text highScoreText;


    public void fillKillCount(int frozenGoats)
    {
        MurderMasterText.text = MurderMasterText.text + " " + frozenGoats;
    }
    public void fillHighScore(float height)
    {
        highScoreText.text = highScoreText.text + " " + height*7f + "m";
    }
}
