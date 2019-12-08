using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;
    public List<GameObject> trackingObjects;

    public Camera mainCam;

    public float followTolerance = 0.5f;

    public float allTimeMaxHeight = 0f;
    
    private void Awake()
    {
        if(mainCam == null) mainCam = Camera.main;
        instance = this;
    }
    public void subscribe(GameObject startTracking)
    {
        trackingObjects.Add(startTracking);
    }
    public void unsubscribe(GameObject stopTracking)
    {
        trackingObjects.Remove(stopTracking);
    }

    public GameObject getHighest()
    {
        GameObject output = trackingObjects[0];
        foreach(GameObject go in trackingObjects)
        {
            if (go.transform.position.y > output.transform.position.y)
            {
                output = go;
            }
        }
        return output;
    }
    public Vector2 maxAndMin()
    {
        if (trackingObjects.Count == 0) return Vector2.zero;
        Vector2 output = new Vector2( trackingObjects[0].transform.position.y, trackingObjects[0].transform.position.y) ;
        foreach (GameObject go in trackingObjects)
        {
            if (go.transform.position.y > output.x)
            {
                output.x = go.transform.position.y;

                if (output.x > allTimeMaxHeight)
                {
                    allTimeMaxHeight = output.x;
                }
            }
            if (go.transform.position.y < output.x)
            {
                output.y = go.transform.position.y;
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
