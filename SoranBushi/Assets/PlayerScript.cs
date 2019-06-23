using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    RecordPlayerMovement recordMovement;

    Spawning spawnLogic;

    public RecordPlayerMovement RecordMovementLogic => recordMovement;

    public Spawning SpawnLogic => spawnLogic;

    // Start is called before the first frame update
    void Awake()
    {
        recordMovement = GetComponent<RecordPlayerMovement>();
        spawnLogic = GetComponent<Spawning>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
