using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level4Trigger : MonoBehaviour
{
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D other)
   {

        if(other.CompareTag("Player"))
        {

            SceneManager.LoadScene(3, LoadSceneMode.Single);

        }

   }
}
