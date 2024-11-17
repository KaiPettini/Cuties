using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killbox : MonoBehaviour
{

    //private charHealth player;
    public float timeToDie = 0.0f;
    private float timeNow;
    // Start is called before the first frame update
    private Animator playerAnim;

    void Start()
    {
        //player = GameObject.Find("player").GetComponent<charHealth>();
        playerAnim = GameObject.Find("player").GetComponent<Animator>();
        

    }

    


    void Update(){

        //if (player.dead && Time.time > timeNow + timeToDie)
        //{

           // SceneManager.LoadScene(0);



       // }
        



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //player.dead = true;
        playerAnim.SetBool("dead", true);
        playerAnim.SetFloat("canControl", 0);
        timeToDie = 3.5f;
        timeNow = Time.time;
        
        
        


    }
}
