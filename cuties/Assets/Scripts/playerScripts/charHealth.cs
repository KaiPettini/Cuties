using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class charHealth : MonoBehaviour
{

    public int hp = 5;
    public float invTime = 1f;
    private float timeNow;
    public bool dead = false;

    private bool invincible;

    private Animator anim;

    private string enemyTag = "enemy";

    private float timeToDie;

   private AudioSource[] sounds;
   private AudioSource damageSound;
   private AudioSource deathSound;


    private bool canChange = true;

    private SpriteRenderer spriteRenderer;

    public startScreen running;

    private CanvasGroup deathCanvasAlpha;

    public bool hasInvincibilityPlus = false;

    

    

    //Start is called before the first frame update
    //Gets components and defines variables.
    void Start() 
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sounds = GetComponents<AudioSource>();
        damageSound = sounds[4];
        deathSound = sounds[5];
        deathSound.pitch = 0.4f;
        damageSound.pitch = 0.8f;
        running = GameObject.Find("title").GetComponent<startScreen>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        deathCanvasAlpha = GameObject.Find("deathCanvas").GetComponent<CanvasGroup>();

        // Invincible color back to normal.
       if (Time.time > timeNow + invTime)
       {
        invincible = false;
        Vector4 redValue = spriteRenderer.color;
        redValue.x = 255;
        redValue.y = 255;
        redValue.z = 255;
        spriteRenderer.color = redValue;

       }

        // If hp is 0, set dead to true, and start coroutines of death canvas, and to loop the death animation.
       if (hp == 0 && canChange)
       {

        
        deadManagement();
        StartCoroutine("deathCanvas");
        StartCoroutine("loopDeath");
        dead = true;
        canChange = false;

       }

       if(hasInvincibilityPlus)
       {

        invTime = 2f;

       }

       else
       {

        invTime = 1f;
       }



        
    }

    // Invincible class, classified by setting the player's color to yellow and playing a damage sound.
    void InvincibilityTime()
    {

            if (hp > 0){

               
                timeNow = Time.time;
                invincible = true;

                Vector4 redValue = spriteRenderer.color;
                redValue.x = 255;
                redValue.y = 255;
                redValue.z = 0;
                spriteRenderer.color = redValue;
                damageSound.Play();

            }
            

    }

    //If player collides with an enemy object, call the invicible class above and reduce hp.

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag(enemyTag) && !invincible)
        {
            hp--;
            InvincibilityTime();
            
        
        }


    }

      void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("hitVillain") && !invincible)
        {

            hp--;
            InvincibilityTime();

        }

    }

    //Dead management class, classified by setting aniamtors properties, setting the game running to false
    // and playing a death sound.
    void deadManagement()
    {

        anim.SetBool("dead", true);
        anim.SetFloat("canControl", 0);
        deathSound.Play();
        running.running = false;
        
       
        

    }

    // deathCanvas coroutine, waiting 3.5 secons in order to make death canvas visible.
    IEnumerator deathCanvas()
    {
        yield return new WaitForSeconds(3.5f);
        deathCanvasAlpha.alpha = 1f;


    }


    // LoopDeath corountine, waiting 1.84 seconds to start the loop death animation.
    IEnumerator loopDeath()
    {

        yield return new WaitForSeconds(1.84f);
        anim.SetBool("deathLoop", true);
        

    }

  

   
}
