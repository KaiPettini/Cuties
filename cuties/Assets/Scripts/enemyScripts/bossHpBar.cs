using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossHpBar : MonoBehaviour
{

    private enemyHealthBoss bossHealth;

    private UnityEngine.UI.Image bossHp;

    private level4intro intro4;

    private startScreen running;

    private CanvasGroup canvas;

    private Animator anim;

    private bool bossDead;

    private getBossDead outro;
    // Start is called before the first frame update

    void Start()
    {
        intro4 = GameObject.Find("level4intro").GetComponent<level4intro>();
        anim = GetComponent<Animator>();
        running = GameObject.Find("title").GetComponent<startScreen>();
        canvas = GetComponent<CanvasGroup>();
        outro = GameObject.Find("Main Camera").GetComponent<getBossDead>();
        
    }

    

    // Update is called once per frame
    void Update()
    {

         if(outro.outro)
        {

            anim.SetBool("fadeOut", true);

        }
        
    
        if(SceneManager.GetActiveScene().name == "level4")
        {

            bossDead = GameObject.Find("boss").GetComponent<enemyHealthBoss>().dead;


            if(!bossDead)
            {
                bossHealth = GameObject.Find("boss").GetComponent<enemyHealthBoss>();
            bossHp = GameObject.Find("bossHp").GetComponent<UnityEngine.UI.Image>();
            

            bossHp.fillAmount = (float)bossHealth.hp/15;

            if(intro4.intro4ended)
            {

                anim.SetBool("showBar", true);

            
            }


            }
            

        
     



            
        }
        else
        {
            bossHp = GameObject.Find("bossHp").GetComponent<UnityEngine.UI.Image>();
            bossHealth = null;
            

            bossHp.fillAmount = 0;

        }

        
        


        }
        

        

        

        
    }

