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
        Plane.transform.localPosition = initialPosition;
        initialRotation.y += 180;
        Plane.transform.localRotation = initialRotation;

    }
}
