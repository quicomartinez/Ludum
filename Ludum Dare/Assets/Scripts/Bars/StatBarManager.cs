using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Change the value of stats / bars.
public class StatBarManager : MonoBehaviour
{
    public void InitializeStatBar(StatBar sb, float value)
    {
        sb.SetValue(value);
    }

    public void AddValue(StatBar sb, float value)
    {
        sb.AddValue(value);
    }


    public void PeriodicallyChangeStatBar(StatBar sb, float quantity)
    {
        sb.PeriodicallyChangeStatBar(quantity);
    }

    public void PeriodicallyChangeStatBarDependingOnPeople(StatBar sb, float quantity)
    {
        sb.PeriodicallyChangeStatBarDependingOnPeople(quantity);
    }


    public void PeriodicallyChangeStatBarDependingOnFights(StatBar sb, float quantity)
    {
        sb.PeriodicallyChangeStatBarDependingOnFights(quantity);
    }

    //public void PeriodicallyChangeStatBarDependingOnPukes(StatBar sb, float quantity)
    //{
    //    sb.PeriodicallyChangeStatBarDependingOnPeople(quantity);
    //}

}


    