using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{
    public static EndScreenScript instance;

    public Text MurderMasterText;
    public Text highScoreText;
    public GameObject anchorMurder;
    public GameObject anchorHighScore;
    public List<GameObject> toEnable = new List<GameObject>();
    public List<GameObject> toDisable = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    public void endgame()
    {
        int murderer = UIkillFeed.instance.getWinner(); 
        GoatState highest = CameraMovement.instance.highestGoat;

        fillKillCount(UIkillFeed.instance.getMaxKills());
        fillHighScore(CameraMovement.instance.allTimeMaxHeight);


        SpawningScript.instance.spawnAtPos(murderer, anchorMurder.transform.position);
        SpawningScript.instance.spawnAtPos(highest.playerNumber, anchorHighScore.transform.position); 


        foreach (GameObject go in toEnable)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in toDisable)
        {
            go.SetActive(false);
        }
        foreach (GoatState go in CameraMovement.instance.trackingGoats)
        {
            go.gameObject.SetActive(false);
        }
         
    }

    public void fillKillCount(int frozenGoats)
    {
        MurderMasterText.text = MurderMasterText.text + " " + frozenGoats;
    }
    public void fillHighScore(float height)
    {
        highScoreText.text = highScoreText.text + " " + height*7f + "m";
    }
}
