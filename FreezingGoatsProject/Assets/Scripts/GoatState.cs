using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatState : MonoBehaviour
{
    public int hitpoints = 2;
    public GameObject iceBlock;

   public void headButtEvent(GameObject kicker)
    {
        hitpoints--;
        if (hitpoints <= 0)
        {
            DIE();
        }
    }

    public void DIE()
    {
        iceBlock.SetActive(true);
        InputController killme = gameObject.GetComponent<InputController>(); 
        GoatController killme2 = gameObject.GetComponent<GoatController>();
        if (killme != null) Destroy(killme);
        if (killme2 != null) Destroy(killme2);
    }
}
