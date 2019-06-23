// Smooth towards the target

using UnityEngine;
using System.Collections;

public class UIFollow : MonoBehaviour
{
    Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    PlayerScript player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        //target = player.Head.transform;
    }
    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.transform.TransformPoint(new Vector3(0, 0, 3f));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(target);
    }
}
