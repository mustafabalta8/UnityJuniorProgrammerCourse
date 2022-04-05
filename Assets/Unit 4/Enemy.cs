using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Rigidbody enemyRg;

    [SerializeField] private float speed;

    private void Start()
    {
        enemyRg = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;//enemy'dan player'a doðru olan direction'ý verir.
        enemyRg.AddForce( lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            SpawnManager4.instance.EnemyCount--;
            
        }
            
    }
}
