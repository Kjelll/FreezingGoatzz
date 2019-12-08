using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;
    public List<GoatState> trackingGoats;

    public Camera mainCam;

    public float followTolerance = 0.5f;

    public float allTimeMaxHeight = -1000f;
    public GoatState highestGoat;
    private void Awake()
    {
        if(mainCam == null) mainCam = Camera.main;
        instance = this;
    }
    public void subscribe(GoatState startTracking)
    {
        trackingGoats.Add(startTracking);
    }
    public void unsubscribe(GoatState stopTracking)
    {
        trackingGoats.Remove(stopTracking);
    }
 
    public Vector2 maxAndMin()
    {
        if (trackingGoats.Count == 0) return Vector2.zero;
        Vector2 output = new Vector2( trackingGoats[0].transform.position.y, trackingGoats[0].transform.position.y) ;
        foreach (GoatState gs in trackingGoats)
        {
            if (gs.transform.position.y > output.x)
            {
                output.x = gs.transform.position.y;

                if (output.x > allTimeMaxHeight)
                {
                    allTimeMaxHeight = output.x;
                    highestGoat = gs;
                }
            }
            if (gs.transform.position.y < output.x)
            {
                output.y = gs.transform.position.y;
            }
        }
        
        return output;
    }


    private void FixedUpdate()
    {
        Vector2 maxMin = maxAndMin();
        if (maxMin.x > mainCam.transform.position.y + mainCam.orthographicSize - followTolerance)
        {
            mainCam.transform.position = new Vector3(mainCam.transform.position.x, maxMin.x + followTolerance - mainCam.orthographicSize, mainCam.transform.position.z);
        }

        if (maxMin.y < mainCam.transform.position.y - mainCam.orthographicSize + followTolerance)
        {

            if (maxMin.x < mainCam.transform.position.y + mainCam.orthographicSize - followTolerance)
            {
                mainCam.transform.position = new Vector3(mainCam.transform.position.x, Mathf.Max( maxMin.y - followTolerance + mainCam.orthographicSize, maxMin.x + followTolerance - mainCam.orthographicSize), mainCam.transform.position.z);
            }
        }
    }
}
