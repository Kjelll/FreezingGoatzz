using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatState : MonoBehaviour
{
    public int hitpoints = 2;
    public GameObject iceObjects;
    public GameObject iceBlock;
    public int playerNumber;
    private void Awake()
    {
        InputController ownIC =  GetComponent<InputController>();
        if (ownIC != null)
        {
            playerNumber = int.Parse( ownIC.controllerSuffix);

        }

}
    public void headButtEvent(float yeetPowa, Rigidbody2D r2b2, GoatState attacker)
    {
        hitpoints--;
        if (yeetPowa >  1.0f)
        {
            Debug.Log("Yeeted with a powa of " + yeetPowa);
            hitpoints -= (int) yeetPowa;
            Debug.Log("To hitpoints: " + hitpoints);
        }
        if (hitpoints <= 0)
        { 
            UIkillFeed.instance.reportKiller(attacker.playerNumber);  
            DIE(r2b2);
        }
    }

    public void DIE(Rigidbody2D r2b2)   //makes the rigidbody targeted DIE
    {
        iceObjects.SetActive(true);
        iceBlock.SetActive(true);
        CameraMovement.instance.unsubscribe(r2b2.gameObject.GetComponent<GoatState>());

        InputController killme = r2b2.gameObject.GetComponent<InputController>(); 
        GoatController killme2 = r2b2.gameObject.GetComponent<GoatController>();
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
        iceBlock.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 1f, 0.7f);
        yield return new WaitForSeconds(seconds);
        Destroy(r2b2);
        iceBlock.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 1f, 0.9f);
    }
}
