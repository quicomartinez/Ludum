using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaa");
        if (collision.gameObject.name == "Player" && collision.gameObject.GetComponent<Interaction>().charStats.hasMop)
        {
            Debug.Log("bbb");
            Destroy(gameObject);
            //RESTA PUNTUACIÓN BATALLAS
        }
        
    }
}
