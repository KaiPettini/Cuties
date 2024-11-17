using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnLvl4 : MonoBehaviour
{

    private level4intro intro4;
    public GameObject mouseVillain;

    private bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        intro4 = GameObject.Find("level4intro").GetComponent<level4intro>();
    }

    // Update is called once per frame
    void Update()
    {

        if(intro4.intro4ended && canSpawn)
        {

            spawnEnemies();

        }
        
    }

    void spawnEnemies()
    {

        Instantiate(mouseVillain, transform.position, transform.rotation);
        canSpawn = false;
        Destroy(gameObject, 0.1f);
        
        
    }
}
