﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHighscore : MonoBehaviour
{
    public static UIHighscore instance;
    public float conversionRate2UI = 0.01f;
    public RectTransform bottomAnchor;
    public RectTransform player1;
    public RectTransform player2;
    public RectTransform player3;
    public RectTransform player4;


    public Image maxHeightMarker;

    private void Awake()
    {
        instance = this;
    }
    
    public void setNewRecord(float height, GoatState gs)
    {
        if (gs == null)
        {
            Debug.Log("empty record holder?");
            return;
        }
        maxHeightMarker.color = gs.sprite.color;
        maxHeightMarker.transform.position = bottomAnchor.transform.position + new Vector3(0, height * conversionRate2UI,0);
    }
    

}
