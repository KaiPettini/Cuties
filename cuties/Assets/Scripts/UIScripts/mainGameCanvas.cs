using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathCanvas : MonoBehaviour

{

    private startScreen running;
    private CanvasGroup canvas;

    private Animator anim;
    // Start is called before the first frame update
    //Gets components and defines variables.
    void Start()
    {

        canvas = GetComponent<CanvasGroup>();
        running = GameObject.Find("title").GetComponent<startScreen>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //IKf the game is running, start fadeIn animation.

        if (running.running)
        {

            anim.SetBool("fadeIn", true);

        }
        // if not running, start fade out animation.
        else if (!running.running && canvas.alpha == 1)
        {

            anim.SetBool("fadeOut", true);


        }

        
    }
}
