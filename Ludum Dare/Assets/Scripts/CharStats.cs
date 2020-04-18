using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CharStats
{
    public bool hasMop;
    public bool hasCousin;
    public bool hasSixPack;
    public bool hasDrink;
    public bool busy;
    
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
