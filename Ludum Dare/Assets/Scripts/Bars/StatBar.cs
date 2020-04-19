using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    private Transform bar;
    private float value;
    private Coroutine coroutine;
    private Color originalBorderColor;
    private void Awake()
    {
        bar = transform.Find("Bar");
        originalBorderColor = GetBorderColor();
    }
    private void Start()
    {
        
    }


    public void SetValue(float sizeNormalized)
    {
        //Debug.Log(sizeNormalized);
        if(sizeNormalized > 1)
        {
            sizeNormalized = 1;
        } else if (sizeNormalized < 0)
        {
            sizeNormalized = 0;
        }
        //Debug.Log("antes: " + value);
        value = sizeNormalized;
        //Debug.Log("despues: " + value);
        bar.localScale = new Vector3(sizeNormalized, 1f);
        if (value <= 0.3)
        {
            SetBorderColor(Color.red);
        }
        else if(GetBorderColor()!= originalBorderColor)
        {
            SetBorderColor(originalBorderColor);
        }

        if (value == 0)
        {
            Debug.Log("T'HAN MATAT");
        }
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

    /* Repeat ... */
    public void PeriodicallyChangeStatBar(float quantity)
    {   
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(AddValueIE( quantity, 1f));
    }
    public IEnumerator AddValueIE(float quantity, float repeatRate)
    {
        while (true)
        {
            AddValue(quantity);
            yield return new WaitForSeconds(repeatRate);
        }
    }

    public void SetBorderColor(Color color)
    {
        transform.Find("Border").GetComponent<SpriteRenderer>().color = color;
    }
    public Color GetBorderColor()
    {
        Color currentColor = transform.Find("Border").GetComponent<SpriteRenderer>().color;
        return currentColor;
    }

}




