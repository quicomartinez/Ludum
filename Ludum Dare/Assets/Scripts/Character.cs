using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Controller controller;
    private Animator animator;
    private CharStats charStats;

    [SerializeField]
    private float moveSpeed = 5f;

    private void Awake()
    {
        controller = GetComponent<Controller>();
        animator = GetComponent<Animator>();
        charStats = new CharStats();    
    }

    private void Update()
    {
        Movement();
        //Interaction();
    }

    private void Movement()
    {
        Vector2 direction = controller.GetDirection();

        if (direction.magnitude > 0.2f)
        {
            transform.position += (Vector3)direction * Time.deltaTime * moveSpeed;
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (controller.interactPressed)
        {
            String name = other.gameObject.name;
            UnityEngine.Debug.Log(name);
            Interaction(name);
        }
    }
    private void Interaction(String name)
    {
        switch (name)
        {
            case "mop":
                charStats.ChangeMop();
                break;
            case "cousin":
                charStats.ChangeCousin();
                break;
            case "drink":
                charStats.ChangeDrink();
                break;
            case "sixPack":
                charStats.ChangeSixPack();
                break;
            case "danceFloor":
                charStats.ChangeDanceFloor();
                break;
        }
    }

}
