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
                    //cleanVomit()
                    onMop2Vomit();
                /*else
                    chanceResbalar()*/
                break;
            case "fight":
                if (charStats.hasCousin)
                    //solveFight()
                    onCousin2Fight();
                /*else
                    chanceTortazo()*/
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
                    //onSixPack2Fridge();
                    UnityEngine.Debug.Log("UPGRADE Drink");
                    if (onSixPack2Fridge != null)
                        onSixPack2Fridge();
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
                    if (onBeer2Dj != null)
                        onBeer2Dj();
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
