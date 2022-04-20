using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft3 : MonoBehaviour
{
    [SerializeField] private float speed = 15f;

    private void Update()
    {
        if(PlayerController3.Instance.IsGameOver==false)
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (gameObject.tag == "Obstacle" && transform.position.x < -15)
            Destroy(gameObject);
    }
}
