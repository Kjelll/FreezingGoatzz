using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public List<GameObject> trackingObjects;

    public Camera mainCam;

    public float topFollowMinimum = 0.5f;


    private void Awake()
    {
        if(mainCam == null) mainCam = Camera.main;
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
        if (maxMin.x > mainCam.transform.position.y + mainCam.orthographicSize - topFollowMinimum)
        {
            mainCam.transform.position = new Vector3(mainCam.transform.position.x, maxMin.x + topFollowMinimum - mainCam.orthographicSize, mainCam.transform.position.z);
        }

        if (maxMin.y < mainCam.transform.position.y - mainCam.orthographicSize)
        {

            if (maxMin.x < mainCam.transform.position.y + mainCam.orthographicSize - topFollowMinimum)
            {
                mainCam.transform.position = new Vector3(mainCam.transform.position.x, Mathf.Max( maxMin.y + mainCam.orthographicSize, maxMin.x + topFollowMinimum - mainCam.orthographicSize), mainCam.transform.position.z);
            }
        }
    }
}
