using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour
{
    string[] filePaths;

    public static GameManager Instance;

    DirectoryInfo directoryInfo;
    FileInfo[] files;

    [SerializeField]
    DancePlayback dancerPrefab;

    List<DancePlayback> dancers;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        dancers = new List<DancePlayback>();
        directoryInfo = new DirectoryInfo("Assets/Resources/");
        files = directoryInfo.GetFiles("*.txt").OrderByDescending(p => p.CreationTime).ToArray();
        foreach(FileInfo file in files)
        {
            //make a dancer for each file
            DancePlayback dancerInstance = GameObject.Instantiate<DancePlayback>(dancerPrefab, new Vector3((Random.value * 10f) + .3f, 0f, (Random.value * 10f) + .3f), Quaternion.identity);
            dancerInstance.ChangeName(file.Name.Replace(".txt", ""));
            dancers.Add(dancerInstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //spawn players randomly
            foreach (DancePlayback dancer in dancers)
            {
                dancer.StartPlayback();
            }
        }

    }

    public DancePlayback GetDancer(int idx)
    {
        return dancers[idx];
    }

    public int GetNumberOfDancers()
    {
        return Mathf.Min(20, files.Length);
    }
}
