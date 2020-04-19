using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBarController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] public GameObject handlerObject;

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
    Interaction interaction;
    FightHandler fightHandler;

    // Getting HandlePeople component to access the list of NPCs
    [HideInInspector] public HandlePeople handlePeople;
    float amountOfNPC;

    // Counters, only good vibes used from here
    GameObject countersObject;
    Counters counter;

    // Show select items
    GameObject selectedItemObject;
    SpriteRenderer itemSprite;
    GameObject emptyInventoryObject;
    SpriteRenderer emptyInventory;

    void Start()
    {
        // Subscriptions

        interaction = player.GetComponent<Interaction>();
        interaction.onVomit += triggeredVomit;
        interaction.onMop2Vomit += triggeredMop2Vomit;
        interaction.onCousin2Fight += triggeredCousin2Fight;
        interaction.onSixPack2Fridge += triggeredSixPack2Fridge;
        interaction.onBeer2Dj += triggeredBeer2Dj;
        /*public event Action onVomit;
        public event Action onMop2Vomit;
        public event Action onFight;
        public event Action onCousin2Fight;
        public event Action onSixPack2Fridge;
        public event Action onBeer2Dj;*/
        interaction.onGetMop += triggeredGetMop;
        interaction.onGetSixPack += triggeredGetSixPack;
        interaction.onGetDrink += triggeredGetDrink;
        interaction.onGetCousin += triggeredGetCousin;
        interaction.onDropMop += triggeredDropMop;
        interaction.onDropSixPack += triggeredDropSixPack;
        interaction.onDropDrink += triggeredDropDrink;
        interaction.onDropCousin += triggeredDropCousin;
        interaction.onFever += triggeredFever;


        fightHandler = handlerObject.GetComponent<FightHandler>();
        fightHandler.onNewFight += triggeredFight;

        // handlePeople = handlerObject.GetComponent<HandlePeople>();

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
        statBarManager.PeriodicallyChangeStatBarDependingOnPeople(statBarBooze, -0.003f);
        statBarManager.PeriodicallyChangeStatBarDependingOnFights(statBarSafety, -0.01f);
        
    }


    void Update()
    {

    }


    // subscription to methods
    void triggeredVomit()
    {
        pukeNumber++;
        Debug.Log("ALGUIEN HA VOMITADO EN TU FIESTA");
        statBarManager.PeriodicallyChangeStatBar(statBarCleanness, -0.01f* pukeNumber);
    }
    void triggeredMop2Vomit()
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
    void triggeredFight()
    {
        fightNumber++;
        Debug.Log("FIGHT HAPPENED, CURRENT FIGHTS: " + fightNumber);
    }
    void triggeredCousin2Fight()
    {
        fightNumber--;
        counter.AddOneVibe();
        Debug.Log("onCousin2Fight");
        //if (fightNumber == 0)
        //{
        //    statBarManager.PeriodicallyChangeStatBar(statBarSafety, +0.01f);
        //}
        //else
        //{
        //    statBarManager.PeriodicallyChangeStatBar(statBarSafety, -0.01f * fightNumber);
        //}
        clearSelectedItem("Cousin");

    }
    void triggeredSixPack2Fridge()
    {
        float sixPackValue = 0.3f;
        counter.AddOneVibe();
        statBarManager.AddValue(statBarBooze, sixPackValue);
        Debug.Log("onSixPack2Fridge");

        clearSelectedItem("SixPack");
    }
    void triggeredBeer2Dj()
    {
        float beerValue = 0.3f;
        counter.AddOneVibe();
        statBarManager.AddValue(statBarDjFokus, beerValue);
        Debug.Log("onBeer2Dj");

        clearSelectedItem("Beer");
    }

    void triggeredGetMop()
    {
        Debug.Log("ON");
        SelectItem("Mop");
    }

    void triggeredGetSixPack()
    {
        SelectItem("SixPack");
    }

    void triggeredGetDrink()
    {
        SelectItem("Beer");
    }

    void triggeredGetCousin()
    {
        SelectItem("Cousin");
    }

    void triggeredDropMop()
    {
        clearSelectedItem("Mop");
        Debug.Log("OFF");

    }

    void triggeredDropSixPack()
    {
        clearSelectedItem("SixPack");
    }

    void triggeredDropDrink()
    {
        clearSelectedItem("Beer");
    }

    void triggeredDropCousin()
    {
        clearSelectedItem("Cousin");
    }

    void triggeredFever()
    {

    }

    void SelectItem(string itemToSelect)
    {
        string emptyInventoryRoute = "Inventory/ItemSelected/NoItem";
        emptyInventoryObject = transform.Find(emptyInventoryRoute).gameObject;
        emptyInventory = emptyInventoryObject.GetComponent<SpriteRenderer>();
        emptyInventory.enabled = false;

        string itemRoute = "Inventory/ItemSelected/" + itemToSelect;
        selectedItemObject = transform.Find(itemRoute).gameObject;
        itemSprite = selectedItemObject.GetComponent<SpriteRenderer>();
        itemSprite.enabled = true;
    }

    void clearSelectedItem(string selectedItem)
    {
        string itemRoute = "Inventory/ItemSelected/" + selectedItem;
        selectedItemObject = transform.Find(itemRoute).gameObject;
        itemSprite = selectedItemObject.GetComponent<SpriteRenderer>();
        itemSprite.enabled = false;

        string emptyInventoryRoute = "Inventory/ItemSelected/NoItem";
        emptyInventoryObject = transform.Find(emptyInventoryRoute).gameObject;
        emptyInventory = emptyInventoryObject.GetComponent<SpriteRenderer>();
        emptyInventory.enabled = true;
    }

    public int GetFightNumber()
    {
        return fightNumber;
    }

    public int GetPukeNumber()
    {
        return pukeNumber;
    }
}
