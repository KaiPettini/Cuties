using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class attackSword : MonoBehaviour
{

    private Animator anim;

    private AudioSource balloonSwing;

    public AudioClip[] balloonSwings;

    private AudioSource[] sounds;

    private AudioSource inflate;

    private weapon sword;
    


    private float timeNow;

    private bool click;

    public float hitTime = 0.75f;

    public int hits = 0;
    private bool canPlayInflate = true;
    public GameObject[] hitBoxes;
    private string stateName;

    public bool hasWeapon = false;

   








    void Start()
    {



        // Gets components of game objetcs and animator
        sword = GameObject.Find("floatingSword").GetComponent<weapon>();
        anim = GetComponent<Animator>();
        sounds = GetComponents<AudioSource>();
        balloonSwing = sounds[0];
        inflate = sounds[2];
        inflate.pitch = 1.4f;
        

      



    }

    void Update()
    {

        

        //Sets the value of has weapon from the FloatingSword object for 
        // animation
        anim.SetBool("hasWeapon", hasWeapon);
        

        // Input setups for swing
        click = Input.GetKeyDown(KeyCode.E);
        if (click && anim.GetFloat("canControl") > 0 && 
        anim.GetBool("hasWeapon"))
        {
            swing();
            
        }

       

        
        // Cooldown mechanic per swing
        if (Time.time > timeNow + hitTime && anim.GetBool("attacking"))
        {

            anim.SetBool("attacking", false);
            anim.SetFloat("canControl", 1);


        }
        
        if (sword.IsDestroyed() && !inflate.isPlaying && canPlayInflate){

            playInflate();
            

        }

       

        

        


    }


    //Swing class, defined by setting animations and getting time of swing

    void swing()
    {

        timeNow = Time.time;
        anim.SetBool("attacking", true);
        anim.SetFloat("canControl", 0);
        hits++;
        balloonSwing.clip = balloonSwings[UnityEngine.Random.Range(0,2)];
        balloonSwing.Play();
        StartCoroutine("spawnHit");
        

        

    
        
        

    


    }

    // Play the inflate balloon sound
    void playInflate()
    {
        inflate.Play();
        canPlayInflate = false;


    }

    // Spawns the trigger hitbox, which triggers when hitting an enemy.s
    IEnumerator spawnHit()
    {
        yield return new WaitForSeconds(0.35f);
        stateName = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if (stateName == "attackHorL_Clip")
        {

            GameObject hitToDel = Instantiate(hitBoxes[0], transform.position, transform.rotation);
            Destroy(hitToDel, 0.1f);
        }
        if (stateName == "attackHorR_Clip")
        {

            GameObject hitToDel = Instantiate(hitBoxes[1], transform.position, transform.rotation);
            Destroy(hitToDel, 0.1f);
            


        }
        if (stateName == "attackBack_Clip")
        {
            GameObject hitToDel = Instantiate(hitBoxes[2], transform.position, transform.rotation);
            Destroy(hitToDel, 0.1f);
            

        }

        if(stateName == "attack1_Clip")
        {
            
            GameObject hitToDel = Instantiate(hitBoxes[3], transform.position, transform.rotation);
            Destroy(hitToDel, 0.1f);

        }

      


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("sword"))
        {

            hasWeapon = true;
            Destroy(GameObject.FindGameObjectWithTag("sword"));

        }


    }

    

   
  
}
