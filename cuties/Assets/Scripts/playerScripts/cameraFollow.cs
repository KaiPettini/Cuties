using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraFollow : MonoBehaviour
{

    private GameObject player;
    private UnityEngine.Vector3 offset;

    public static cameraFollow instance;
    // Start is called before the first frame update
    // Calls objects and defines variables.
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position;
        if(instance != null){

        }
        
    }

    // Update is called once per frame
    void Update()
    {

        // Gets the player transforms x and y.
        offset.x = player.transform.position.x;
        offset.y = player.transform.position.y;


        // if the player between the values below, set the camera's positions to follow the player's.
        UnityEngine.Vector3 newOffset = transform.position;

        
       
        
            newOffset.x = offset.x;
            transform.position = newOffset;
        
        

        
        

            newOffset.y = offset.y;
            transform.position = newOffset;
        

        
       

        
        

        
    }
}
