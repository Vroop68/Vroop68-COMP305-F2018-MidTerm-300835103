//GameController.cs, John Knoop, 300835103, 10/19/2019, v1.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanControllerL2 : MonoBehaviour
{
    public float horizontalSpeed = 0.1f;
    public float resetPosition = 4.8f;
    public float resetPoint = -4.8f;


    void Start()
    {
        //Reset();
    }

    void Update()
    {
        Move();
        CheckBounds();
    }
    //Moves the background left to right at desired speed
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    //Resets background when it reaches specified position
    void Reset()
    {
        transform.position = new Vector2(resetPosition, 0.0f);
    }

    //Checks the specified reset position against the current x value of the background
    void CheckBounds()
    {
        if (transform.position.x <= resetPoint)
        {
            Reset();
        }
    }
}
