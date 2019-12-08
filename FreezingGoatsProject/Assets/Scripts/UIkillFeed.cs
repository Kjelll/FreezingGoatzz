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



    public void goat1kill() {  
        Goat1kills.text = "" + ( int.Parse(Goat1kills.text) + 1);
    }
    public void goat2kill()
    {
        Goat2kills.text = "" + (int.Parse(Goat2kills.text) + 1);

    }
    public void goat3kill()
    {
        Goat3kills.text = "" + (int.Parse(Goat3kills.text) + 1);

    }
    public void goat4kill()
    {
        Goat4kills.text = "" + (int.Parse(Goat4kills.text) + 1);

    }
}
