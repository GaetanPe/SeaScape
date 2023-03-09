using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CannonController : MonoBehaviour
{
    #region Attributes

    [Header("\t--- Cannon stats")]
    public float rotationSpeed;
    public float blastPower;

    [Header("\t--- Cannon output")]
    public GameObject cannonBall;
    public Transform shotPoint;


    [Header("\t--- Rotation angle variables")]
    float yaw; // Y axis rotation
    float pitch; // X axis rotation

    [Header("\t--- Main Camera")]
    CameraController mainCameraController;
    Vector3 rotationSmoothVelocity;
    Vector3 currentCameraRotation;

    #endregion


    #region Start/Update/LateUpdate

    void Start()
    {
        mainCameraController = Camera.main.GetComponent<CameraController>();

    }

    void Update()
    {
        // Shooting when LeftMouse is pressed
        shoot();
    }

    void LateUpdate()
    {
        cameraCannonFollowing();
    }

    #endregion


    #region Camera Following

    void cameraCannonFollowing()
    {
        // Camera rotation angles
        yaw += Input.GetAxis("Mouse X") * mainCameraController.mouseSensivity;
        pitch -= Input.GetAxis("Mouse Y") * mainCameraController.mouseSensivity;
        pitch = Mathf.Clamp(pitch, mainCameraController.pitchMinMax.x, mainCameraController.pitchMinMax.y);

        // Stocks current camera rotation and adapt to cannon's
        currentCameraRotation = Vector3.SmoothDamp(currentCameraRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, mainCameraController.rotationSmoothTime);
        transform.eulerAngles = currentCameraRotation;
    }

    #endregion


    #region Shooting

    void shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject createdCannonball = Instantiate(cannonBall, shotPoint.position, shotPoint.rotation);
            createdCannonball.GetComponent<Rigidbody>().velocity = shotPoint.transform.up * blastPower;
        }
    }

    #endregion
}