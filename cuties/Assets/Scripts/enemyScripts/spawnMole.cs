using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleHole : MonoBehaviour
{


    
    

    

    private AudioSource[] sounds;
    private AudioSource digUp;


     public float vicinity = 0.2f;

    public GameObject[] enemies;
    private int enemyIndex;
    private bool canSpawn = true;



    
    // Start is called before the first frame update
    //Gets components and defines variables,
    void Start()
    {

    
        sounds = GetComponents<AudioSource>();
        digUp = sounds[0];
        digUp.pitch = 1.3f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if canSpawn, start coroutine of spawning the mole.

        if (canSpawn)

        
        {
    
            StartCoroutine("SpawnMole");
            
        }

    

        
    }

    //coroutine of spawning the mole, defined by waiting 1.2s until randomly spawning a mole, and playing a sound.
    IEnumerator SpawnMole()
    {


        yield return new WaitForSeconds(1.2f); 
        enemyIndex = Random.Range(0, enemies.Length);

        if (canSpawn)
        {
            Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
            canSpawn = false;

            if(!digUp.isPlaying)
            {
                digUp.Play();

            }
        
        }
        
        
    }
}
