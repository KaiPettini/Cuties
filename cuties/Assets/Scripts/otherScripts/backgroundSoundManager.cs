using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class backgroundSoundManager : MonoBehaviour
{
    private startScreen running;
    private bool canPlay = true;
    private bool muted = false;

    private AudioSource[] sounds;


    
    private AudioSource backgroundMusic;

    private AudioSource bossMusic;

    private AudioSource victoryMusic;

    private getBossDead outroTime;
    // Start is called before the first frame update
    // Gets the componets and defines variables
    void Start()
    {

        sounds = GetComponents<AudioSource>();
        backgroundMusic = sounds[0];
        bossMusic = sounds[1];
        victoryMusic = sounds[2];
        running = GameObject.Find("title").GetComponent<startScreen>();
        outroTime = GetComponent<getBossDead>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(SceneManager.GetActiveScene().name == "level4" && !muted)
        {

            bossMusic.volume = 0.6f;
            backgroundMusic.volume = 0.0f;
            victoryMusic.volume = 0.13f;
            

            if(!outroTime.outro)
            {

                bossMusic.volume = 0.6f;
                if(!bossMusic.isPlaying)
                {
                    bossMusic.Play();
                }
                
                


            }
            else
            {

                bossMusic.Stop();
                if(!victoryMusic.isPlaying)
                {

                    victoryMusic.Play();

                }
            }



        }

        // If the game is running, and it is not muted, play the background music.
        if(running.running && !muted && canPlay)
        {

            backgroundMusic.volume = 0.3f;
            backgroundMusic.Play();
            canPlay = false;

        }
        // If game not running, set volume to 0.
        else if(!running.running)
        {
            backgroundMusic.volume = 0.0f;
            bossMusic.volume = 0.0f;
        }
        
        // If user clicks M, mute.
        if (Input.GetKeyDown(KeyCode.M))
        {
             mute();
        }

    
       
        


        

        
        
    }

    // Class mute, characterized by volume sets.
    void mute()
    {

        if (backgroundMusic.volume > 0 || bossMusic.volume > 0)
        {

            backgroundMusic.volume = 0;
            bossMusic.volume = 0f;
            victoryMusic.volume = 0f;
            muted = true;
        }
        else
        {
            backgroundMusic.volume = 0.3f;
            victoryMusic.volume = 0.13f;
            bossMusic.volume = 0.6f;
            muted= false;

        }

    }

   
}
