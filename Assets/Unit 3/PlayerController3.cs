using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerController3 : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimator;
    private AudioSource playerAudio;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;

    [SerializeField] private float jumpForce=8f;
    [SerializeField] private float gravityModifier = 1f;
    [SerializeField] private bool isOnGround=true;
    [SerializeField] private bool isGameOver;

    public static PlayerController3 Instance { get; private set; }

    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

    private void Start()
    {
        Singelton();
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }
    private void Singelton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Jump();
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !IsGameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            IsGameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound);

        }
        
    }

    [Button]
    void ChangeGravity()
    {
        Physics.gravity = new Vector3(0,-9.81f,0);
        Physics.gravity *= gravityModifier;
    }

    

}
