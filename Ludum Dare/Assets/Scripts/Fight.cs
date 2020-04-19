using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    GameObject fighter1;
    GameObject fighter2;

    private void Start()
    {
        //SUMA PUNTACIÓN BATALLAS
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

        //gameObject.GetComponent<Character>().GetInteraction();


        if (collision.gameObject.name == "Player") //condicionPrimo) //FALTA CONDICIÓN DEL PRIMO)
        {
            fighter1.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            fighter2.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            Destroy(gameObject);
            //RESTA PUNTUACIÓN BATALLAS
           


        }
    }
}
