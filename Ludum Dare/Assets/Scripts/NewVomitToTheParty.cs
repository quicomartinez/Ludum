using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVomitToTheParty : MonoBehaviour
{
    [SerializeField]
    private GameObject vomit;

    private Coroutine coroutine;
    private HandlePeople handlePeople;

    private void Awake()
    {
        handlePeople = GetComponent<HandlePeople>();
    }

    private void Start()
    {
        PeriodicallyInstantiateVomit();
    }

    public void PeriodicallyInstantiateVomit()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(InstantiateVomitIE());
    }

    //waitTime is now a random Number; we can make it a propierty that changes with the game stats.
    public IEnumerator InstantiateVomitIE()
    {
        while (true)
        {
            GameObject npcToInstantiate = handlePeople.GetRandomNpc();
            Instantiate(vomit, npcToInstantiate.transform.position, Quaternion.identity);


            float waitTime = Random.Range(2, 4f);
            yield return new WaitForSeconds(waitTime);
        }
    }

}
