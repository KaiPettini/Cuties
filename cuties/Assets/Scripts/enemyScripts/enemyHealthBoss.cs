using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyHealthBoss : MonoBehaviour
{

    public int hp = 1;
    private hit hit;

    private AudioSource[] sounds;
    private AudioSource damageSound;

    private SpriteRenderer spriteRenderer;
    private float timeNow;
    private float timeToNoRed = 0.35f;
    public GameObject dyingAnim;
    private bool canDie = true;

    public float disappearTime = 1.5f;

    public float timeToDelete = 0.1f;

    public bool dead = false;

    private CircleCollider2D bossCollider;
    
    // Sets components and defines variables.
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        hit = GameObject.Find("hitL").GetComponent<hit>();
        damageSound = sounds[0];
        damageSound.pitch = 0.7f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        bossCollider = GameObject.Find("boss").GetComponent<CircleCollider2D>();
       
        
        
    }

    // Update is called once per frame
    void Update()
    {

        // if the hp == 0, start the coroutine of dying.
        if (hp == 0 && canDie)
        {
            StartCoroutine("Die");
            canDie = false;
            dead = true;
            

        }

        // Set damage color back to normal.
        if (Time.time > timeNow + timeToNoRed)
        {


            Vector4 redValue = spriteRenderer.color;
            redValue.x = 255;
            redValue.y = 255;
            redValue.z = 255;
            spriteRenderer.color = redValue;

        }

        

        

        

       
        
    }

    // if the enemy collides with a hit, calls takeDamage.
    void OnTriggerEnter2D(Collider2D other)
    {
        
        


        if(other.CompareTag("hit"))
        {

            

            takeDamage();

        }



    }

    //Take damage function, defined by reducing hp by hit damage amount.
    void takeDamage()
    {

        hp = hp - hit.damage;
        
        // if hp > 0, set color to red.

        if(hp > 0)
        {



            Vector4 redValue = spriteRenderer.color;
                redValue.x = 255;
                redValue.y = 0;
                redValue.z = 0;
                spriteRenderer.color = redValue;
                damageSound.pitch = 0.7f;
                damageSound.Play();
                

                timeNow = Time.time;
        }
        else
        {
            damageSound.pitch = 0.38f;
            damageSound.Play();

        }

    }

    // coroutine die, defined by waiting a smaill amount and starting the dying animation, deleting that object after.
    IEnumerator Die()
    {

        yield return new WaitForSeconds(0.1f);
        
        GameObject animToDel = Instantiate(dyingAnim, transform.position, transform.rotation);
        Destroy(animToDel, disappearTime);
        
        spriteRenderer.sortingLayerName = "background";
        spriteRenderer.sortingOrder = 0;
        Destroy(bossCollider);

        
    }

    

    
}
