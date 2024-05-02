using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Adjust the speed of rotation
    public float angleOfChange = 0.7f; 


    // Update is called once per frame
    void FixedUpdate()
    {
        // rotate the object along its y axis by AngleOfChange each frame
        transform.Rotate(0, 0, angleOfChange);
    }
}
