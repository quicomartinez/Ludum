using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVomitToTheParty : MonoBehaviour
{

    [SerializeField]
    private GameObject vomit;

    private void Start()
    {
        InvokeRepeating("NewVomitComing", 8.0f, 6f);
    }

    private void NewVomitComing()
    {
        Instantiate(vomit, new Vector3(-5f, -3.5f, 0), Quaternion.identity);
        UnityEngine.Debug.Log("V");
    }
}
