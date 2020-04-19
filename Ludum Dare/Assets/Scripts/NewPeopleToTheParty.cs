using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPeopleToTheParty : MonoBehaviour
{
    [SerializeField]
    private GameObject people;

    [SerializeField]
    private Sprite[] animals;

    private Coroutine coroutine;
    private HandlePeople handlePeople;

    private void Awake()
    {
        handlePeople = GetComponent<HandlePeople>();
    }

    private void Start()
    {
        PeriodicallyInstantiatePeople();
    }

    public void PeriodicallyInstantiatePeople()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(InstantiatePeopleIE());
    }

    //waitTime is now a random Number; we can make it a propierty that changes with the game stats.
    public IEnumerator InstantiatePeopleIE()
    {
        while (true)
        {
            GameObject peopleToSave = Instantiate(people, new Vector3(-5f, -3.5f, 0), Quaternion.identity);
            peopleToSave.GetComponentInChildren<SpriteRenderer>().sprite = animals[Random.Range(0, animals.Length)];
            handlePeople.AddNPC(peopleToSave);
            float waitTime = Random.Range(0, 4f);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
