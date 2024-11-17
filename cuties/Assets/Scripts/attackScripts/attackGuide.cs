using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attackGuide : MonoBehaviour
{

    private Animator playerAnim;
    public GameObject attackText;

    private bool spawnGuide = true;

    private bool attack;

    private GameObject guideAttacking;
   
    // Start is called before the first frame update
    void Start()
    {

        playerAnim = GameObject.Find("player").GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

       
        if(playerAnim.GetBool("hasWeapon") == true && spawnGuide)
        {

            guideAttacking = Instantiate(attackText, transform.position, transform.rotation);
            spawnGuide = false;

            


        }

        if(Input.GetKeyDown(KeyCode.E) && playerAnim.GetBool("hasWeapon"))
        {

            Destroy(guideAttacking);

        }

        

        

        

      

        
    }
}
