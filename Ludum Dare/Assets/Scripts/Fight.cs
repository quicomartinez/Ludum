using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fight : MonoBehaviour
{
    GameObject fighter1;
    GameObject fighter2;
    public event Action onNewFight;
    private void Start()
    {
        //SUMA PUNTACIÓN BATALLAS
        if (onNewFight != null)
            onNewFight();
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
        if (collision.gameObject.name == "Player" && gameObject.GetComponent<Character>().GetInteraction().charStats.hasCousin) 
        {
            fighter1.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            fighter2.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            Destroy(gameObject);
            //RESTA PUNTUACIÓN BATALLAS
        }
    }
}
