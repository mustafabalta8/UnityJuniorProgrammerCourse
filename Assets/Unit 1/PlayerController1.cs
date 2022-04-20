using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController1 : MonoBehaviour
{
    //[SerializeField] private float speed;
    [SerializeField] private float horsePower;
    [SerializeField] private float turnSpeed;
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] Transform centerOfMass;
    Rigidbody playerRb;

    private float speedPerHour;
    [SerializeField] private TextMeshProUGUI speedText;

    [SerializeField] private WheelCollider[] wheelsArray;
    private int wheelsOnGround;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb.centerOfMass = centerOfMass.position;
    }
    void FixedUpdate()
    {
        //if (IsOnGround())
        //{
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            //transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

            speedPerHour = (int)playerRb.velocity.magnitude * 3.6f; // 3.6 for km per hour
            speedText.SetText("Speed: " + speedPerHour + " km");
        //}
        
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in wheelsArray)
        {
            if (wheel.isGrounded)
                wheelsOnGround++;
        }
        if (wheelsOnGround == 4)
            return true;
        else
            return false;
    }
}
