using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponUI : MonoBehaviour
{

    private Animator playerAnim;
    public Sprite[] holderSprite;

    private UnityEngine.UI.Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        playerAnim = GameObject.Find("player").GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(playerAnim.GetBool("hasWeapon"))
        {

            image.sprite = holderSprite[1];

        }
        else
        {

            image.sprite = holderSprite[0];

        }
        
    }
}
