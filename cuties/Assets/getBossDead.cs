using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class getBossDead : MonoBehaviour
{

    public bool outro = false;
    private enemyHealthBoss boss;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        if(SceneManager.GetActiveScene().name == "level4")
        {

            boss = GameObject.Find("boss").GetComponent<enemyHealthBoss>();

            if (boss.hp == 0)
            {

                StartCoroutine("startMusic");

            }

        }

       
       
    }
     IEnumerator startMusic()
        {
            yield return new WaitForSeconds(4f);
            outro = true;
            

        }
}
