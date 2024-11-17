using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyImage : MonoBehaviour
{

    private startScreen running;
    // Start is called before the first frame update
    void Start()
    {
        running = GameObject.Find("title").GetComponent<startScreen>();
    }

    // Update is called once per frame
    void Update()
    {
       if(running.running)
       {

        Destroy(gameObject, 2f);
       } 
    }
}
