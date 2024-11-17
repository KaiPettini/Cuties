using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class healthBar : MonoBehaviour
{

    public Sprite[] hpBars;

    private UnityEngine.UI.Image image;
    private charHealth hp;


    // Gets components and defines variables.
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        hp = GameObject.Find("player").GetComponent<charHealth>();

    }

    // Update is called once per frame
    void Update()
    //set sprite to the sprite representing the hp amount.
    {
        if (hp.hp >= 0)
        {
            image.sprite = hpBars[hp.hp];
        }
        else
        {
            image.sprite = hpBars[0];
        }
        
        
    }
}
