using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public float resoX,resoY;
    private CanvasScaler can;

    void Start()
    {
        can = GetComponent<CanvasScaler>();
        SetInfo();
    }

    public void SetInfo()
    {
        resoX = (float)Screen.currentResolution.width;
        resoY = (float)Screen.currentResolution.height;

        can.referenceResolution = new Vector2(resoX, resoY);

    }


   
}
