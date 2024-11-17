using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level3Trigger : MonoBehaviour
{

    public GameObject textToShow;

    // Update is called once per frame
   
   void OnTriggerEnter2D(Collider2D other)
   {

        if(other.CompareTag("Player"))
        {

            SceneManager.LoadScene(2, LoadSceneMode.Single);

        }

   }
}
