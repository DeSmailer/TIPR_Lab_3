using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueControl : MonoBehaviour
{
    [Range(0, 1)] public float hue = 0;

    public HueValue[] hues;

    private void OnEnable()
    {
        for (int i = 0; i < hues.Length; i++)
        {
            hues[i].hue = hue;
        }
    }

    //void Update()
    //{
    //    for (int i = 0; i < hues.Length; i++)
    //    {
    //        hues[i].hue = hue;
    //    }
    //}
}
