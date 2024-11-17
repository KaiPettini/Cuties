using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class level4intro : MonoBehaviour
{

    private CanvasGroup canvasGroup;
    private Animator anim;

    public TMP_Text[] texts;
    private int textToShow = 1;

    private startScreen running;
    private int thisText = 0;

    public bool intro4ended = false;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        anim = GetComponent<Animator>();
        running = GameObject.Find("title").GetComponent<startScreen>();
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "level4")
        {
            StartCoroutine("intro4chars");
            

        }
        
    }

    IEnumerator intro4chars()
    {

        yield return new WaitForSeconds(3f);
        anim.SetBool("introBegin", true);
        
        StartCoroutine("level4text");

       
            


    }

    IEnumerator level4text()
    {
        
        yield return new WaitForSeconds(1f);

         try{

            if(Input.GetKeyDown(KeyCode.Z))
        {
            texts[thisText].alpha = 0;
            texts[textToShow].alpha = 1;  
            thisText++;
            textToShow++;

        }

        }catch(IndexOutOfRangeException){

            canvasGroup.alpha = 0;
            intro4ended = true;

        

    }
}
}
