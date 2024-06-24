using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 moveDir; //vector 3 movedirection
    public float moveSpeed = 0.1f; //float for movespeed, setting it to .1
    public float moveCap = 5f; //float for movecap, setting it to 5
    public float horizontalInput; //float for horizontalINput
    public float verticalInput; //float for vertical input

    public GameObject playerOrientation; //gameobject that holds the player's direction

    public Rigidbody rb; //rigidbody variable to hold the players rigidbody
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //get the rigidbody and assign it to rb
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); //get horizontal input(A & D) and create a float from 1 to -1 based on the input
        verticalInput = Input.GetAxisRaw("Vertical"); //get vertical input (W & S) and create a float from 1 to -1 based on the input


        moveDir = playerOrientation.transform.forward * verticalInput + playerOrientation.transform.right * horizontalInput; //set the movedirection to the forward direction of playerOrientation times by the vertical input float, and add that to the right direction of the playerOrientation times by the horizontal input float
    }

    void FixedUpdate() //runs once every physics update
    {
        rb.AddForce(moveDir.normalized * moveSpeed, ForceMode.VelocityChange); //add force to the rigidbody in the direction of moveDir normalized (pressing two keys on diagonal (W & D for example) wont make it go faster than just pressing W or D
        //Debug.Log(rb.velocity.sqrMagnitude); // Flag
        if(rb.velocity.magnitude > moveCap) //If the magnitude (x*x+y*z*z) is larger than moveCap
        {
            rb.velocity = rb.velocity.normalized * moveCap; //new cap for velocity (see below) old one stuck you to 8 axis for some reason, set the veloctiy to the normalized velocity times by moveCap
        }
        //rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -moveCap, moveCap), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -moveCap, moveCap));
    }
}
