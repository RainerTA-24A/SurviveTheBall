using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public float jumpForce = 5f;

    //viide Rigidbody komponendile
    private Rigidbody rb;
    //Hüppamine true or false
    private bool jumpRequested = false;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        // Otsime balli küljest Rigidbody komponendi üles
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool jump = Input.GetKeyDown(KeyCode.Space);


        if (isGrounded)
        {
            if (jump)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Loeme klaviatuuri nooli või WASD klahve
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Add jump klahv
        // Teeme suunavektori (X = vasak,parem, Y = 0, Z = edasi,tagasi)
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Rakendame pallile jõudu, et see liiguks                                
        rb.AddForce(movement * speed);


    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
