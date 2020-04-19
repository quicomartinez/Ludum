using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject bar = GameObject.Find("Bar");
        Image image = bar.GetComponent<Image>();
        image.fillAmount = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
