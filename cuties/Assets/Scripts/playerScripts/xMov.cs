using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xMov : MonoBehaviour
{

    private Animator anim;
    public float move;

    public float speedIncrease = 1;

    private Rigidbody2D rigBody;
    private AudioSource[] sounds;
    private AudioSource footsteps;

    public AudioClip[] steps;

    private bool facingRight = false;

    private bool walking = false;

    private startScreen running;


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

       
        
        // if game is running, get move input properties, which sets the xspeed to the move, updating the velocity.
        if(running.running)
        {
            move = Input.GetAxis("Horizontal") * speedIncrease;
            anim.SetFloat("xSpeed", move);
            

            rigBody.velocity = new Vector2(move * anim.GetFloat("canControl"), 
            rigBody.velocity.y);

            //flip facing call, which will flip the character depending on move characteristics.
            if (move > 0 && facingRight && anim.GetFloat("canControl") > 0)
                FlipFacing();
            
            else if (move < 0 && !facingRight && anim.GetFloat("canControl") > 0)
                FlipFacing();

            // if player is not walking, set walking to true and start audio coroutine, else, set walking to false.
            if (Input.GetButton("Horizontal"))
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

            // if player cannot control, footsteps volume = 0, else, set volume to 0.3
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
            rigBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else {

            rigBody.constraints = RigidbodyConstraints2D.None;
            rigBody.constraints = RigidbodyConstraints2D.FreezeRotation;

           

        }

        
        
        


        
    }

    //flip facing class, defined by changing the xscale to -1.
    void FlipFacing(){

        Vector3 charScale = transform.localScale;
        charScale.x *= -1.0f;
        transform.localScale = charScale;

        facingRight = !facingRight;

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
