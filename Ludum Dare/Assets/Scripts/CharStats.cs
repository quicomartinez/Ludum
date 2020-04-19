using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Policy;
using UnityEngine;

public class CharStats
{
    public bool hasMop;
    public bool hasCousin;
    public bool hasSixPack;
    public bool hasDrink;
    public bool busy;

    private String aniMop = "thinkingMop";
    private String aniBeer = "thinkingBeer";
    private String ani6Pack= "thinking6Pack";
    private String aniCousin = "thinkingCousin";
    public String getItem()
    {
        if (hasMop)
            return aniMop;
        if (hasDrink)
            return aniBeer;
        if (hasSixPack)
            return ani6Pack;
        if (hasCousin)
            return aniCousin;
        return "";
    }

    public void RaiseBusy()
    {
        UnityEngine.Debug.Log("U R Busy");
    }

    public bool ObjAction(bool hasObj)
    {
        if (this.busy)
        {
            if (hasObj)
            {
                this.busy = false;
                return false;
            }
            else
            {
                RaiseBusy();
                return hasObj;
            }               
            
        }
        else
        {
            this.busy = true;
            return true;
        }
    }
    public void ChangeMop()
    {
        hasMop = ObjAction(hasMop);
    }

    public void ChangeCousin()
    {
        hasCousin = ObjAction(hasCousin);
    }

    public void ChangeSixPack()
    {
        hasSixPack = ObjAction(hasSixPack);
    }

    public void ChangeDrink()
    {
        hasDrink = ObjAction(hasDrink);
    }


}
