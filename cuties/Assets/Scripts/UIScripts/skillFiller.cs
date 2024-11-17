using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillFiller : MonoBehaviour
{

    private rightClickSkill loveSkill;
    public Sprite[] skillSprites;

    private UnityEngine.UI.Image image;
    // Start is called before the first frame update
    void Start()
    {

        loveSkill = GameObject.Find("player").GetComponent<rightClickSkill>();
        image = GetComponent<UnityEngine.UI.Image>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (loveSkill.hasSkill)
        {

            
            image.sprite = skillSprites[1];
        }

        else
        {

            image.sprite = skillSprites[0];

        }
        
    }
}
