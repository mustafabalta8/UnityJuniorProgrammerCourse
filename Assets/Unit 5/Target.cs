using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRg;
    [SerializeField] int minSpeed=12;
    [SerializeField] int maxSpeed=16;
    [SerializeField] int maxTorque = 10;
    [SerializeField] float ySpawnPosition = -2f;
    [SerializeField] float xSpawnRange = 4f;

    [SerializeField] int pointValue = 10;

    [SerializeField] ParticleSystem explosionParticle;
    private void Start()
    {
        targetRg = GetComponent<Rigidbody>();
        transform.position = SetRandomSpawnPosition();
        targetRg.AddForce(GenerateRandomForce(), ForceMode.Impulse);
        targetRg.AddTorque(GenerateRandomTorque(), ForceMode.Impulse);
    }
    private void OnMouseDown()
    {
        if (GameManager.instance.IsGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            GameManager.instance.UpdateScore(pointValue);

            if (gameObject.CompareTag("Enemy"))
            {
                GameManager.instance.GameOver();
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 GenerateRandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    Vector3 GenerateRandomTorque()
    {
        return new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
    }
    Vector2 SetRandomSpawnPosition()
    {
        return new Vector2(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPosition);
    }


}
