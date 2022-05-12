using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*Author: Xion, Pao
 * Date: 5/11/2022
 * Description: Makes the hard enemies move towards the player.
 * */
public class HardEnemy : MonoBehaviour
{
    //Varibles
    /* public float speed;
     private Transform target;
     Rigidbody myRb;
     Vector3 moveDirection;
    */
     private NavMeshAgent HEnemy;
    public GameObject Player;
    public float EnemyRun = 4f;
    

   
    // Start is called before the first frame update
    void Start()
    {
       // target = GameObject.FindGameObjectWithTag("Player").GetComponent <Transform> ();

        HEnemy = GetComponent<NavMeshAgent>();

        //myRb = GetComponent<Rigidbody>();
        //target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the enemy towards the player
       
       //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

       float distance = Vector3.Distance(transform.position, Player.transform.position);

        if(distance < EnemyRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            HEnemy.SetDestination(newPos);
        }
      
      /*
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

        
            myRb.velocity = new Vector3(moveDirection.x, moveDirection.y) * speed;
        */


    }


    
  



}
