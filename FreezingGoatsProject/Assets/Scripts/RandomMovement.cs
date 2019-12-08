using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = .000001f;
    public float sinusAmplitude = .0001f;
    public float sinusFrequency = 5f;
    void FixedUpdate()
    {
        transform.Translate(speed*Time.fixedDeltaTime, Mathf.Sin(Time.time* sinusFrequency) * sinusAmplitude * Time.fixedDeltaTime, 0);
    }
}
