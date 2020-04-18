using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    private float xCoordinate;
    private float yCoordinate;

    private void Start()
    {
        //GetComponent<HandlePeople>().AddNPC(this.gameObject);

        xCoordinate = Random.Range(-2f, 5.8f);
        yCoordinate = Random.Range(-2f, 3f);

        Vector3 destination = new Vector3(xCoordinate, yCoordinate, 0);
        GetComponent<NavMeshAgent2D>().destination = destination;

    }

}
