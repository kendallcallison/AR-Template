using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlane : MonoBehaviour
{
    public GameObject Plane;
    public GameObject Camera;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Transform parentTransform;

    private void Start()
    {
        // Store initial position and rotation
        initialPosition = Camera.transform.position;
        initialRotation = Camera.transform.rotation;

        // Store parent transform
        parentTransform = transform.parent;
    }

    // reset plane the hand 
    public void ResetPlane()
    {
        Plane.transform.localPosition = Camera.transform.position;
        
        Plane.transform.localRotation = Camera.transform.rotation;

        // Calculate the rotation to rotate the plane around 180 degrees
        Quaternion halfTurnRotation = Quaternion.Euler(0f, 180f, 0f);

        // Apply half-turn rotation to the plane
        Plane.transform.localRotation *= halfTurnRotation;


    }
}
