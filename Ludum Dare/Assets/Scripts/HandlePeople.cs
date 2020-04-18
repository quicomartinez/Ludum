using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePeople : MonoBehaviour
{
    private List<GameObject> npcList = new List<GameObject>();

    private void Start()
    {
        npcList.Add(GameObject.Find("Player"));

    }

    public void AddNPC(GameObject npc)
    {
        npcList.Add(npc);
    }

    //Esta fallando
    public GameObject GetRandomNpc()
    {
        return npcList[0];
    }

    private void Update()
    {

    }
}
