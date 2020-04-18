using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interaction
{
    public event Action onVomit;
    public event Action onMop2Vomit;
    public event Action onFight;
    public event Action onCousin2Fight;
    public event Action onSixPack2Fridge;
    public event Action onBeer2Dj;

    private CharStats charStats;
    public void init()
    {
        charStats = new CharStats();
    }
    public void EnterArea(String name)
    {
        switch (name)
        {
            case "vomit":

                if (charStats.hasMop)
                {
                    UnityEngine.Debug.Log("Cleaning the mess");
                    onMop2Vomit();
                }
                    
                /*else
                    chanceResbalar()*/
                break;
            case "fight":
                if (charStats.hasCousin)
                {
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
                    UnityEngine.Debug.Log("Droping Mop");
                else
                    UnityEngine.Debug.Log("Picking the Mop");
                charStats.ChangeMop();
                // resetMop?
                break;
            case "cousin":
                charStats.ChangeCousin();

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
                        UnityEngine.Debug.Log("Droping the Drink in the Fridge");
                    else
                        UnityEngine.Debug.Log("Cracking a cold one");
                    charStats.ChangeDrink();

                }
                break;
            case "storage":
                UnityEngine.Debug.Log("Picking a SixPack");
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
                    UnityEngine.Debug.Log("Fever!");
                break;
        }
    }
}
