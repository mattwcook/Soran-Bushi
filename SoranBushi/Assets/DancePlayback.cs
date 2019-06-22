using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancePlayback : MonoBehaviour
{
    bool isPlayback;

    [SerializeField]
    RecordPlayerMovement records;

    float timeSinceStart;
    int playbackIndex;

    [SerializeField]
    private Transform head;

    [SerializeField]
    private Transform leftHand;

    [SerializeField]
    private Transform rightHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void StartPlayback()
    {
        isPlayback = true;
        timeSinceStart = 0f;
        playbackIndex = 0;
    }

    void StopPlayback()
    {
        isPlayback = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPlayback)
            {
                StopPlayback();
            }
            else
            {
                StartPlayback();
            }
        }

        if(isPlayback)
        {
            if(timeSinceStart > records.Poses[playbackIndex].elapsedTime)
            {
                playbackIndex += 1;
            }

            if(playbackIndex < records.Poses.Count)
            {
                TimedPose t = records.Poses[playbackIndex];

                head.localPosition = t.headPosition;
                head.localRotation = t.headRotation;

                leftHand.localPosition = t.leftHandPosition;
                leftHand.localRotation = t.leftHandRotation;

                rightHand.localPosition = t.rightHandPosition;
                rightHand.localRotation = t.rightHandRotation;

                timeSinceStart += Time.deltaTime;
            }
            else
            {
                StopPlayback();
            }
        }
    }
}
