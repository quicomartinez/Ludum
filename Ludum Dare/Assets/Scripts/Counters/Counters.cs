using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counters : MonoBehaviour
{
    public int partyDuration;
    private GameObject timeCounterObject;
    private TextMesh timeCounterText;

    public float goodVibesCounter;
    private GameObject goodVibesCounterObject;
    private TextMesh goodVibesCounterText;

    // Start is called before the first frame update
    void Start()
    {
        //barController = transform.parent.parent.gameObject;
        timeCounterObject = transform.Find("TimeCounter/Time").gameObject;
        timeCounterText = timeCounterObject.GetComponent<TextMesh>();

        goodVibesCounterObject = transform.Find("GoodVibesCounter/GoodVibes").gameObject;
        goodVibesCounterText = goodVibesCounterObject.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        goodVibesCounterText.text = goodVibesCounter.ToString();
        UpdatePartyDuration();
        timeCounterText.text = partyDuration.ToString();
    }

    public void AddOneVibe()
    {
        goodVibesCounter++;
    }

    public float GetVibesCounter()
    {
        return goodVibesCounter;
    }

    private void UpdatePartyDuration()
    {
        partyDuration = (int)Time.timeSinceLevelLoad;
    }
}
