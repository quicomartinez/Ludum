using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBarController : MonoBehaviour
{
    public GameObject objectStatBarManager;
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
    private int numberBeerOnFridge = 0; // max 24
    private int numberBeerHand = 0; // max 6

    void Start()
    {
        statBarManager = objectStatBarManager.GetComponent<StatBarManager>();

        statBarManager.InitializeStatBar(statBarSafety, statSafety);
        statBarManager.InitializeStatBar(statBarBooze, statBooze);
        statBarManager.InitializeStatBar(statBarCleanness, statCleanness);
        statBarManager.InitializeStatBar(statBarDjFokus, statDjFokus);

        // Automatically starting to decrease
        statBarManager.PeriodicallyChangeStatBar(statBarDjFokus, 1f, -0.01f);
    }

    // Update is called once per frame
    void Update()
    {
       // statBarManager.PeriodicallyChangeStatBar(statBarSafety, 1f, -0.1f);
    }

    // addnewpuke -> está suscrito al eveto generadoPuke del propio Puke que está existiendo en el juego
    void addNewPuke()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pukeNumber = pukeNumber + 1; 
            Debug.Log("New puke: " + pukeNumber);
        }
            
    }
}
