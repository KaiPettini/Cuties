using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnLevel2 : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnEnemy");
    }

    // Update is called once per frame
    IEnumerator spawnEnemy()
    {

        yield return new WaitForSeconds(4.55f);
        Instantiate(enemy, transform.position, transform.rotation);
        Destroy(gameObject, 0.1f);
        

    }
}
