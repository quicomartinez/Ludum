using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VomitScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip sfxClean;
    [SerializeField]
    private AudioClip sfxVomit;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(sfxVomit, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player" && collision.gameObject.GetComponent<Interaction>().charStats.hasMop)
        {
            AudioSource.PlayClipAtPoint(sfxClean, transform.position);
            collision.gameObject.GetComponent<Interaction>().GenerateOnFight();
            Destroy(gameObject);
        }


            //RESTA PUNTUACIÓN BATALLAS
        
        
    }
}
