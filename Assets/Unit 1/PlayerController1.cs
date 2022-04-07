using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    //[SerializeField] private float speed;
    [SerializeField] private float horsePower;
    [SerializeField] private float turnSpeed;
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] Transform centerOfMass;
    Rigidbody playerRb;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb.centerOfMass = centerOfMass.position;
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
    }
}
