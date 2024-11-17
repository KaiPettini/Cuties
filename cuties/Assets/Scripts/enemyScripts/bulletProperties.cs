using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletProperties : MonoBehaviour
{

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("explosionSpawn");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator explosionSpawn()
    {

        yield return new WaitForSeconds(1.08f);
        GameObject explosionToDel = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosionToDel, 0.35f);
        Destroy(gameObject, 0.1f);



    }
}
