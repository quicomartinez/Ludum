﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    private Transform bar;

    private void Start()
    {
        // bla
        bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized)
    {

        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
