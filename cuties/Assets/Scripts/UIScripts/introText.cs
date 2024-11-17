using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class introText : MonoBehaviour
{

    public TMP_Text[] texts;
    private int textToShow = 1;
    private int thisText = 0;

    private CanvasGroup canvasGroup;

    private startScreen running;

    private GameObject player;

    private GameObject introPlayer;

    private GameObject playerSpawn;

    private playButton canInteract;
    
    // Start is called before the first frame update
    void Start()
    {

        canvasGroup = GetComponent<CanvasGroup>();
        running = GameObject.Find("title").GetComponent<startScreen>();
        player = GameObject.Find("player");
        introPlayer = GameObject.Find("introPlayer");
        playerSpawn = GameObject.Find("playerSpawn");
        canInteract = GameObject.Find("startButton").GetComponent<playButton>();
        
    }

    // Update is called once per frame
    void Update()
    {

        try{

            if(Input.GetKeyDown(KeyCode.Z) && !running.running && canInteract.canInteract)
        {
            texts[thisText].alpha = 0;
            texts[textToShow].alpha = 1;  
            thisText++;
            textToShow++;

        }

        }catch(IndexOutOfRangeException){

            canvasGroup.alpha = 0;
            running.running = true;

            Destroy(introPlayer);

            Vector3 playerPos = player.transform.position;
            playerPos.x = playerSpawn.transform.position.x;
            playerPos.y = playerSpawn.transform.position.y;
            playerPos.z = player.transform.position.z;

            player.transform.position = playerPos;

            Destroy(playerSpawn);
            
        }
        
        
        

        
    }
}
