using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class FightHandler : MonoBehaviour
{

    private Coroutine coroutine;
    private HandlePeople handlePeople;

    public event Action onNewFight;

    [SerializeField]
    private GameObject cloudFigth;

    float time;
    bool canStart = true;

    private void Awake()
    {
        handlePeople = GetComponent<HandlePeople>();
    }

    private void Start()
    {
        time = 5.0f;

    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0 && canStart)
        {
            canStart = false;
            PeriodicallyFight();
        }

    }

    public void PeriodicallyFight()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(StartFightIE());
    }

    //waitTime is now a random Number; we can make it a propierty that changes with the game stats.
    public IEnumerator StartFightIE()
    {
        while (true)
        {
            GameObject npc1 = handlePeople.GetRandomNpc();
            GameObject npc2 = handlePeople.GetRandomNpc();
            Vector3 placeToFight = npc2.transform.position;

            GameObject thisCloudFight = Instantiate(cloudFigth, placeToFight - (0.12f * (placeToFight - npc1.transform.position)), Quaternion.identity);
            thisCloudFight.GetComponent<Fight>().AssignNpc1(npc1);
            thisCloudFight.GetComponent<Fight>().AssignNpc2(npc2);

            npc1.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            npc2.GetComponentInChildren<SpriteRenderer>().color = Color.red;

            npc1.GetComponent<AutoMove>().MoveToFight(placeToFight - (0.25f * (placeToFight - npc1.transform.position)));
            npc2.GetComponent<AutoMove>().MoveToFight(placeToFight);
            
            if (onNewFight != null)
            {
                onNewFight();
            }

            float waitTime = UnityEngine.Random.Range(10, 15f);
            yield return new WaitForSeconds(waitTime);
        }
    }

}
