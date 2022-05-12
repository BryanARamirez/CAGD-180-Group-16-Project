using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Author: Xiong, Pao
 * Date:5//11/2022
 * Description: The normal enemies move left and right, Also prevents them from going of a cliff and turn around after reaching a wall
 * */

public class NormalEnemy : MonoBehaviour
{
    //Varibles
    public float speed;
    Rigidbody myRb;

   
    // Start is called before the first frame update
   void Start()
    {
        myRb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {
            //goes right
            myRb.velocity = new Vector3(speed, 0f);
        }
        else
        {
            //goes left
            myRb.velocity = new Vector3(-speed, 0f);
        }
    }
    
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    //prevents the enemy from walking off a cliff and turns them around after reching a wall
    private void OnTriggerExit(Collider collision)
    {
        transform.localScale = new Vector3(-(Mathf.Sign(myRb.velocity.x)), transform.localScale.y);
    }

}
