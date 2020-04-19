using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBarController : MonoBehaviour
{
    public GameObject player;
    public GameObject statBarManagerObject;
    public GameObject peopleHandlerObject;
    StatBarManager statBarManager;

    [SerializeField] private StatBar statBarSafety;
    [SerializeField] private StatBar statBarBooze;
    [SerializeField] private StatBar statBarCleanness;
    [SerializeField] private StatBar statBarDjFokus;

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
    List<GameObject> npcList;
    float amountOfNPC;

    void Start()
    {
        character = player.GetComponent<Character>();
        interaction = character.GetInteraction();
        interaction.onVomit += Vomit;
        interaction.onMop2Vomit += Mop2Vomit;
        interaction.onFight += Fight;
        interaction.onCousin2Fight += Cousin2Fight;
        interaction.onSixPack2Fridge += SixPack2Fridge;
        interaction.onBeer2Dj += Beer2Dj;

        // Not needed after implementing a method to get beer from the fridge that raises an event if fridge is empty
        handlePeople = peopleHandlerObject.GetComponent<HandlePeople>();
        npcList = handlePeople.GetNPCList();
        amountOfNPC = (float)npcList.Count;

        // Bars
        statBarManager = statBarManagerObject.GetComponent<StatBarManager>();

        statBarManager.InitializeStatBar(statBarSafety, statSafety);
        statBarManager.InitializeStatBar(statBarBooze, statBooze);
        statBarManager.InitializeStatBar(statBarCleanness, statCleanness);
        statBarManager.InitializeStatBar(statBarDjFokus, statDjFokus);

        // Automatically starting to decrease
        statBarManager.PeriodicallyChangeStatBar(statBarDjFokus, -0.02f);

        // Not needed after implementing a method to get beer from the fridge that raises an event if fridge is empty
        statBarManager.PeriodicallyChangeStatBar(statBarBooze, -0.01f* amountOfNPC);

    }

    // Update is called once per frame
    void Update()
    {
        //amountOfNPC = (float)npcList.Count;
        //Debug.Log("npcs: " + amountOfNPC);
        //statBarManager.PeriodicallyChangeStatBar(statBarBooze, -0.001f * amountOfNPC);

        // statBarManager.PeriodicallyChangeStatBar(statBarSafety, 1f, -0.1f);
        //if (Input.GetKeyDown(KeyCode.Space))
        //    addNewPuke();

        // Safety

        // Booze

        // Cleanness


        //if (pukeNumber > 3)
        //{
        //    pukeNumber = 0;
        //    statBarManager.StopCoroutine("AddValueIE");
        //  //  statBarManager.AddValue(statBarCleanness, -0.1f);
        //}

        // DJ Fokus


    }

    // addnewpuke -> está suscrito al eveto generadoPuke del propio Puke que está existiendo en el juego
    //void addNewPuke()
    //{
    //    pukeNumber++;
    //}

    //void onePukeWasCleaned()
    //{
    //    pukeNumber--;
    //    statBarManager.PeriodicallyChangeStatBar(statBarCleanness, -0.01f);
    //}

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
        fightNumber++;
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
        statBarManager.AddValue(statBarBooze, sixPackValue);
        Debug.Log("onSixPack2Fridge");

    }
    void Beer2Dj()
    {
        float beerValue = 0.3f;
        statBarManager.AddValue(statBarDjFokus, beerValue);
        Debug.Log("onBeer2Dj");

    }
}
