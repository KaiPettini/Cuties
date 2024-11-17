using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnLocation : MonoBehaviour
{

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {

     player = GameObject.Find("player");
     Vector3 tempPlayerPos = player.transform.position;
     tempPlayerPos.x = transform.position.x;
     tempPlayerPos.y = transform.position.y;
     tempPlayerPos.z = player.transform.position.z;
     player.transform.position = tempPlayerPos;

    }

}
