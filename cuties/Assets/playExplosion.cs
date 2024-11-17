using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playExplosion : MonoBehaviour
{

    private AudioSource explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        explosionSound = GetComponent<AudioSource>();
        explosionSound.Play();
    }

    // Update is called once per frame
   
}
