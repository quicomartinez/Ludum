using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Change the value of stats / bars.
public class StatBarManager : MonoBehaviour
{
    Coroutine coroutine;
    public void PeriodicallyChangeStatBar(StatBar statBar, float time, float quantity, string functionName, bool destroy)
    {
       FunctionPeriodic.Create(() =>
        {
            if (statBar.GetValue() > 0f)
                statBar.AddValue(quantity);
        }, time);

    }

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
}


    