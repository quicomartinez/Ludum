using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cousin : MonoBehaviour
{
    private GameObject player;
    private Coroutine coroutine;
    private Vector3[] placesToMove = new Vector3[3] { new Vector3(-5, 0, 0), new Vector3(2, 3, 0), new Vector3(5, -2, 0) };

    private bool followPlayer;

    private void Start()
    {
        player = GameObject.Find("Player");
        PeriodicallyMoveCousin();
    }

    private void Update()
    {
        //solo para testear
        /*StartFollowingPlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            followPlayer = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            StopFollowingPlayer();
        }*/
    }

    public void StartFollowingPlayer()
    {
        if (followPlayer == true)
        {
            Debug.Log("AAA");
            StopCoroutine(coroutine);
            GetComponent<NavMeshAgent2D>().destination = player.transform.position;
        }
    }

    public void StopFollowingPlayer()
    {
        followPlayer = false;
        PeriodicallyMoveCousin();
    }


    public void PeriodicallyMoveCousin()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(MoveToOtherPlaceIE());
    }


    public IEnumerator MoveToOtherPlaceIE()
    {
        while (true)
        {
            Vector3 destination = placesToMove[Random.Range(0, placesToMove.Length)];
            Debug.Log(destination);
            GetComponent<NavMeshAgent2D>().destination = destination;
            float waitTime = Random.Range(4, 8f);
            yield return new WaitForSeconds(waitTime);
        }
    }

}
