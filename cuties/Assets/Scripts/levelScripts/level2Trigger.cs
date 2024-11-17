using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2Load : MonoBehaviour
{

    

   
    public bool inScene2 = false;

    private GameObject floatingSword;


    public GameObject textToShow;
    private bool canSpawn = true;

    private GameObject warning;

    void Start()
    {

        floatingSword = GameObject.Find("floatingSword");

    }

    void Update()

    {

        if(floatingSword.IsDestroyed()){

            Destroy(warning);
        }

    }



    
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player"))
        {

            if(floatingSword.IsDestroyed())
            {

                SceneManager.LoadScene(1, LoadSceneMode.Single);
            


            }
            else if(canSpawn)
            {

                warning = Instantiate(textToShow, transform.position, transform.rotation);
                canSpawn = false;


            }

            

            

        }

    }

    
}

