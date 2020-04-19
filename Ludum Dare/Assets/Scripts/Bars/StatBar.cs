using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    private Transform bar;
    private float value;
    private Coroutine coroutine;
    private Color originalBorderColor;
    private StatBarController barController;

    GameObject handlerObject;
    HandlePeople handlePeople;
    FightHandler fightHandler;
    float amountOfPeople;
    float amountOfFights;

    float safetyRecovery = 0.02f;

    private void Awake()
    {
        bar = transform.Find("Bar");
        originalBorderColor = GetBorderColor();
        //peopleHandlerObject = transform.parent.parent.gameObject;
        
        barController = transform.parent.parent.gameObject.GetComponent<StatBarController>();
        handlerObject = barController.handlerObject;
        handlePeople = handlerObject.GetComponent<HandlePeople>();
        //amountOfPeople = (float)handlePeople.GetNPCListCounter();
        
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

    public void PeriodicallyChangeStatBarDependingOnPeople(float quantity)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(AddValueIEDynamicPeople(quantity, 1f));
    }
    public IEnumerator AddValueIEDynamicPeople(float quantity, float repeatRate)
    {
        while (true)
        {
            amountOfPeople = (float)handlePeople.GetNPCListCounter();
            AddValue(quantity * amountOfPeople);
            
            yield return new WaitForSeconds(repeatRate);
        }
    }

    public void PeriodicallyChangeStatBarDependingOnFights(float quantity)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(AddValueIEDynamicFight(quantity, 1f));
    }
    public IEnumerator AddValueIEDynamicFight(float quantity, float repeatRate)
    {
        while (true)
        {
            amountOfFights = (float)barController.GetFightNumber();
            if (amountOfFights == 0)
            {

                AddValue(safetyRecovery);

            }
            else
            {
                AddValue(quantity * amountOfFights);
            }

            yield return new WaitForSeconds(repeatRate);
        }
    }

    //public void PeriodicallyChangeStatBarDependingOnVomits(float quantity)
    //{
    //    if (coroutine != null)
    //    {
    //        StopCoroutine(coroutine);
    //    }
    //    coroutine = StartCoroutine(AddValueIEDynamicVomits(quantity, 1f));
    //}
    //public IEnumerator AddValueIEDynamicVomits(float quantity, float repeatRate)
    //{
    //    while (true)
    //    {
    //        amountOfPeople = (float)handlePeople.GetNPCListCounter();
    //        AddValue(quantity * amountOfPeople);
    //        yield return new WaitForSeconds(repeatRate);
    //    }
    //}


}




