using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject powerUpIndicator;

    private Rigidbody playerRg;

    [SerializeField] private float speed;
    [SerializeField] private float powerUpStrenght=12f;
    [SerializeField] private bool hasPowerUp;

    private void Start()
    {
        playerRg = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRg.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.23f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            GetPowerUp(other);
        }
    }
    private void GetPowerUp(Collider other)
    {
        hasPowerUp = true;
        Destroy(other.gameObject);
        powerUpIndicator.SetActive(true);
        StartCoroutine(PowerUpCountDownRoutine());
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy") && hasPowerUp)
        {
            PushEnemy(collision);
        }
    }
    
    private void PushEnemy(Collision collision)
    {
        Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        //Enemy pozisyonundan player pozisyonunun farký enemy'nin gitti yönün tersini veriyor
        Vector3 directionFromPlayerToEnemy = collision.gameObject.transform.position - transform.position;//Vector3 awayFromPlayer

        enemyRigidbody.AddForce(directionFromPlayerToEnemy * powerUpStrenght, ForceMode.Impulse);
    }
}
