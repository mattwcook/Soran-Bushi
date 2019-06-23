using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    GameObject spawnPointsParent;
    public Vector2 spawnAreaDimensions;
    public float minDancerDistance;
    int dancersNumber;
    GameObject spawnPoint;
    float randX;
    float randZ;
    Vector3 spawnPosition;

    public GameObject SpawnPointsObject => spawnPointsParent;
    // Start is called before the first frame update
    void Awake()
    {
        spawnPointsParent = transform.Find("Spawn Points Parent").gameObject;
        dancersNumber = 20;
        int num = 0;
        while (num < dancersNumber)
        {
            GetNewSpawnPoint();
            num = spawnPointsParent.transform.childCount;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetNewSpawnPoint()
    {
        randX = Random.Range(-spawnAreaDimensions.x / 2f, spawnAreaDimensions.x / 2f);
        randZ = Random.Range(-spawnAreaDimensions.y / 2f, spawnAreaDimensions.y / 2f);
        spawnPosition = new Vector3(randX, 0.0f, randZ);
        while (spawnPosition.magnitude < minDancerDistance)
        {
            return;
        }

        foreach (Transform tr in spawnPointsParent.transform)
        {
            if ((tr.position - spawnPosition).magnitude < minDancerDistance)
            {
                return;
            }
        }

        spawnPoint = new GameObject();
        spawnPoint.transform.SetParent(spawnPointsParent.transform);
        spawnPoint.transform.localPosition = spawnPosition;
        spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x, 0f, spawnPoint.transform.position.z);
    }
}
