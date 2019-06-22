using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public struct TimedPose
{
    public float elapsedTime;

    public Vector3 headPosition;
    public Quaternion headRotation;

    public Vector3 leftHandPosition;
    public Quaternion leftHandRotation;

    public Vector3 rightHandPosition;
    public Quaternion rightHandRotation;
}

public class RecordPlayerMovement : MonoBehaviour
{
    bool isRecording;
    float timeSinceStart;
    List<TimedPose> posesCollected;

    public List<TimedPose> Poses => posesCollected;

    [SerializeField]
    private Transform head;

    [SerializeField]
    private Transform leftHand;

    [SerializeField]
    private Transform rightHand;

    [SerializeField]
    private string myName;

    // Start is called before the first frame update
    void Start()
    {
        posesCollected = new List<TimedPose>();
    }

    public void StartRecording()
    {
        timeSinceStart = 0f;
        isRecording = true;
        posesCollected.Clear();
    }

    public void StopRecording()
    {
        isRecording = false;
        SaveAsFile(myName);
    }

    string ConvertToString(TimedPose pose)
    {
        string line = pose.elapsedTime + ", " + pose.headPosition.x + ", " +
            pose.headPosition.y + ", " + pose.headPosition.z + ", " +
            pose.headRotation.w + ", " + pose.headRotation.x + ", " + pose.headRotation.y + ", " + pose.headRotation.z + ", " +
            pose.leftHandPosition.x + ", " + pose.leftHandPosition.y + ", " + pose.leftHandPosition.z + ", " +
            pose.leftHandRotation.w + ", " + pose.leftHandRotation.x + ", " + pose.leftHandRotation.y + ", " + pose.leftHandRotation.z + ", " +
            pose.rightHandPosition.x + ", " + pose.rightHandPosition.y + ", " + pose.rightHandPosition.z + ", " +
            pose.rightHandRotation.w + ", " + pose.rightHandRotation.x + ", " + pose.rightHandRotation.y + ", " + pose.rightHandRotation.z + ";";
        return line;
    }

    void SaveAsFile(string filename)
    {
        StreamWriter writer = new StreamWriter("Assets/Resources/"+filename+".txt", true);

        //List<string> lines = new List<string>();
        foreach(TimedPose pose in posesCollected)
        {
            writer.WriteLine(ConvertToString(pose));
        }
        writer.Close();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isRecording)
            {
                StopRecording();
            }
            else
            {
                StartRecording();
            }
        }
        if (isRecording)
        {
            TimedPose t = new TimedPose();
            t.elapsedTime = timeSinceStart;
            t.headPosition = head.localPosition;
            t.headRotation = head.localRotation;
            t.leftHandPosition = leftHand.localPosition;
            t.leftHandRotation = leftHand.localRotation;
            t.rightHandPosition = rightHand.localPosition;
            t.rightHandRotation = rightHand.localRotation;
            posesCollected.Add(t);
            timeSinceStart += Time.deltaTime;
        }
    }
}
