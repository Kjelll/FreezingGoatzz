using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionWrapper : MonoBehaviour
{
    public static float maxLeftPos = -6;    //7 is the border of the camera
    public static float maxRightPos = 6; 
    public static float pushIntoScreenPower = 200f;
    private Rigidbody2D m_Rigidbody2D;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


        void FixedUpdate()
        {
        if (m_Rigidbody2D == null) return;
            if(transform.position.x > maxRightPos)
            {
                transform.position = new Vector3( maxLeftPos + .1f, transform.position.y, transform.position.z);
            if (m_Rigidbody2D.velocity.x > 5f)
            {
                m_Rigidbody2D.AddForce(new Vector2(pushIntoScreenPower, pushIntoScreenPower / 20f)); 
            }
        }
        if (transform.position.x < maxLeftPos)
        {
            transform.position = new Vector3(maxRightPos - 0.1f, transform.position.y, transform.position.z);
            if (m_Rigidbody2D.velocity.x < -5f)
            {
                m_Rigidbody2D.AddForce(new Vector2(-pushIntoScreenPower, pushIntoScreenPower / 20f));
            }
        }
        }
}
