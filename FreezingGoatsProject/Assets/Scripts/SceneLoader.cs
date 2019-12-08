using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    bool player1ready = false;
    bool player2ready = false;
    bool player3ready = false;
    bool player4ready = false;
    int controllerSuffix;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Scream1") >= 0.7f)
        {
            player1ready = true;
        }
        if (Input.GetAxis("Scream2") >= 0.7f)
        {
            player2ready = true;
        }
        if (Input.GetAxis("Scream3") >= 0.7f)
        {
            player3ready = true;
        }
        if (Input.GetAxis("Scream4") >= 0.7f)
        {
            player4ready = true;
        }

        if (Input.GetKeyDown(KeyCode.Return)||(player1ready&&player2ready&&player3ready&&player4ready))
        {
            SceneManager.LoadScene(1);
        }
    }
}
