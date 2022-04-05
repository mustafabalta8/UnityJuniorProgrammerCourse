using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startingPosition;
    [SerializeField] private float repeatWidth;
    private float repeatPosition;
    void Start()
    {
        startingPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        repeatPosition = startingPosition.x - repeatWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < repeatPosition)
        {
            transform.position = startingPosition;
        }
    }
}
