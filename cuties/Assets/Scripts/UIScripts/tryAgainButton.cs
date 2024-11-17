using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tryAgainButton : MonoBehaviour
{

    private Button pressPlay;
    private startScreen running;

    private Animator canvasAnim;
  

    private AudioSource click;

    private Image image;

    public bool sceneReloading = false;

    public GameObject[] dontDestroy;

    

    // Start is called before the first frame update
    // Gets components and defines variables.
    void Start()
    {

        pressPlay = GetComponent<Button>();
        pressPlay.onClick.AddListener(clickSound);
        pressPlay.onClick.AddListener(playAgain);
        running = GameObject.Find("title").GetComponent<startScreen>();
        click = GetComponent<AudioSource>();
        image = GetComponent<Image>();

        

        
        
    }

    // if player clicks the button, start coroutine of playing again.
     void playAgain()
    {
        sceneReloading  = true;
        StartCoroutine("pressPlayAgain");
    }

    

    //Click sound class, defined by playing a sound  and making the button darker.


    public void clickSound()
    {
        if (!running.running)
        {
            click.Play();
        }
        
        UnityEngine.Vector4 imageColors = image.color;
            imageColors.w = 1f; 
            imageColors.x = 0.8f;
            imageColors.y = 0.8f;
            imageColors.z = 0.8f;
        

            image.color = imageColors;


    }
    
    //coroutine pressplayagain, defined by waiting 0.5s until reloading the scene.
    IEnumerator pressPlayAgain()
    {

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(0);

        

        foreach(GameObject obj in dontDestroy)
        {
            Destroy(obj);

        }
        

    }
}
