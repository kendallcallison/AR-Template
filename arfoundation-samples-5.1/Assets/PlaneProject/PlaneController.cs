using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float rotationSpeed = 50f;
    public float maxRotationSpeed = 100f;
    public float rotationAcceleration = 20f;
    public float pitchSpeed = 50f;
    public float maxPitchAngle = 60f;

    public HoldButton right;
    public HoldButton left;
    public HoldButton up;
    public HoldButton down;

    public float pitch = 0f;

    private Rigidbody rigid;

    private void Start()
    {
        // Get the Rigidbody component attached to the airplane
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Move the airplane forward constantly
        rigid.velocity = transform.forward * forwardSpeed * -1;

        rigid.AddForce(transform.forward * (pitch * -1f));

        // Rotate the airplane based on button inputs
        RotateAirplane();

        // Pitch the airplane based on button inputs
        PitchAirplane();
    }

    // Rotate the airplane based on button inputs
    private void RotateAirplane()
    {
        // Rotate right
        if (right.IsButtonHeld())
        {
            rotationSpeed += rotationAcceleration * Time.deltaTime;
            rotationSpeed = Mathf.Clamp(rotationSpeed, 0, maxRotationSpeed);
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        // Rotate left
        else if (left.IsButtonHeld())
        {
            rotationSpeed += rotationAcceleration * Time.deltaTime;
            rotationSpeed = Mathf.Clamp(rotationSpeed, 0, maxRotationSpeed);
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else
        {
            rotationSpeed = 0f;
        }
    }

    // Pitch the airplane based on button inputs
    private void PitchAirplane()
    {
        // Pitch up
        if (up.IsButtonHeld())
        {
            if (pitch < 90f)
            {
                pitch += .5f;
                transform.eulerAngles = new Vector3(pitch, transform.eulerAngles.y, transform.eulerAngles.z);
            }

        }
        // Pitch down
        else if (down.IsButtonHeld())
        {
            if (pitch > -90)
            {
                pitch -= .5f;
                transform.eulerAngles = new Vector3(pitch, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
    }
}
