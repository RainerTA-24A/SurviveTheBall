
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10f;

    [Header("Jump")]
    public float jumpForce = 5f;
    public float jumpHoldForce = 12f;
    public float maxJumpHoldTime = 1.5f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isHoldingJump;
    private float jumpHoldTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("PlayerController requires a Rigidbody!");
        }
    }

    void Update()
    {
        // Alusta hüpet ainult maapinnal olles
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGrounded = false;
            isHoldingJump = true;
            jumpHoldTimer = 0f;
        }

        // Hoia hüppe lisajõudu aktiivsena ainult piiratud aja
        if (isHoldingJump)
        {
            if (Input.GetKey(KeyCode.Space) &&
                jumpHoldTimer < maxJumpHoldTime)
            {
                jumpHoldTimer += Time.deltaTime;
            }
            else
            {
                isHoldingJump = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        // WASD ja nooleklahvid
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(
            moveHorizontal,
            0f,
            moveVertical
        );

        rb.AddForce(movement * speed);

        // Lisajõud Space'i hoidmise ajal
        if (isHoldingJump && jumpHoldTimer < maxJumpHoldTime)
        {
            rb.AddForce(
                Vector3.up * jumpHoldForce,
                ForceMode.Acceleration
            );
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
