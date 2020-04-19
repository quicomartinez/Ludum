using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fight : MonoBehaviour
{
    GameObject fighter1;
    GameObject fighter2;

    public event Action onCousin2Fight;

    private void Start()
    {

    }

    public void AssignNpc1( GameObject npcToAssign)
    {
        fighter1 = npcToAssign;
    }

    public void AssignNpc2(GameObject npcToAssign)
    {
        fighter2 = npcToAssign;
    }

    //FALTA CONDICIÓN DEL PRIMO
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.name == "Player" && collision.gameObject.GetComponent<Interaction>().charStats.hasCousin) 
        {
            Interaction interaction = collision.gameObject.GetComponent<Interaction>();

            fighter1.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            fighter2.GetComponentInChildren<SpriteRenderer>().color = Color.white;

            //RESTA PUNTUACIÓN BATALLAS
            if (interaction.charStats.hasCousin)
            {
                UnityEngine.Debug.Log("Solving the Fight!");
                interaction.cousin.StopFollowingPlayer();
                interaction.charStats.ChangeCousin();
                Destroy(gameObject);
                if (onCousin2Fight != null)
                    onCousin2Fight();


                Destroy(gameObject);
            }
        }
    }
}
