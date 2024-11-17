using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPlusIcon : MonoBehaviour
{

    private CanvasGroup canvasGroup;

    private xMov speedPlus;
    // Start is called before the first frame update
    void Start()
    {

        canvasGroup = GetComponent<CanvasGroup>();
        speedPlus = GameObject.Find("player").GetComponent<xMov>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(speedPlus.speedIncrease > 1)
        {

            canvasGroup.alpha = 1;

        }

        else
        {
            canvasGroup.alpha = 0;

        }
        
    }
}
