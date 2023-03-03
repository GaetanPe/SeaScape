using UnityEngine;
using UnityEngine.EventSystems;

public class BoatController : MonoBehaviour
{
    [Header("\t--- Character General Attributes")]
    public Transform motor;
    private Transform cameraTransform;
    protected Rigidbody boatRigidbody;

    [Header("\t--- Camera")]
    public float turnSmoothTime;
    float turnSmoothVelocity;

    [Header("\t--- Speed management")]
    public float maxSpeed;



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
        if (EventSystem.current.IsPointerOverGameObject())
            return;

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

        // Moves the boat
        boatRigidbody.AddForceAtPosition((maxSpeed * transform.forward) * movementDirection.magnitude, motor.position);
    }
}