using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public float timeBetweenSpawn = 10f;
    public float timeSinceSpawn = 0f;
    public GameObject objectToSpawn;

    // Update is called once per frame
    void Update()
    {
        SpawnIfTime();
    }

    private void SpawnIfTime()
    {
        if(timeSinceSpawn > timeBetweenSpawn)
        {
            SpawnObject(objectToSpawn);
        }
        else
        {
            timeSinceSpawn += Time.deltaTime;
        }
    }

    private void SpawnObject(GameObject theObject)
    {
        GameObject newBox = Instantiate(theObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
        timeSinceSpawn = 0;
    }
}
