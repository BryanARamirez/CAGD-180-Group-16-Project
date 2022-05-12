using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Worked on by Bryan Ramirez

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool goingLeft;

    public Player playerscript;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKey("a"))
        {
            goingLeft = true;
        }
        if (Input.GetKey("d"))
        {
            goingLeft = false;
        }
        if (playerscript.isFacingLeft == true)
        {
            goingLeft = true;
        }
        if (playerscript.isFacingLeft == false)
        {
            goingLeft = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (goingLeft == true)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        if (goingLeft == false)
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Dummy")
        {
            Destroy(this.gameObject);
        }
    }
}
