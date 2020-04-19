using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBarController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject peopleHandlerObject;

    private GameObject statBarManagerObject;
    StatBarManager statBarManager;

    //[SerializeField]
    // StatBars
    GameObject safetyBarObject;
    private StatBar statBarSafety;
    GameObject boozeBarObject;
    private StatBar statBarBooze;
    GameObject cleannessBarObject;
    private StatBar statBarCleanness;
    GameObject djFokusBarObject;
    private StatBar statBarDjFokus;

    // Initial value for each bar.
    private float statSafety = 0.5f;
    private float statBooze = 0.5f;
    private float statCleanness = 0.5f;
    private float statDjFokus = 0.5f;

    // General values from the game
    private int pukeNumber = 0;
    private int fightNumber = 0;
    private int numberBeerOnFridge = 0; // max 24
    private int numberBeerHand = 0; // max 6

    // Methods subscribed
    Character character;
    Interaction interaction;

    // Getting HandlePeople component to access the list of NPCs
    HandlePeople handlePeople;
    float amountOfNPC;

    // Counters, only good vibes used from here
    GameObject countersObject;
    Counters counter;


    void Start()
    {
        // Subscriptions
   
        character = player.GetComponent<Character>();
        interaction = character.GetInteraction();
        interaction.onVomit += Vomit;
        interaction.onMop2Vomit += Mop2Vomit;
        interaction.onFight += Fight;
        interaction.onCousin2Fight += Cousin2Fight;
        interaction.onSixPack2Fridge += SixPack2Fridge;
        interaction.onBeer2Dj += Beer2Dj;


        // Counters
        countersObject = transform.Find("Counters").gameObject;
        counter = countersObject.GetComponent<Counters>();

        // Bar manager
        statBarManagerObject = transform.Find("StatBarManager").gameObject;
        statBarManager = statBarManagerObject.GetComponent<StatBarManager>();

        // Bar objects and statbars
        safetyBarObject = transform.Find("StatBars/Safety").gameObject;
        statBarSafety = safetyBarObject.GetComponent<StatBar>();

        boozeBarObject = transform.Find("StatBars/Booze").gameObject;
        statBarBooze = boozeBarObject.GetComponent<StatBar>();

        cleannessBarObject = transform.Find("StatBars/Cleanness").gameObject;
        statBarCleanness = cleannessBarObject.GetComponent<StatBar>();

        djFokusBarObject = transform.Find("StatBars/DJFokus").gameObject;
        statBarDjFokus = djFokusBarObject.GetComponent<StatBar>();

      
        // Initializing bars
        statBarManager.InitializeStatBar(statBarSafety, statSafety);
        statBarManager.InitializeStatBar(statBarBooze, statBooze);
        statBarManager.InitializeStatBar(statBarCleanness, statCleanness);
        statBarManager.InitializeStatBar(statBarDjFokus, statDjFokus);

        // Automatically starting to decrease
        statBarManager.PeriodicallyChangeStatBar(statBarDjFokus, -0.02f);

        // Dynamic coroutine to reduce booze bar depending of the amount of npcs
        statBarManager.PeriodicallyChangeStatBarDependingOnPeople(statBarBooze, -0.001f);

    }


    void Update()
    {

    }


    // subscription to methods
    void Vomit()
    {
        pukeNumber++;
        Debug.Log("onVomit");
        statBarManager.PeriodicallyChangeStatBar(statBarCleanness, -0.01f* pukeNumber);
    }
    void Mop2Vomit()
    {
        pukeNumber--;
        counter.AddOneVibe();
        Debug.Log("onMop2Vomit");
        if (pukeNumber == 0)
        {
            statBarManager.PeriodicallyChangeStatBar(statBarCleanness, +0.01f);
        }
        else
        {
            statBarManager.PeriodicallyChangeStatBar(statBarCleanness, -0.01f * pukeNumber);
        }

    }
    void Fight()
    {
        fightNumber++;
        Debug.Log("onFight");
        statBarManager.PeriodicallyChangeStatBar(statBarSafety, -0.01f * fightNumber);

    }
    void Cousin2Fight()
    {
        fightNumber--;
        counter.AddOneVibe();
        Debug.Log("onCousin2Fight");
        if (fightNumber == 0)
        {
            statBarManager.PeriodicallyChangeStatBar(statBarSafety, +0.01f);
        }
        else
        {
            statBarManager.PeriodicallyChangeStatBar(statBarSafety, -0.01f * fightNumber);
        }

    }
    void SixPack2Fridge()
    {
        float sixPackValue = 0.3f;
        counter.AddOneVibe();
        statBarManager.AddValue(statBarBooze, sixPackValue);
        Debug.Log("onSixPack2Fridge");

    }
    void Beer2Dj()
    {
        float beerValue = 0.3f;
        counter.AddOneVibe();
        statBarManager.AddValue(statBarDjFokus, beerValue);
        Debug.Log("onBeer2Dj");

    }
}
