using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] typePointsObjects;
    public GameObject[] typeBadObjects;
    public GameObject[] typeDeathObjects;
    public GameObject[] typePowerUpsObjects;
    public GameObject[] typeHealthObjects;

    private int typePointsWeight = 6;
    private int typeDeathWeight = 9;
    private int typeBadWeight = 10;
    private int typePowerUpsWeight = 11;
    private int typeHealthWeight = 12;

    void Start(){
        float spawnDelay = Random.Range(2f, 3f);
        InvokeRepeating("SpawnObject", 1f, spawnDelay);
    }

    void Update()
    {}

    void SpawnObject()
    {
        GameObject[] chosenArray = ChooseRandomType();
        GameObject prefabToSpawn = chosenArray[Random.Range(0, chosenArray.Length)];
        
        Vector2 spawnPosition = new Vector2(Random.Range(-2.3f, 2.3f), 6f);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    GameObject[] ChooseRandomType()
    {
        int random = Random.Range(0, 10);
        if (random < typePointsWeight){return typePointsObjects;}
        else if (random < typeDeathWeight){return typeDeathObjects;} 
        else if (random < typeBadWeight){return typeBadObjects;} 
    
        // else if (random < typePowerUpsWeight){return typePowerUpsObjects;} 
        // else if (random < typeHealthWeight){return typeHealthObjects;} 
        else return null;
    }
}