using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    private Rigidbody rigid_body;
    public float jump_force = 100;
    public bool isGrounded;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rigid_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.5f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetKey("space") && isGrounded || Input.GetKey("w") && isGrounded)
        {
            rigid_body.AddForce(Vector3.up * jump_force);
        }
    }

    private void Move()
    {
        Vector3 temp;
        temp = transform.position;
        if (Input.GetKey("a"))
        {
            temp += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey("d"))
        {
            temp += Vector3.right * Time.deltaTime * speed;
        }
        transform.position = temp;
    }
}
