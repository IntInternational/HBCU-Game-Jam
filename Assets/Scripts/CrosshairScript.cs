using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    float shake = 0f;
    float shakeAmount = 0.7f;
    float decreaseFactor = 1.0f;

    SpriteRenderer m_SpriteRenderer;

    // public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        GetComponent<Collider2D>().enabled = false;

        m_SpriteRenderer.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            m_SpriteRenderer.color = Color.blue;

            GetComponent<Collider2D>().enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            m_SpriteRenderer.color = Color.red;

            GetComponent<Collider2D>().enabled = false;
        }

        if (shake > 0)
        {
            Camera.main.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);

        if (collision.tag == "Enemy")
        {
            // shake = 1f;
            Debug.Log("Enemy Hit!");
            collision.GetComponent<EnemyScript>().enemyhealth -= 1;
        }
    }
}