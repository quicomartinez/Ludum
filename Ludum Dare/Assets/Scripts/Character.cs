using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;
using static Interaction;

public class Character : MonoBehaviour
{

    private Controller controller;
    private Animator animator;
    private Interaction interaction;
    private CharacterController2D characterController2D;

    [SerializeField]
    private float moveSpeed = 5f;
    Vector2 direction;
    private bool canInteract;

    string interactiveObjectsName;
    GameObject interactiveObject;

    private void Awake()
    {
        controller = GetComponent<Controller>();
        animator = GetComponent<Animator>();
        interaction = new Interaction();
        interaction.init();
        characterController2D = GetComponent<CharacterController2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        InteractWithItem();
    }

    private void InteractWithItem()
    {
        if (canInteract && controller.interactPressed)
        {
            UnityEngine.Debug.Log(interactiveObjectsName);
            interaction.EnterArea(interactiveObject);
        }
    }

    private void Movement()
    {
        direction = controller.GetDirection();

        if (direction.magnitude > 0.2f)
        {
            characterController2D.velocity = direction * moveSpeed;
            animator.SetBool("walking", true);
        }
        else
        {
            characterController2D.velocity = Vector2.zero;
            animator.SetBool("walking", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        canInteract = true;
        interactiveObjectsName = collision.gameObject.name;
        interactiveObject = collision.gameObject;
        if (collision.gameObject.CompareTag("People"))
        {
            moveSpeed = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;

        if (collision.gameObject.CompareTag("People"))
        {
            moveSpeed = 5f;
        }
    }

    public Interaction GetInteraction()
    {
        return interaction;
    }
}
