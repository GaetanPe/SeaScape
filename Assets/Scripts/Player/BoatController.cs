using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;

public class BoatController : MonoBehaviour
{
    [Header("\t--- Character General Attributes")]
    public Transform motor;
    private Transform cameraTransform;
    protected Rigidbody boatRigidbody;
    protected Quaternion quarternionStartRotation;

    [Header("\t--- Camera")]
    public float turnSmoothTime;
    float turnSmoothVelocity;

    [Header("\t--- Speed and Power")]
    public float maxSpeed;
    public float motorPower;


    [Header("\t--- Steering")]
    public float steerPower;



    /*----------------------------------------------------------------------------------------*/
    /*                                       Functions                                        */
    /*----------------------------------------------------------------------------------------*/

    void Start()
    {
        // Initialize everything
        cameraTransform = Camera.main.transform;
        boatRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // Input
        Vector2 movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // Move the boat
        moveBoat(movementDirection);
    }


    void moveBoat(Vector2 movementDirection)
    {
        // If the boat is moving, adapt movement to camera
        if (movementDirection != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(movementDirection.x, movementDirection.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        // Moving forward
        if (Input.GetKey(KeyCode.Z))
            boatRigidbody.AddForceAtPosition(maxSpeed * transform.forward, motor.position);
        if (Input.GetKey(KeyCode.S))
            boatRigidbody.AddForceAtPosition(-maxSpeed * transform.forward, motor.position);

        // Steering and rotation
        var steer = 0;
        if (Input.GetKey(KeyCode.Q)) // Left steer
            steer = -1;
        if(Input.GetKey(KeyCode.D)) // Right steer
            steer = 1;
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.D)) // No steer if both are pressed
            steer = 0;

        motor.SetPositionAndRotation(motor.position, transform.rotation * quarternionStartRotation * Quaternion.Euler(0, 30f * steer, 0));
        boatRigidbody.AddForceAtPosition(steer * (transform.right * steerPower / 100f), motor.position);
    }
}