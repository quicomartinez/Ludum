using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Change the value of stats / bars.
public class StatBarManager : MonoBehaviour
{
    public void PeriodicallyChangeStatBar(StatBar statBar, float time, float quantity)
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

}


    