using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    private bool hasMop;
    private bool hasCousin;
    private bool hasSixPack;
    private bool hasDrink;
    private bool busy;
    
    public void Start()
    {
        hasMop = false;
        hasCousin = false;
        hasSixPack = false;
        hasDrink = false;
        busy = false;
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

    public void ChangeDanceFloor()
    { 
        if (!busy)
        {
            UnityEngine.Debug.Log("FEVER");
        }
    }

}
