using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outroCagedMouse : MonoBehaviour
{

    private getBossDead outro;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        outro = GameObject.Find("Main Camera").GetComponent<getBossDead>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(outro.outro)
        {

            anim.SetBool("outroTime", true);

        }
    }
}
