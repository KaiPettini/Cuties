using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
using Unity.VisualScripting;

public class enemyAi : MonoBehaviour
{

    public AIPath aiPath;
    private bool facingRight;

    private startScreen running;

    private Animator villainAnim;

    private int charGenerator;

    private float speed;

    private Transform playerTransform;

    public float vicinity = 2f;

    private Animator anim;

    private float timeNow;

    private float hitTime = 0.75f;

    private AudioSource[] audios;

    public AudioClip[] balloonSwings;

    private AudioSource balloonSwing;

    private string stateName;

    public GameObject[] hitboxes;

    private float minDistance;

    private enemyHealth hp;

    // Start is called before the first frame update
    void Start()
    {
        
        running = GameObject.Find("title").GetComponent<startScreen>();
        villainAnim = GetComponent<Animator>();
        charGenerator = UnityEngine.Random.Range(1,4);
        anim = GetComponent<Animator>();
        playerTransform = GameObject.Find("player").GetComponent<Transform>();
        speed = GetComponent<AIPath>().maxSpeed;
        minDistance = GetComponent<AIPath>().endReachedDistance;
        audios = GetComponents<AudioSource>();
        hp = GetComponent<enemyHealth>();
        balloonSwing = audios[1];

        if (charGenerator == 1)
        {

            speed = 0.3f;
            minDistance = 0.3f;
            hp.hp = 5;
            
        }

        if(charGenerator == 2)
        {

            speed = 0.5f;
            minDistance = 0.2f;
            hp.hp = 4;

        }

        if(charGenerator == 3)
        {

            speed = 0.7f;
            minDistance = 0.1f;
            hp.hp = 3;

        }

        

    }

    // Update is called once per frame
    void Update()

    
    {
        
        

        if(aiPath.desiredVelocity.x >= 0.01f && facingRight)
        {

            FlipFacing();
            villainAnim.SetFloat("xSpeed", -1f);

        }
        else if (aiPath.desiredVelocity.x <= 0.01f && !facingRight)
        {

            FlipFacing();
            villainAnim.SetFloat("xSpeed", 1f);

        }

        if (!running.running || !anim.GetBool("canControl")){

            aiPath.maxSpeed = 0;

        }


        else{

            aiPath.maxSpeed = speed;
            aiPath.endReachedDistance = minDistance;

        }

        if(Mathf.Abs(transform.position.x - playerTransform.position.x) < vicinity
        && Mathf.Abs(transform.position.y - playerTransform.position.y) < vicinity
        && anim.GetBool("canControl"))
        {   

            swing();


            
        }

        if(Time.time > timeNow + hitTime && anim.GetBool("attacking"))
        {

            anim.SetBool("canControl", true);
            anim.SetBool("attacking", false);

        }

        

        
        


        

        
        
    }

    void FlipFacing(){

        Vector3 tempRotation = transform.localScale;
        tempRotation.x *= -1.0f;
        transform.localScale = tempRotation;

        facingRight = !facingRight;

    }

    void swing()
    {
        timeNow = Time.time;
        anim.SetBool("attacking", true);
        anim.SetBool("canControl", false);
        balloonSwing.clip = balloonSwings[UnityEngine.Random.Range(0,2)];
       

        balloonSwing.Play();
        
        StartCoroutine("spawnHit");
    
        
        


    }

    IEnumerator spawnHit()
    {

        yield return new WaitForSeconds(0.35f);
        stateName = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;

        if(stateName == "villainAttack_Clip")
        {

            GameObject hitToDel = Instantiate(hitboxes[0], transform.position, transform.rotation);
            Destroy(hitToDel, 0.1f);

        }

        if(stateName == "villainAttackR_Clip")
        {

            GameObject hitToDel = Instantiate(hitboxes[1], transform.position, transform.rotation);
            Destroy(hitToDel, 0.1f);

        }
        

    }


}
