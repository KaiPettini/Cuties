using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loveSkillDrop : MonoBehaviour
{

    private float vicinity = 0.3f;
    private GameObject player;

    private rightClickSkill loveSkill;

    private AudioSource popSound;



    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("player");
        loveSkill = GameObject.Find("player").GetComponent<rightClickSkill>();
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

        loveSkill.hasSkill = true;
        popSound.Play();
        Destroy(gameObject, 0.1f);

    }
}
