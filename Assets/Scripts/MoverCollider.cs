using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCollider : MonoBehaviour
{
    public GameObject barrier;

    public float xPos = 20.0f;

    public bool isMover1 = false;

    public GameObject[] newEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            barrier.GetComponent<SideScroll>().nextXPos += xPos;
            barrier.GetComponent<SideScroll>().moving = true;
            Destroy(gameObject);

            for (int i = 0; i < newEnemies.Length; i++)
                newEnemies[i].GetComponent<EnemyScript>().followPlayer = true;
        }
    }
}
