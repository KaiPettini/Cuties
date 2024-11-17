using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public GameObject ObjectToSpawn;

    public Sprite[] chestSprites;
    private GameObject player;

    private float vicinity = 0.3f;
    private bool canOpen = true;

    private SpriteRenderer spriteRenderer;

    private AudioSource openSound;

    

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        openSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

       if (Mathf.Abs(transform.position.x - player.transform.position.x) < vicinity
                && Mathf.Abs(transform.position.y - player.transform.position.y) < vicinity && canOpen)
                {

                    if(Input.GetKeyDown(KeyCode.Z))
                    {
                        
                        openChest();
                        
                        
                    }

                }
        
    }

    void openChest()
    {

        spriteRenderer.sprite = chestSprites[1];
        Vector3 transformPos;
        transformPos.y = transform.position.y + 0.18f;
        transformPos.x = transform.position.x + 0.022f;
        transformPos.z = transform.position.z;
        Instantiate(ObjectToSpawn, transformPos, transform.rotation);
        canOpen = false;
        openSound.Play();

    }
}
