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

    // Start is called before the first frame update
    void Start()
    {
        spawnPointsParent = transform.Find("Spawn Points Parent").gameObject;
        dancersNumber = GameManager.Instance.GetNumberOfDancers();
        for (int i = 0; i<= dancersNumber; i++)
        {
            GetNewSpawnPoint();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetNewSpawnPoint()
    {
        randX = Random.Range(-spawnAreaDimensions.x / 2, spawnAreaDimensions.x / 2);
        randZ = Random.Range(-spawnAreaDimensions.y / 2, spawnAreaDimensions.y / 2);
        spawnPosition = new Vector3(randX, 0.0f, randZ);
        if ((spawnPosition - transform.position).magnitude < minDancerDistance)
        {
            GetNewSpawnPoint();
        }
        foreach (Transform T in spawnPointsParent.transform)
        {
            if ((T.position - spawnPosition).magnitude < minDancerDistance)
            {
                GetNewSpawnPoint();
            }
            else
            {
                spawnPoint = new GameObject();
                spawnPoint.transform.SetParent(spawnPointsParent.transform);
                spawnPoint.transform.localPosition = spawnPosition;
            }
        }
    }
}
