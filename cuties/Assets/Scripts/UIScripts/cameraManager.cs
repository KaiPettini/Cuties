using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    private Animator anim;
    private CinemachineVirtualCamera virtualCamera;

    private bool intro2Ended = false;

    

    private Animator canvasAnim;

    private Animator playerAnim;

    private GameObject playerSpawn;

    public GameObject player;

    private level4intro intro4;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        canvasAnim = GameObject.Find("startScreenCanvas").GetComponent<Animator>();
        playerSpawn = GameObject.Find("playerSpawn");
        playerAnim = GameObject.Find("player").GetComponent<Animator>();
        intro4 = GameObject.Find("level4intro").GetComponent<level4intro>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if(canvasAnim.GetBool("animBegin") && !playerSpawn.IsDestroyed())
        {
          
            anim.SetBool("introBegin", true);
            virtualCamera.Follow = null;

        }

        else if(SceneManager.GetActiveScene().name == "level2" && !intro2Ended) 
        {

            anim.SetBool("intro2Begin", true);
            virtualCamera.Follow = null;
            StartCoroutine("spawnEnemies");
            


        }

        else if (SceneManager.GetActiveScene().name == "level4" && !intro4.intro4ended)
        {

            anim.SetBool("intro4Begin", true);
            virtualCamera.Follow = null;
            StartCoroutine("bossEntry");
            playerAnim.SetFloat("canControl", 0);
            

        }
        else if (playerSpawn.IsDestroyed())
        {

            virtualCamera.Follow = player.transform;

        }
        
    }

    IEnumerator spawnEnemies()
    {

        yield return new WaitForSeconds(4.5f);
        intro2Ended = true;



    }

    IEnumerator bossEntry()
    {

        yield return new WaitForSeconds(1f);

        if(intro4.intro4ended)
        {
            playerAnim.SetFloat("canControl", 1);
        }
        

    }


}
