using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amulet : MonoBehaviour {

    public GameObject victory;
    bool treasureObtained = false;
    private MovePlayer player;

    void Start() {

    }

    private void Update()
    {
     
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player = col.gameObject.GetComponent<MovePlayer>();
            Destroy(player);
            treasureObtained = true;
            victory.SetActive(true);

        }
    }

    
}
