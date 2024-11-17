using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outroCanvas : MonoBehaviour
{

    private getBossDead outro;
    private CanvasGroup canvas;

    private startScreen running;

    private CanvasGroup victoryCanvas;

    private CanvasGroup deathCanvas;
    // Start is called before the first frame update
    void Start()
    {
        outro = GameObject.Find("Main Camera").GetComponent<getBossDead>();
        canvas = GetComponent<CanvasGroup>();
        running = GameObject.Find("title").GetComponent<startScreen>();
        victoryCanvas = GameObject.Find("victoryMessage").GetComponent<CanvasGroup>();
        deathCanvas = GameObject.Find("deathMessage").GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(outro.outro)
        {

            canvas.alpha = 1;
            running.running = false;
            victoryCanvas.alpha = 1;
            deathCanvas.alpha = 0;

        }
    }
}
