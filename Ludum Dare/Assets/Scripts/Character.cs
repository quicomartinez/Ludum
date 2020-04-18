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
    private CharStats charStats = new CharStats();

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
        UnityEngine.Debug.Log(controller.interactPressed);

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
