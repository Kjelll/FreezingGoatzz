using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText;
    public float timeLeft = 180f; 
     

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        int seconds = (((int)timeLeft) % 60);
        countdownText.text = "" + ((int)(timeLeft / 60f)) + ":"  + ( (seconds<10) ? "0" : "" )+ seconds;
        if (timeLeft < 0f)
        {
            EndScreenScript.instance.endgame();
            Destroy(gameObject); //sepukku
        }
    }
}
