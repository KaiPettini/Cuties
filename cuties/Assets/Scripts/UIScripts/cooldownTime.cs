using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class cooldownTime : MonoBehaviour
{

    private rightClickSkill skillInfo;
    public TMP_Text skillcooldown;

    // Start is called before the first frame update
    void Start()
    {

       // skillInfo = GameObject.Find("player").GetComponent<rightClickSkill>();
        //skillcooldown = GameObject.Find("skillCooldown").GetComponent<TMPro.TMP_Text>();



        
    }

    // Update is called once per frame
    void Update()
    {

//        if(Time.time < (skillInfo.cooldown + skillInfo.timeNow))
        {


            //skillcooldown.text = "Skill cooldown: " + 
            //Math.Abs(Math.Round(Time.time - (skillInfo.cooldown + skillInfo.timeNow), 1)).ToString();


        }
     //   else
        {

           // skillcooldown.text = "Skill cooldown: 0"; 

        }
        
    }
}
