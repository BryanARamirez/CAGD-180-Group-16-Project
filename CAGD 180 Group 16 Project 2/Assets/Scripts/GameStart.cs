using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        if(gameStarted == false)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
            gameStarted = true;
            Destroy(this);
        }
    }
}
