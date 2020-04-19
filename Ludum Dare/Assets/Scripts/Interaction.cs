using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interaction : MonoBehaviour
{
    public event Action onVomit;
    public event Action onMop2Vomit;
    public event Action onFight;
    public event Action onCousin2Fight;
    public event Action onSixPack2Fridge;
    public event Action onBeer2Dj;
    public event Action onGetMop;
    public event Action onGetSixPack;
    public event Action onGetDrink;
    public event Action onGetCousin;
    public event Action onDropMop;
    public event Action onDropSixPack;
    public event Action onDropDrink;
    public event Action onDropCousin;
    public event Action onFever;


    public CharStats charStats;
    public Cousin cousin;
    [SerializeField]
    private AudioClip sfxCleaning;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip sfxPickMop;
    [SerializeField]
    private AudioClip sfxDropMop;
    [SerializeField]
    private AudioClip sfxTakeSixPack;
    [SerializeField]
    private AudioClip sfxDeliverBeer;
    [SerializeField]
    private AudioClip sfxTakeBeer;

    public void init()
    {
        charStats = new CharStats();
        Debug.Log("IMPORTANDO");
    }
    private void Start()
    {
        charStats = new CharStats();
        cousin = GameObject.Find("Cousin").GetComponent<Cousin>();
        audioSource = GetComponent<AudioSource>();

    }
    public void EnterArea(GameObject interactiveObject)
    {
        Debug.Log("SU PUTO NOMBRE" + interactiveObject);
        String name = interactiveObject.name;
        switch (name)
        {
            //case "Vomit(Clone)":
               /* Debug.Log("ENTROENVOMITO");
                if (charStats.hasMop)
                {
                    audioSource.PlayOneShot(sfxCleaning);
                    UnityEngine.Debug.Log("Cleaning the mess");
                    //Destroy(interactiveObject);
                    if (onMop2Vomit != null) 
                        onMop2Vomit();
                }*/
                    
                /*else
                    chanceResbalar()*/
                //break;
            /*else
                    chanceTortazo()*/

            case "wc":
                if (charStats.hasMop)
                {
                    AudioSource.PlayClipAtPoint(sfxDropMop, transform.position);
                    UnityEngine.Debug.Log("Droping Mop");
                    if (onDropMop != null)
                        onDropMop();     
                    
                }                    
                else
                {
                    if (!charStats.busy)
                    {
                        
                        AudioSource.PlayClipAtPoint(sfxPickMop, transform.position);
                        UnityEngine.Debug.Log("Picking the Mop");
                        if (onGetMop != null)
                            onGetMop();
                    }
                    else
                    {
                        //ANIM BOCADILLO OBJETO QUE YA TENGO
                        //metodo getItem de charStats
                    }
                }
                    
                charStats.ChangeMop();
                // resetMop?
                break;
            case "Cousin":

                if (!charStats.busy)
                {
                    cousin.StartFollowingPlayer();
                    charStats.ChangeCousin();
                    if (onGetCousin != null)
                        onGetCousin();
                }   
                break;
            case "fridge":
                if (charStats.hasSixPack)
                {
                    //onSixPack2Fridge();
                    AudioSource.PlayClipAtPoint(sfxDeliverBeer, transform.position);
                    UnityEngine.Debug.Log("SixPack Delivered!");                    
                    if (onSixPack2Fridge != null)
                    {
                        onSixPack2Fridge();
                        Debug.Log("ASD");
                    }
                        
                    charStats.ChangeSixPack();
                    //upgradeDrinkBar() ?
                }
                else
                {
                    if (charStats.hasDrink)
                    {
                        AudioSource.PlayClipAtPoint(sfxTakeBeer, transform.position);
                        UnityEngine.Debug.Log("Droping the Drink in the Fridge");
                        if (onDropDrink != null)
                            onDropDrink();
                    }                        
                    else
                    {
                        AudioSource.PlayClipAtPoint(sfxTakeBeer, transform.position);
                        UnityEngine.Debug.Log("Cracking a cold one");
                        if (onGetDrink != null)
                            onGetDrink();
                    }                        
                    charStats.ChangeDrink();
                }
                break;
            case "storage":
                if (charStats.hasSixPack)
                {
                    if (onDropSixPack != null)
                        onDropSixPack();
                }
                else
                {
                    if (!charStats.busy)
                    {
                        AudioSource.PlayClipAtPoint(sfxTakeSixPack, transform.position);
                        UnityEngine.Debug.Log("Picking a SixPack");
                        if (onGetSixPack != null)
                            onGetSixPack();                        
                    }
                    else
                    {
                        //BOCADILLO QUE OBJETO LLEVAS
                    }
                }
                charStats.ChangeSixPack();
                break;
            case "dj":
                if (charStats.hasDrink)
                {
                    UnityEngine.Debug.Log("Hydrating the DJ");
                    if (onBeer2Dj != null)
                        onBeer2Dj();
                    charStats.ChangeDrink();
                }
                //upgradeDjBar?
                break;
            case "danceFloor":
                // if fever?
                if (!charStats.busy)
                {
                    UnityEngine.Debug.Log("Fever!");
                    if (onFever != null)
                        onFever();
                }

                break;
        }
    }

    public void GenerateOnFight()
    {
        if (onCousin2Fight != null)
            onCousin2Fight();
    }

    public void GenerateOnVomit()
    {
        if (onMop2Vomit != null)
            onMop2Vomit();
    }
}
