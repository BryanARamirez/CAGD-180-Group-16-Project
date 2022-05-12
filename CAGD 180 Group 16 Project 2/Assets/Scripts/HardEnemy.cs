using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Author: Xion, Pao
 * Date: 5/11/2022
 * Description: Makes the hard enemies move towards the player.
 * */
public class HardEnemy : MonoBehaviour
{
    //Varibles
    public float speed;
    private Transform target;
    Rigidbody myRb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent <Transform> ();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the enemy towards the player
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
       
    }
}
