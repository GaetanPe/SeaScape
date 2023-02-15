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
    protected Rigidbody boatRigidbody;
    protected Quaternion quarternionStartRotation;

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
        var forceDirection = transform.forward;
        var steer = 0;

        // Steering
        if(Input.GetKey(KeyCode.Q)) // Left steer
            steer = -1;
        if(Input.GetKey(KeyCode.D)) // Right steer
            steer = 1;
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.D)) // No steer if both are pressed
            steer = 0;

        // Rotation
        boatRigidbody.AddForceAtPosition(steer * transform.right * steerPower / 100f, motor.position);

        // Forward input
        var movingDir = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);

        if(Input.GetKey(KeyCode.Z))
            PhysicsHelper.ApplyForceToReachVelocity(boatRigidbody, movingDir * maxSpeed, motorPower, ForceMode.Acceleration);
        if(Input.GetKey(KeyCode.S))
            PhysicsHelper.ApplyForceToReachVelocity(boatRigidbody, movingDir * - maxSpeed, motorPower, ForceMode.Acceleration);

        motor.SetPositionAndRotation(motor.position, transform.rotation * quarternionStartRotation * Quaternion.Euler(0, 30f * steer, 0));

        // Is moving forward ?
        bool movingForward = Vector3.Cross(transform.forward, boatRigidbody.velocity).y < 0;

        // Move in direction
        boatRigidbody.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(boatRigidbody.velocity, ((movingForward) ? 1f : 0f) * transform.forward, Vector3.up) * boatRigidbody.drag, Vector3.up) * boatRigidbody.velocity;
    }
}