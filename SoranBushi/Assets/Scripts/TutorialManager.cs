using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject shipCaptain;
    public GameObject playerShadow;
    int playbackCounter = 0;

    float timer = 0.0f;

    AudioSource helloGibberish;
    AudioSource followMeGibberish;
    AudioSource wellDoneGibberish;
    AudioSource letsStartGibberish;
    // Start is called before the first frame update
    void Start()
    {
        helloGibberish = shipCaptain.transform.Find("Hello Audio").gameObject.GetComponent<AudioSource>();
        followMeGibberish = shipCaptain.transform.Find("Follow Me Audio").gameObject.GetComponent<AudioSource>();
        wellDoneGibberish = shipCaptain.transform.Find("Well Done Audio").gameObject.GetComponent<AudioSource>();
        letsStartGibberish = shipCaptain.transform.Find("Lets Start Audio").gameObject.GetComponent<AudioSource>();

        ////////// Captain start wave hello
        //shipCaptain.GetComponent<DancePlayback>().ChangeName(file.Name.Replace());

        ////////// Captain start intro audio
        helloGibberish.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        ////// After enough waves, turn off welcome text, turn on follow shadow, inititite first 
        ////// move at low speed, initiate follow me text, initiate follow me audio
        /*
        if (timer >= )
        {
            timer = 0
        }
        */
        
    }

    void PlaybackEnded()
    {
        playbackCounter += 1;
    }
    
}
