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
    // Start is called before the first frame update
    void Start()
    {
        helloGibberish = shipCaptain.transform.Find("Hello Audio").gameObject.GetComponent<AudioSource>();

        ////////// Captain start wave hello
        //shipCaptain.ChangeName(file.Name.Replace());

        ////////// Captain start intro audio
        helloGibberish.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
    }
    
}
