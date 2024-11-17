using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;

public class rightClickSkill : MonoBehaviour
{

    private bool click;
    private Animator anim;

    public float timeNow;

    private AudioSource[] sounds;

    private AudioSource skillSound;

    private float useTime = 1.3f;

    public float cooldown = 0;
    private startScreen running;

    private charHealth hp;

    private UnityEngine.UI.Image skillCD;

    public bool hasSkill = false;

    


    // Start is called before the first frame update

    // Gets components and defines variables.
    void Start()
    {
        
        anim = GetComponent<Animator>();
        sounds = GetComponents<AudioSource>();
        skillSound = sounds[3];
        running = GameObject.Find("title").GetComponent<startScreen>();
        hp = GetComponent<charHealth>();
        skillCD = GameObject.Find("skillCooldown").GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {

        //if the game is running and the user has the skill, get input and  
        //if the input is greater than 0, as well as the ability not being on cooldown, use the skill.


        if(running.running)
        {

            if (hasSkill)
            {
                click = Input.GetKeyDown(KeyCode.Q);
                Debug.Log(click);
                if (click && anim.GetFloat("canControl") > 0 &&
                Time.time > timeNow + cooldown)
            {

                useSkill();


            }

            if (Time.time > timeNow + useTime && anim.GetBool("channelling"))
            {

                anim.SetBool("channelling", false);
                anim.SetFloat("canControl", 1);


            }


            }

                
        }
        if(Time.time < (cooldown + timeNow))

        {
            skillCD.fillAmount = 1 - (cooldown + timeNow - Time.time)/cooldown;
            
        }
        else
        {

           skillCD.fillAmount = 1;

        }

        




            
    

    }   

    //use Skill class, defined by setting animator properties setting a cooldown, increasing hp, and playing a sound.
    void useSkill()
    {


        timeNow = Time.time;
        anim.SetBool("channelling", true);
        anim.SetFloat("canControl", 0);
        cooldown = 7.0f;
        skillSound.Play();
        if (hp.hp < 5)
        {
            hp.hp ++;
        }

        
    }
}
