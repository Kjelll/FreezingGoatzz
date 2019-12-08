using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHighscore : MonoBehaviour
{
    public static UIHighscore instance;
    public RectTransform bottomAnchor;

    private void Awake()
    {
        instance = this;
    }

    

}
