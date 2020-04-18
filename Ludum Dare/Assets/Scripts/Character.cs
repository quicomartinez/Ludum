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
    private CharacterController2D characterController2D;

    [SerializeField]
    private float moveSpeed = 5f;
    Vector2 direction;
    private bool canInteract;

    string interactiveObjectsName;

    private void Awake()
    {
        controller = GetComponent<Controller>();
        animator = GetComponent<Animator>();
        charStats = new CharStats();
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
            Interaction(interactiveObjectsName);
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }

    private void Interaction(String name)
    {
        switch (name)
        {
            case "vomit":
                /*
                if (charStats.hasMop)
                  cleanVomit()
                  upgradeCleanBar() ?
                else
                    chanceResbalar()*/
                break;
            case "fight":
                /*
                 * if (charStats.hasCousin)
                 *  solveFight()
                 *  upgradeCopsBar() ?
                 * else
                 *  chanceTortazo()
                 */
                break;
            case "wc":
                charStats.ChangeMop();
                // resetMop?
                break;
            case "cousin":
                charStats.ChangeCousin();
                break;
            case "fridge":
                if (charStats.hasSixPack)
                {

                    UnityEngine.Debug.Log("UPGRADE Drink");
                    charStats.ChangeSixPack();
                    //upgradeDrinkBar() ?
                }
                else
                {
                    charStats.ChangeDrink();
                    
                }
                break;
            case "storage":
                charStats.ChangeSixPack();
                break;
            case "dj":
                if (charStats.hasDrink)
                {
                    charStats.ChangeDrink();
                    UnityEngine.Debug.Log("UPGRADE DJ");
                }
                    //upgradeDjBar?
                break;
            case "danceFloor":
                // if fever?
                charStats.ChangeDanceFloor();
                break;
        }
    }

}
