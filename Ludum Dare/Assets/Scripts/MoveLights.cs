using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLights : MonoBehaviour
{
    private float xCoordinate;
    private float yCoordinate;

    private float speed = 1.0f;

    private bool lights1 = true;
    private bool lights2 = false;

    Vector2 destination1;
    Vector2 destination2;

    private void Start()
    {
        destination1 = CalculateRandomPlace();
        destination2 = CalculateRandomPlace();
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;


        if (lights1 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination1, step);
        }

        if (Vector2.Distance(transform.position, destination1) < 0.2f)
        {
            lights1 = false;
            lights2 = true;
            destination2 = CalculateRandomPlace();
        }

        if (lights2 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination2, step);
        }

        if (Vector2.Distance(transform.position, destination2) < 0.2f)
        {
            lights1 = true;
            lights2 = false;
            destination1 = CalculateRandomPlace();
        }
    }

    private Vector2 CalculateRandomPlace()
    {
        float xCoordinate = Random.Range(-4.5f, 4f);
        float yCoordinate = Random.Range(-1.3f, 2);
        return new Vector2(xCoordinate, yCoordinate);
    }

}
