using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {


    public GameObject enemy;
    private Transform player;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0f;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (randX < 65)
            {
                if (Time.time > nextSpawn)
                {
                    nextSpawn = Time.time + spawnRate;
                    randX = player.position.x + Random.Range(7f, 9f);
                    whereToSpawn = new Vector2(randX, transform.position.y + 2);
                    Instantiate(enemy, whereToSpawn, Quaternion.identity);
                    Debug.Log("Enemy spawned");
                }
            }
        }
    }
}
