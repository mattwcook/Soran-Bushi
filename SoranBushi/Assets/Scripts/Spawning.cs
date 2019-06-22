using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameManager manager;
    public GameObject spawnPointsParent;
    public Vector2 spawnAreaDimensions;
    public float minDancerDistance;
    int dancersNumber;
    GameObject spawnPoint;
    float randX;
    float randZ;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        numberOfDancers = manager.numberOfDancers;
        for (int i = 0; i<= dancersNumber; i++)
        {
            randX = Random.Range(-spawnAreaDimensions.x / 2, spawnAreaDimensions.x / 2);
            randZ = Random.Range(-spawnAreaDimensions.y / 2, spawnAreaDimensions.y / 2);
            spawnPosition = new Vector3(randX, 0.0f, randZ);
            foreach (transform T in spawnPointsParent)
            {
                if (T - new Vector3())
            }
            spawnPoint = new GameObject();
            spawnPoint.transform.SetParent(spawnPointsParent.transform);

            spawnPoint.transform.localPosition = new Vector3();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
