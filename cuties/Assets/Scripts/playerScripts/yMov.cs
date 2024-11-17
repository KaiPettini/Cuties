using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class yMov : MonoBehaviour
{

    private Animator anim;
    public float move;
    public AudioClip[] steps;
    private AudioSource[] sounds;
    private AudioSource footsteps;

    private bool walking;

    public float speedIncrease = 1f;

    private startScreen running;


    private Rigidbody2D rigBody;

    
   


    // Start is called before the first frame update
    //Gets components and defines variables.
    void Start()
    {
       
       anim = GetComponent<Animator>();
       rigBody = GetComponent<Rigidbody2D>();
       sounds = GetComponents<AudioSource>();
       footsteps = sounds[1];
       running = GameObject.Find("title").GetComponent<startScreen>();

     
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       // if game is running, get inputs and set animator properties, chaging the velocity
        if(running.running)
        {

            // Get Axis from input manager
            move = Input.GetAxis("Vertical") * speedIncrease;
            anim.SetFloat("ySpeed", move);   


            

            rigBody.velocity = new Vector2(rigBody.velocity.x, move * anim.GetFloat("canControl"));


            //if game is running, set walking to true if player presses vertical, and start audio coroutine, else, set it to
            // false and stopcoroutine.
            if (Input.GetButton("Vertical"))
            {
                if (!walking)
                {
                    walking = true;
                        StartCoroutine("FootstepsAudio");
                }

            }
            else
            {
                if (walking)
                {
                    walking = false;
                    StopCoroutine("FootstepsAudio");
                }


            }


            // if player cannot control, set volume to 0, else, set it to 0.3.
            if (anim.GetFloat("canControl") == 0)
            {
                footsteps.volume = 0;

            }
            else
            {
                footsteps.volume = 0.3f;
            }
        }
        //if game is not running, stop character and volume.
        if (!running.running){

            footsteps.volume = 0f;
            move = 0;
            rigBody.velocity = new Vector2(move * anim.GetFloat("canControl"), 
            rigBody.velocity.y);
        }
            

        


        

    }
    //footsteps audio coroutine, defined by radomly playing a sound when player walks.
    IEnumerator FootstepsAudio()
    {
       
            for ( ; ; )
            
            { 
                if(!footsteps.isPlaying)
                {
                    footsteps.clip = steps[UnityEngine.Random.Range(0, steps.Length)];
                    footsteps.Play();
                }

                yield return new WaitForSeconds(0.1f);

            }
        
        
        
    }

   




    
}
