using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatState : MonoBehaviour
{
    public int hitpoints = 2;
    public GameObject iceObjects;
    public GameObject iceBlock;
    public GameObject totalFreezeBlock;

    public void headButtEvent(float yeetPowa, Rigidbody2D r2b2)
    {
        hitpoints--;
        if (yeetPowa > 3)
        {
            hitpoints -= (int) yeetPowa;
        }
        if (hitpoints <= 0)
        {
            DIE(r2b2);
        }
    }

    public void DIE(Rigidbody2D r2b2)
    {
        iceObjects.SetActive(true);
        iceBlock.SetActive(true);
        InputController killme = gameObject.GetComponent<InputController>(); 
        GoatController killme2 = gameObject.GetComponent<GoatController>();
        if (killme != null)
        {
            SpawningScript.instance.reportDeath(killme.controllerSuffix);
            Destroy(killme);
        }
        if (killme2 != null) Destroy(killme2);
        StartCoroutine( disableAfterSeconds(r2b2, 10f));
    }


    public IEnumerator disableAfterSeconds(Rigidbody2D r2b2, float seconds)
    { 
        yield return new WaitForSeconds(seconds);
        Destroy(r2b2);
        totalFreezeBlock.SetActive(true);
        iceBlock.SetActive(false);
    }
}
