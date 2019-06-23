using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainStart : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string voiceActingEventString = "event:/";

    public FMOD.Studio.EventInstance voiceActingEvent;

    [SerializeField]
    DancePlayback captain;

    private void Start()
    {
        voiceActingEvent = FMODUnity.RuntimeManager.CreateInstance(voiceActingEventString);
        voiceActingEvent.start();
        //if(Input.GetKeyDown(KeyCode.S))
        //{
            captain.ChangeName("captain_0");
            captain.StartPlayback();
        //}

    }
}
