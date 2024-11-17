using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playButton : MonoBehaviour
{

    private Button pressPlay;
    private startScreen running;

    private Animator introAnim;

    private Animator canvasAnim;
  

    private AudioSource click;

    private Image image;

    private Animator introPlayerAnim;

    private Animator tutorialCharAnim;

    public bool canInteract;

    

    // Start is called before the first frame update
    // Gets components and define variables.
    void Awake()
    {

        pressPlay = GetComponent<Button>();
        pressPlay.onClick.AddListener(clickSound);
        pressPlay.onClick.AddListener(GameRunning);
        running = GameObject.Find("title").GetComponent<startScreen>();
        canvasAnim = GameObject.Find("startScreenCanvas").GetComponent<Animator>();
        click = GetComponent<AudioSource>();
        image = GetComponent<Image>();
        introAnim = GameObject.Find("gameIntro").GetComponent<Animator>();
        introPlayerAnim = GameObject.Find("introPlayer").GetComponent<Animator>();
        tutorialCharAnim = GameObject.Find("tutorialChar").GetComponent<Animator>();


        

    }

    

    //Game running class, defined by set the game to running, and setting animator components.
    void GameRunning()
    {

        
        canvasAnim.SetBool("animBegin", true);
        canvasAnim.SetBool("playPressed", true);
        introPlayerAnim.SetBool("introBegin", true);
        tutorialCharAnim.SetBool("introBegin", true);
        StartCoroutine("ShowText");

        
        
        
    }

    //click Sound button, defined by playing a sound if the game is not playing, as well as making the button 
    // darker.

    public void clickSound()
    {
        if (!running.running)
        {
            click.Play();
        }
        
        UnityEngine.Vector4 imageColors = image.color;
            imageColors.w = 1f; 
            imageColors.x = 0.8f;
            imageColors.y = 0.8f;
            imageColors.z = 0.8f;
        

            image.color = imageColors;


    }

    IEnumerator ShowText()
    {

        yield return new WaitForSeconds(3.2f);

        introAnim.SetBool("introBegin", true);
        StartCoroutine("Interactable");


    }

    IEnumerator Interactable()
    {

        yield return new WaitForSeconds(1.4f);
        canInteract = true;



    }
}
