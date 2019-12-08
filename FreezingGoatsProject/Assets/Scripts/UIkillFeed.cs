using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIkillFeed : MonoBehaviour
{
    public static UIkillFeed instance;
    public Text Goat1kills;
    public Text Goat2kills;
    public Text Goat3kills;
    public Text Goat4kills;



    public int killCount1 = 0;
    public int killCount2 = 0;
    public int killCount3 = 0;
    public int killCount4 = 0;

    public int totalKills = 0;

    private void Awake()
    {
        instance = this;
    }

    public void reportKiller(int killerTag)
    {
        totalKills++;
        switch (killerTag)
        {
            case 1: goat1kill(); break;
            case 2: goat2kill(); break;
            case 3: goat3kill(); break;
            case 4: goat4kill(); break;

        }
    }

    public int getMaxKills()
    {
        return Mathf.Max(killCount1, killCount2, killCount3, killCount4);
    }
    public int getWinner()
    {
        int max = Mathf.Max(killCount1, killCount2, killCount3, killCount4);
        if(max== killCount1)
        {
            return 1;

        }
        if (max == killCount2)
        {
            return 2;
        } 
        if (max == killCount3)
        {
            return 3;

        }
        return 4;

    }

    public void goat1kill() {  
        Goat1kills.text = "" + ++killCount1;
    }
    public void goat2kill()
    {
        Goat2kills.text = "" + ++killCount2;

    }
    public void goat3kill()
    {
        Goat3kills.text = "" + ++killCount3;

    }
    public void goat4kill()
    {
        Goat4kills.text = "" + ++killCount4;

    }
}
