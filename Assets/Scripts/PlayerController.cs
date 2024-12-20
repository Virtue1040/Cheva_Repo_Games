using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cameraTransform;

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 5f;
    public float lookSensitivity = 2f;
    public float cameraDistance = 5f;
    public Vector3 cameraOffset = new Vector3(0, 2, 0);

    private float cameraPitch = 0f;
    private bool isFrontLooking = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleJump();

        HandleCameraThirdPerson();
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    //private void HandleCamera()
    //{
    //    float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
    //    float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;
    //    transform.Rotate(Vector3.up * mouseX);
    //    cameraPitch -= mouseY;
    //    cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);
    //    cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    //}
    private void HandleCameraThirdPerson()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;
        transform.Rotate(Vector3.up * mouseX);
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFrontLooking = !isFrontLooking;
        }
        if (isFrontLooking)
        {
            cameraTransform.position = transform.position + transform.forward * cameraDistance + cameraOffset;
        }
        else
        {
            cameraTransform.position = transform.position - transform.forward * cameraDistance + cameraOffset;
        }
    }
}
