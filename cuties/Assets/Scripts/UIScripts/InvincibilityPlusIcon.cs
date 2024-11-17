using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPlusIcon : MonoBehaviour
{

    private CanvasGroup canvasGroup;

    private charHealth invincibility;
    // Start is called before the first frame update
    void Start()
    {

        canvasGroup = GetComponent<CanvasGroup>();
        invincibility = GameObject.Find("player").GetComponent<charHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(invincibility.hasInvincibilityPlus)
        {

            canvasGroup.alpha = 1;

        }

        else
        {
            canvasGroup.alpha = 0;

        }
        
    }
}
