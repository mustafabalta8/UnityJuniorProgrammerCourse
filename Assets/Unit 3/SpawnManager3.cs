using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float repeatRate = 2f;
    [SerializeField] private float startDelay = 2f;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }
    private void SpawnObstacle()
    {
        if (PlayerController3.instance.IsGameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
        
    }


}
