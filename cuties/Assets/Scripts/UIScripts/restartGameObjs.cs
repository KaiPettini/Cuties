using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{

    public GameObject[] dontDestroy;
    private tryAgainButton sceneReload;
    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject);
        sceneReload = GameObject.Find("tryAgainButton").GetComponent<tryAgainButton>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(sceneReload.sceneReloading)
        {

            foreach(GameObject obj in dontDestroy)
            {

                Destroy(obj, 0.5f);

            }

        }
        
    }
}
