using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attackCounter : MonoBehaviour
{


    public TMP_Text hitCounter;
    public attackSword hits;

    public int attackCount = 0;
    // Start is called before the first frame update
    void Start()
    {

        // G

       // hitCounter = GameObject.Find("hitCounter").GetComponent<TMPro.TMP_Text>();
        
        hits = GameObject.Find("player").GetComponent<attackSword>();

        
        

        
    }

    // Update is called once per frame
    void Update()

    
    {
       // hitCounter.text = "Number of Hits: " + hits.hits.ToString();

        
    }
}
