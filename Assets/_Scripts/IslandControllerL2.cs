//GameController.cs, John Knoop, 300835103, 10/19/2019, v1.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class IslandControllerL2 : MonoBehaviour
{
    public float horizontalSpeed = 0.05f;


    public Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// This method moves the island across the screen by horizontalSpeed
    /// </summary>
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void Reset()
    {
        float randomYPosition = Random.Range(boundary.Bottom, boundary.Top);
        transform.position = new Vector2(boundary.Right, randomYPosition);
    }

    /// <summary>
    /// This method checks if the ocean reaches the left boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {
        if (transform.position.x <= boundary.Left)
        {
            Reset();
        }
    }
}
