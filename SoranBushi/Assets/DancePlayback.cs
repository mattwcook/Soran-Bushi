using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DancePlayback : MonoBehaviour
{
    bool isPlayback;

    RecordPlayerMovement records;

    float timeSinceStart;
    int playbackIndex;

    [SerializeField]
    private Transform head;

    [SerializeField]
    private Transform leftHand;

    [SerializeField]
    private Transform rightHand;

    private string filename;

    [SerializeField]
    private TextMesh nameText;

    private List<TimedPose> poses;

    // Start is called before the first frame update
    public void ChangeName(string nm)
    {
        filename = nm;
        nameText.text = filename;
        records = GameObject.Find("Player").GetComponent<RecordPlayerMovement>();
        Debug.Log("player found: " + records.name);
        //try to load a file
        //Re-import the file to update the reference in the editor
        TextAsset asset = Resources.Load<TextAsset>(filename);

        //if no file, use the player memory to playback poses
        if(asset != null && !string.IsNullOrEmpty(asset.text))
        {
            poses = new List<TimedPose>();
            string[] lines = asset.text.Split(';');
            foreach(string line in lines)
            {
                try
                {
                    string[] vals = line.Split(',');
                    TimedPose t = new TimedPose();
                    t.elapsedTime = float.Parse(vals[0]);
                    t.headPosition = new Vector3(float.Parse(vals[1]), float.Parse(vals[2]), float.Parse(vals[3]));
                    t.headRotation = new Quaternion(float.Parse(vals[5]), float.Parse(vals[6]), float.Parse(vals[7]), float.Parse(vals[8]));
                    t.leftHandPosition = new Vector3(float.Parse(vals[8]), float.Parse(vals[9]), float.Parse(vals[10]));
                    t.leftHandRotation = new Quaternion(float.Parse(vals[12]), float.Parse(vals[13]), float.Parse(vals[14]), float.Parse(vals[11]));
                    t.rightHandPosition = new Vector3(float.Parse(vals[15]), float.Parse(vals[16]), float.Parse(vals[17]));
                    t.rightHandRotation = new Quaternion(float.Parse(vals[19]), float.Parse(vals[10]), float.Parse(vals[21]), float.Parse(vals[18]));

                    poses.Add(t);
                }
                catch(System.FormatException e)
                {
                    Debug.Log("incorrect line format detected.");
                }
            }

            Debug.Log("poses count: " + poses.Count);
        }
        else
        {
            poses = records.Poses;
        }
    }

    public void StartPlayback()
    {
        isPlayback = true;
        timeSinceStart = 0f;
        playbackIndex = 0;
    }

    public void StopPlayback()
    {
        isPlayback = false;

    }

    // Update is called once per frame
    void Update()
    {

        if(isPlayback)
        {
            if(timeSinceStart > poses[playbackIndex].elapsedTime)
            {
                playbackIndex += 1;
            }

            if(playbackIndex < poses.Count)
            {
                TimedPose t = poses[playbackIndex];

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
