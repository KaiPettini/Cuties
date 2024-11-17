using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class bossSkills : MonoBehaviour
{

    private Animator anim;

    private int skillGenerator;

    private float cooldown;

    private float timeNow;

    public GameObject enemySpawn1;
    public GameObject enemySpawn2;
    public GameObject mouseVillain;

    public GameObject bossHit;
    private bool canSpawn = true;

    public GameObject bullets;

    private level4intro intro4;

    private GameObject player;

    private enemyHealthBoss bossDead;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        intro4 = GameObject.Find("level4intro").GetComponent<level4intro>();
        player = GameObject.Find("player");
        bossDead = GameObject.Find("boss").GetComponent<enemyHealthBoss>();
       
    }

    // Update is called once per frame
    void Update()
    {

   

        if(Time.time > timeNow + cooldown && intro4.intro4ended && bossDead.hp != 0)
        {

            generateSkill();
            canSpawn = true;
            

        }



        if(skillGenerator == 1 && canSpawn)
        {

            StartCoroutine("enemySpawn");
            

        }
        
        if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "villainSkillSpawn_Clip")
        {

            anim.SetBool("spawnSkill", false);

        }

        if(skillGenerator == 2 && canSpawn)
        {
            
            StartCoroutine("hitAttack");    

        }

        if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "villainAttackHit_Clip")
        {

            anim.SetBool("hitSkill", false);

        }

        if(skillGenerator == 3 && canSpawn)
        {

            StartCoroutine("bulletSkill");

        }

        if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "villainAttackBullets_Clip")
        {

            anim.SetBool("bulletSkill", false);

        }
        
        
    }

    void generateSkill()
    {

        skillGenerator = UnityEngine.Random.Range(1,4);
        timeNow = Time.time;
        cooldown = 10f;
    }

    IEnumerator enemySpawn()
    {
        yield return new WaitForSeconds(0f);
        Instantiate(mouseVillain, enemySpawn1.transform.position, enemySpawn1.transform.rotation);
        Instantiate(mouseVillain, enemySpawn2.transform.position, enemySpawn2.transform.rotation);
        canSpawn = false;
        anim.SetBool("spawnSkill", true);
        StopCoroutine("enemySpawn");
        

    }

    IEnumerator hitAttack()
    {

        yield return new WaitForSeconds(0.0f);
        anim.SetBool("hitSkill", true);
        StartCoroutine("spawnHit");
        canSpawn = false;
        StopCoroutine("hitAttack");
        



    }

    IEnumerator spawnHit()
    {

        yield return new WaitForSeconds(1.0f);

        GameObject hitToDel = Instantiate(bossHit, transform.position, transform.rotation);
        Destroy(hitToDel, 0.1f);

    }

    IEnumerator bulletSkill()
    {

        yield return new WaitForSeconds(0.0f);
        anim.SetBool("bulletSkill", true);
        StartCoroutine("spawnBullet1");
        StartCoroutine("spawnBullet2");
        StartCoroutine("spawnBullet3");
        canSpawn = false;
        StopCoroutine("bulletSkill");

    }

    IEnumerator spawnBullet1()
    {

        yield return new WaitForSeconds(1.5f);
        Instantiate(bullets, player.transform.position, player.transform.rotation);


    }
    IEnumerator spawnBullet2()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(bullets, player.transform.position, player.transform.rotation);

    }

    IEnumerator spawnBullet3()
    {
        yield return new WaitForSeconds(2.5f);
        Instantiate(bullets, player.transform.position, player.transform.rotation);

    }
}
