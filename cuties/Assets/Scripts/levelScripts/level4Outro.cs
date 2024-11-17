using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4Outro : MonoBehaviour
{

    private bool bossDead;

    public bool outroTime;
    // Start is called before the first frame update
    void Start()
    {
        bossDead = GameObject.Find("boss").GetComponent<enemyHealthBoss>().dead;
    }

    // Update is called once per frame
    void Update()
    {

        if(bossDead == true)
        {
            outroTime = true;

        }
        
    }
}
