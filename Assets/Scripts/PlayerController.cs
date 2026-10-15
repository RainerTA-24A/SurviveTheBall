
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    public float jumpHoldForce = 12f;
    public float maxJumpHoldTime = 1.5f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isHoldingJump;
    private float jumpHoldTimer;
    private Transform cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            isHoldingJump = true;
            jumpHoldTimer = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && isHoldingJump)
        {
            jumpHoldTimer += Time.deltaTime;

            if (jumpHoldTimer >= maxJumpHoldTime)
            {
                isHoldingJump = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
    }

    private void FixedUpdate()
    {
        if (cam == null && Camera.main != null)
        {
            cam = Camera.main.transform;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cam != null ? cam.forward : Vector3.forward;
        Vector3 right = cam != null ? cam.right : Vector3.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = (right * horizontal + forward * vertical).normalized;
        rb.AddForce(movement * speed);

        if (isHoldingJump && jumpHoldTimer < maxJumpHoldTime)
        {
            rb.AddForce(Vector3.up * jumpHoldForce);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
