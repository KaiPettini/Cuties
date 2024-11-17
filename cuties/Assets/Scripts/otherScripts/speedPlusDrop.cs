using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedPlusDrop : MonoBehaviour
{

    private float vicinity = 0.3f;

    private GameObject player;

    private AudioSource popSound;

    private xMov playerXMov;

    private yMov playerYMov;



    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("player");
        popSound = GetComponent<AudioSource>();
        playerXMov = GameObject.Find("player").GetComponent<xMov>();
        playerYMov = GameObject.Find("player").GetComponent<yMov>();
        
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

        playerXMov.speedIncrease = 1.2f;
        playerYMov.speedIncrease = 1.2f;
        popSound.Play();
        Destroy(gameObject, 0.1f);

    }
}
