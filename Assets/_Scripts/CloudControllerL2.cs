//GameController.cs, John Knoop, 300835103, 10/19/2019, v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class CloudControllerL2 : MonoBehaviour
{
    [Header("Speed Values")]
    [SerializeField]
    public Speed horizontalSpeedRange;

    [SerializeField]
    public Speed verticalSpeedRange;

    public float verticalSpeed;
    public float horizontalSpeed;

    [SerializeField]
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
    /// This method moves the ocean down the screen by verticalSpeed
    /// </summary>
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, verticalSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void Reset()
    {
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);

        float randomXPosition = Random.Range(boundary.Bottom, boundary.Top);
        transform.position = new Vector2(Random.Range(boundary.Right, boundary.Right + 2.0f), randomXPosition);
    }

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
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
