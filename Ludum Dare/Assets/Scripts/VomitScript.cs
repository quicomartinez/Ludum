using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && gameObject.GetComponent<Interaction>().charStats.hasMop)
        {
            Destroy(gameObject);
            //RESTA PUNTUACIÓN BATALLAS
        }
    }
}
