using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Controller controller;
    private Animator animator;

    [SerializeField]
    private float moveSpeed = 5f;

    private void Awake()
    {
        controller = GetComponent<Controller>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
        Interaction();
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

    private void Interaction()
    {
        if (controller.interactPressed)
        {
            Debug.Log("APRETADO");
        }
    }
}
