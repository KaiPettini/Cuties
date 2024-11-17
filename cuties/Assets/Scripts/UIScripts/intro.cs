using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class intro : MonoBehaviour
{


    [System.Serializable]
    public class DialogueLine
    {

        [TextArea(3, 10)]
        public string line;


    }

    [System.Serializable]
    public class Dialogue
    {

        public List<DialogueLine> dialogueLines = new List<DialogueLine>();

    }

    
    public Dialogue dialogue;
}
