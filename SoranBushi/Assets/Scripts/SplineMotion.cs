using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineMotion : MonoBehaviour
{
    public int numberOfPoints;
    public Transform endPoint;
    public int numberOfHarmonics;
    public float amplitude;
    float offSet;
    public float waveSpeed;
    float L;
    float x;
    float y;
    float z;
    Vector3[] vertices;
    

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        L = (endPoint.position - transform.position).magnitude;
        offSet += waveSpeed * Time.deltaTime;
        transform.LookAt(endPoint);
        vertices = new Vector3[numberOfPoints + 1];
        GetComponent<LineRenderer>().positionCount = numberOfPoints + 1;
        for (int i = 0; i <= numberOfPoints; i++)
        {
            // Free Wave
            //x = amplitude * Mathf.Sin(360.0f * numberOfHarmonics / numberOfPoints * i * Mathf.PI / 180.0f + offSet);

            // Double Fixed Standing Wave
            x = amplitude * Mathf.Sin(360.0f * numberOfHarmonics / numberOfPoints * i * Mathf.PI / 180.0f) * Mathf.Cos(offSet);


            y = 0.0f;
            z = L / numberOfPoints * i;
            vertices[i] = new Vector3(x, y, z);
        }
        GetComponent<LineRenderer>().SetPositions(vertices);
    }
}
