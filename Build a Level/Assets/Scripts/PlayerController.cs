using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform look;

   
    private Rigidbody playerRb;
    private float speed = 2f;
    //private Vector3 gravity = new Vector3(0, -1f, 0);

    // Variables related to jumping
    private float jumpForce = 5f;
    private bool isGrounded = true;

    private Animator anim;
    private string run = "Run";




    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Physics.gravity = gravity;
 
    }

    // Update is called once per frame
    void Update()
    {
        //Make the powerup follow the player around
        
        Move();
        Jump();
    }
    private void Move()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, Time.deltaTime * mouseX * 120f);

        dontLookInsideFunction();
    }

    // Code for the Jump movement
    private void Jump()
    {
        // If space key is pressde while grounded we will jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void dontLookInsideFunction()
    {

        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
        {
            Debug.Log("End of run");
            anim.SetBool(run, false);

        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("fart");
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            anim.SetBool(run, true);

        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool(run, true);
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool(run, true);
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool(run, true);
            transform.Translate(Vector3.back * Time.deltaTime * speed);

        }


    }



    // How the game knows im on the ground
    private void OnCollisionEnter(Collision collision)
    {
        // When I collide with the ground I can jump again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
