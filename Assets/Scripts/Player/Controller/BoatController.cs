using UnityEngine;
using UnityEngine.EventSystems;

public class BoatController : MonoBehaviour
{
    #region Attributes

    [Header("\t--- Character General Attributes")]
    public Transform motor;
    private Transform cameraTransform;
    protected Rigidbody boatRigidbody;
    private ParticleSystem waterParticles;

    [Header("\t--- Camera")]
    public float turnSmoothTime;
    float turnSmoothVelocity;

    [Header("\t--- Speed management")]
    public float maxSpeed;

    [Header("\t--- Particles")]
    private float particleEmission;

    #endregion


    #region Start/Update

    [System.Obsolete]
    void Start()
    {
        // Initialize everything
        cameraTransform = Camera.main.transform;
        boatRigidbody = GetComponent<Rigidbody>();

        // Initialize water particles and stops at the start
        waterParticles = GetComponentInChildren<ParticleSystem>();
        particleEmission = waterParticles.emissionRate;
    }

    [System.Obsolete]
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // Input and water particles playing if the boat is moving
        Vector2 movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // Move the boat
        moveBoat(movementDirection);
    }

    #endregion


    #region Boat Movement

    [System.Obsolete]
    void moveBoat(Vector2 movementDirection)
    {
        // If the boat is moving, adapt movement to camera + add water particles
        if(movementDirection != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(movementDirection.x, movementDirection.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);

            waterParticles.emissionRate = particleEmission;
        }
        else
            waterParticles.emissionRate = 0;

        // Moves the boat
        boatRigidbody.AddForceAtPosition((maxSpeed * transform.forward) * movementDirection.magnitude, motor.position);
    }

    #endregion
}