using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Worked on by Bryan Ramirez

public class Dummy : MonoBehaviour
{
    public float health = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health = health - 1;
        }
        if (other.gameObject.tag == "Heavy_Bullet")
        {
            health = health - 3;
        }
    }
}
