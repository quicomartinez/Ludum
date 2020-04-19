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


    public GameObject GetRandomNpc()
    {
        int index = Random.Range(0, npcList.Count);
        Debug.Log(index);
        return npcList[index];
    }

    //Returns List with the NPC in game
    public List<GameObject> GetNPCList()
    {
        return npcList;
    }

    //Returns int with number of NPC in game
    public int GetNPCListCounter()
    {
        return npcList.Count;
    }
}
