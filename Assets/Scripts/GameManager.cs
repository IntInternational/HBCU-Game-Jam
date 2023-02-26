using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Story canvases
    public GameObject[] canvases;

    public int currentCanvas = 0;

    // Health code
    public TMP_Text healthText;

    public int health = 5;
    public bool isDead = false;

    public GameObject GameOver;

    // Protagonist dialogue boxes
    public GameObject protagDialog;

    public bool activateProtagDialogue = false;

    public GameObject player;
    // Enemy
    public GameObject enemy;

    public GameObject firstDialogue;
    public GameObject nextDialog;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Example so we can test the Health Bar functionality
        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            TakeDamage();
        }

        if (health <= 0)
        {
            isDead = true;
            // GameOver.SetActive(true);
            player.GetComponent<CharacterController>().alive = false;
            LoadNextScene();
        }

        if (Input.GetKeyDown(KeyCode.Q) || activateProtagDialogue)
        {
            protagDialog.SetActive(true);
            activateProtagDialogue = true;
        }
        else if (!activateProtagDialogue)
        {
            protagDialog.SetActive(false);
        }


        healthText.text = "Health: " + health;
    }

    // Load next level
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Take health down by 1
    public void TakeDamage()
    {
        health -= 1;
    }

    // Load next canvas on menu
    public void LoadNextCanvas()
    {
        canvases[currentCanvas].SetActive(false);
        currentCanvas += 1;
        canvases[currentCanvas].SetActive(true);
    }

    // Dialogue boxes
    public void dialogueBoxTalk()
    {
        // Debug.Log("Talk");
        activateProtagDialogue = false;

        enemy.GetComponent<EnemyScript>().followPlayer = false;

        enemy.GetComponent<EnemyScript>().Speech.SetActive(false);
        enemy.GetComponent<EnemyScript>().AngryFace.SetActive(true);

        nextDialog.SetActive(true);
        firstDialogue.SetActive(true);
    }

    // Dialogue boxes
    public void dialogueBoxFight()
    {
        // Debug.Log("Fight");
        activateProtagDialogue = false;

        enemy.GetComponent<EnemyScript>().followPlayer = true;

        enemy.GetComponent<EnemyScript>().Speech.SetActive(false);
    }

    public void LoadNextNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
