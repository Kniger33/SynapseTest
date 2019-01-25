using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSwipes : MonoBehaviour
{
    private PictureControl pc;

    void Start()
    {
        pc = GameObject.Find("Main Image").GetComponent<PictureControl>();        
    }

    public void ResetAllSwipes()
    {
        pc.CountOfToLeft = 0;
        pc.CountOfToRight = 0;
        pc.toLeftText.text = "0";
        pc.toRightText.text = "0";
    }
}
