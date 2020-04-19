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
    private GameObject cousin;
    public void init()
    {
        charStats = new CharStats();
    }
    private void Start()
    {
        charStats = new CharStats();
        cousin = GameObject.Find("Cousin");
    }
    public void EnterArea(GameObject interactiveObject)
    {
        String name = interactiveObject.name;
        switch (name)
        {
            case "vomit":

                if (charStats.hasMop)
                {
                    UnityEngine.Debug.Log("Cleaning the mess");
                    Destroy(interactiveObject);
                    if (onMop2Vomit != null) 
                        onMop2Vomit();
                }
                    
                /*else
                    chanceResbalar()*/
                break;
            case "fight":
                if (charStats.hasCousin)
                {
                    cousin.GetComponent<Cousin>().StopFollowingPlayer();
                    UnityEngine.Debug.Log("Solving the Fight!");
                    //solveFight()
                    if (onCousin2Fight != null)
                        onCousin2Fight();
                }
                /*else
                    chanceTortazo()*/
                break;
            case "wc":
                if (charStats.hasMop)
                {
                    UnityEngine.Debug.Log("Droping Mop");
                    if (onDropMop != null)
                        onDropMop();                    
                }                    
                else
                {
                    if (!charStats.busy)
                    {
                        UnityEngine.Debug.Log("Picking the Mop");
                        if (onGetMop != null)
                            onGetMop();
                    }
                }
                    
                charStats.ChangeMop();
                // resetMop?
                break;
            case "cousin":
                if (!charStats.busy)
                {
                    cousin.GetComponent<Cousin>().StartFollowingPlayer();
                    charStats.ChangeCousin();
                    if (onGetCousin != null)
                        onGetCousin();
                }   
                break;
            case "fridge":
                if (charStats.hasSixPack)
                {
                    //onSixPack2Fridge();
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
                        UnityEngine.Debug.Log("Droping the Drink in the Fridge");
                        if (onDropDrink != null)
                            onDropDrink();
                    }                        
                    else
                    {
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
                        UnityEngine.Debug.Log("Picking a SixPack");
                        if (onGetSixPack != null)
                            onGetSixPack();                        
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
}
