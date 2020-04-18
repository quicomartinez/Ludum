using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPeopleToTheParty : MonoBehaviour
{
    [SerializeField]
    private GameObject people;

    private void Start()
    {
        InvokeRepeating("NewPeopleComing", 2.0f, 1.5f);
    }

    private void NewPeopleComing()
    {
        Instantiate(people, new Vector3(-5f, -3.5f, 0), Quaternion.identity);
        Debug.Log("A");
    }
}
