using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject Player;

    public GameManager gm;

    public GameObject Speech;
    public GameObject AngryFace;

    public float speed = 5.0f;
    public bool followPlayer = false;

    public int enemyhealth = 1;

    public GameObject rightBarrier;

    void Start()
    {
        Player = GameObject.Find("Player");

        Physics.IgnoreCollision(rightBarrier.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void Update()
    {
        if (followPlayer)
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

        if (enemyhealth <= 0)
            Destroy(gameObject);

        if (enemyhealth <= 0 && gameObject.name == "Boss Enemy")
        {
            Destroy(gameObject);
            gm.GetComponent<GameManager>().LoadNextNextScene();
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            gm.GetComponent<GameManager>().health -= 1;
        }
            
    }
}
