using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public static SpawningScript instance;

    public GameObject PlayerPrefab1;
    public GameObject PlayerPrefab2;
    public GameObject PlayerPrefab3;
    public GameObject PlayerPrefab4;


    public GameObject spawnPosition;


    private void Awake()
    {
        instance = this;
    }

    public void reportDeath(string controllerSuffix)
    {
    
        int playerNum = int.Parse(controllerSuffix);
        GameObject toInstantiate = PlayerPrefab1;
        switch (playerNum)
        {
            case 2: toInstantiate = PlayerPrefab2; break;
            case 3: toInstantiate = PlayerPrefab3; break;
            case 4: toInstantiate = PlayerPrefab4; break;

        }
        GameObject newSpawn = Instantiate(toInstantiate, spawnPosition.transform.position, Quaternion.identity);

        CameraMovement.instance.subscribe(newSpawn.GetComponent< GoatState>());

    }

    public GameObject spawnAtPos(int playerNum,Vector3 posi)
    {
        GameObject toInstantiate = PlayerPrefab1;
        switch (playerNum)
        {
            case 2: toInstantiate = PlayerPrefab2; break;
            case 3: toInstantiate = PlayerPrefab3; break;
            case 4: toInstantiate = PlayerPrefab4; break;

        }
        GameObject newSpawn = Instantiate(toInstantiate,  posi, Quaternion.identity);

        return newSpawn;
    }


}
