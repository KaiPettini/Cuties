using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibilityPlusDrop : MonoBehaviour
{
    private float vicinity = 0.3f;
    private GameObject player;

    private charHealth invincibility;

    private AudioSource popSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        invincibility = GameObject.Find("player").GetComponent<charHealth>();
        popSound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

         if (Mathf.Abs(transform.position.x - player.transform.position.x) < vicinity
                && Mathf.Abs(transform.position.y - player.transform.position.y) < vicinity)
                {

                    if(Input.GetKeyDown(KeyCode.Z))
                    {
                      

                        getSkill();

                    }


                }
        
    }

    void getSkill()

    {

        invincibility.invTime = 2.0f;
        invincibility.hasInvincibilityPlus = true;
        popSound.Play();
        Destroy(gameObject, 0.1f);

    }
}
