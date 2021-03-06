﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    private Transform bar;
    private float value;

    private void Awake()
    {
        bar = transform.Find("Bar");
    }
    private void Start()
    {
        
    }

    public void SetValue(float sizeNormalized)
    {
        if(sizeNormalized > 100)
        {
            sizeNormalized = 100;
        } else if (sizeNormalized < 0)
        {
            sizeNormalized = 0;
        }
        value = sizeNormalized;
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    // This method works with float values, between 0..1
    public void AddValue(float sizeNormalized)
    {

        SetValue(value + sizeNormalized);
    }

    public float GetValue()
    {
        return value;
    }

}
