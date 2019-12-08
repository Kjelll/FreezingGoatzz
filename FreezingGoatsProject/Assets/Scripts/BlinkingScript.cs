using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingScript : MonoBehaviour
{
    public Animator animator;

    private float timeToBlink;
    private float timeBlink;
    private bool isBlinking;

    void Start()
    {
        timeToBlink = genTimeToBlink();
        timeBlink = genTimeBlink();
        isBlinking = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!isBlinking) {
            timeToBlink -= Time.deltaTime;

            if (timeToBlink < 0)
            {
                isBlinking = true;
                animator.SetBool("isBlinking", isBlinking);
                timeToBlink = genTimeToBlink();
            }
        }
        else {
            timeBlink -= Time.deltaTime;
            if(timeBlink < 0)
            {
                isBlinking = false;
                animator.SetBool("isBlinking", isBlinking);
                timeBlink = genTimeBlink();
            }
        }
    }

    private float genTimeToBlink()
    {
        float rand = Random.Range(0, 10);
        float ttb;
        if (rand < 2)
        {
            ttb = Random.Range(1.0f, 2.0f);
        }
        else if (rand < 8)
        {
            ttb = Random.Range(2.0f, 5.0f);
        }
        else
        {
            ttb = Random.Range(5.0f, 7.0f);
        }
        return ttb;
    }

    private float genTimeBlink()
    {
        float rand = Random.Range(0, 10);
        float tb;
        if (rand < 2)
        {
            tb = Random.Range(0.1f, 0.2f);
        }
        else if (rand < 8)
        {
            tb = Random.Range(.2f, 0.7f);
        }
        else
        {
            tb = Random.Range(0.7f, 0.9f);
        }
        return tb;
    }
}
