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

    [SerializeField]
    DancePlayback captain;

    [SerializeField]
    List<DancePlayback> dancers;

    [FMODUnity.EventRef]
    public string musicEventString = "event:/";

    public FMOD.Studio.EventInstance musicEvent;
    public FMOD.Studio.ParameterInstance musicTransition;

    PlayerScript player;

    private void Start()
    {
        musicEvent = FMODUnity.RuntimeManager.CreateInstance(musicEventString);
        musicEvent.getParameter("TransitionGameMusic", out musicTransition);
        musicEvent.start();
        Instance = this;
        dancers = new List<DancePlayback>();
        directoryInfo = new DirectoryInfo("Assets/Resources/");
        files = directoryInfo.GetFiles("*.txt").OrderByDescending(p => p.CreationTime).ToArray();

        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        foreach (FileInfo file in files)
        {
            //make a dancer for each file
            if(file.Name != "captain.txt")
            {
                DancePlayback dancerInstance = GameObject.Instantiate<DancePlayback>(dancerPrefab, player.SpawnLogic.SpawnPointsObject.transform.GetChild(dancers.Count).position, Quaternion.identity);
                dancerInstance.ChangeName(file.Name.Replace(".txt", ""));
                dancers.Add(dancerInstance);
            }

        }
        captain.ChangeName("captain");

    }

    private void OnApplicationQuit()
    {
        player.RecordMovementLogic.StopRecording();
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
                musicTransition.setValue(1f);
            }
            captain.StartPlayback();

            player.RecordMovementLogic.StartRecording();

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
