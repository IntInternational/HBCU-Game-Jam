using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    // Story canvases
    public GameObject[] dialogue;

    public int currentDialogue = 0;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextDialogueOption()
    {
        dialogue[currentDialogue].SetActive(false);
        currentDialogue += 1;
        dialogue[currentDialogue].SetActive(true);

        if(currentDialogue == dialogue.Length)
            enemy.GetComponent<EnemyScript>().followPlayer = true;
    }
}
