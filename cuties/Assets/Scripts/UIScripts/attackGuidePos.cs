using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackGuidePos : MonoBehaviour
{

    private GameObject playerPos;
    // Start is called before the first frame update
    void Start()
    {

        playerPos = GameObject.Find("player");
        
    }

    // Update is called once per frame
    void Update()
    {

       

            Vector3 guidePos = transform.position;
            guidePos.x = playerPos.transform.position.x;
            guidePos.y = playerPos.transform.position.y - 0.04f;
            guidePos.z = playerPos.transform.position.z;

            transform.position = guidePos;



      
        
    }
}
