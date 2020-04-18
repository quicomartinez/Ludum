using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{
    private Animator animator;


    private float blendNumber = 0;

    static float t = 0.0f;
    private float minimum;
    private float maximum;

    private void Awake()
    {   
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        minimum = Random.Range(0, 1f);
        maximum = Random.Range(0, 1f);
    }

    private void Update()
    {
        animator.SetFloat("Blend", blendNumber);

        blendNumber = Mathf.Lerp(minimum, maximum, t);
        t += 0.01f * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = Random.Range(0, 1f);
            minimum = temp;
            t = 0.0f;
        }
    }


}
