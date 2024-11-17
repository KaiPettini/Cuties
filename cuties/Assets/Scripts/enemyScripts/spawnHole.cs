using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject hole;

    private Vector3 tempPos;

    public float vicinity = 0.5f;

    private GameObject player;
    private bool canSpawn = true;
    private startScreen running;
    

    //Gets components and defines variables.
    void Start()

    {

        player = GameObject.FindGameObjectWithTag("Player");
        running = GameObject.Find("title").GetComponent<startScreen>();

    }

   
    void Update()
    {

        //if game is running, and the player is between the object's, call spawn hole.
        if(running.running)
        {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) < vicinity
                && Mathf.Abs(transform.position.y - player.transform.position.y) < vicinity
                && canSpawn)
            
            {
                SpawnHole();
                

            }
        }



    
        
    }

    
    //Spawn hole class, defined by randomly spawning a hole within a range, as well as instantiating it.
    void SpawnHole()
    {

        tempPos = transform.position;
        tempPos.x += transform.position.x * Random.Range(-0.2f, 0.3f);
        //tempPos.y += transform.position.y * Random.Range(-2.9f, 3.3f);
        transform.position = tempPos;
        tempPos.y += transform.position.y * Random.Range(-0.2f, 0f);
        transform.position = tempPos;

        
        Instantiate(hole, transform.position, transform.rotation);
        canSpawn = false;
        
    }
}
