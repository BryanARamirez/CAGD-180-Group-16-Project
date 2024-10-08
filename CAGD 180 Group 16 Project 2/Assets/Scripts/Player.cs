using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Worked on by Bryan Ramirez

public class Player : MonoBehaviour
{

    public float speed;

    private Rigidbody rigid_body;
    public float jump_force = 100;
    public bool isGrounded;
    private Vector3 startPos;

    public float maxHealth = 99;
    public float health;
    public float healingOrb;
    public Text healthText;
    public float damageAmount;

    public bool isFacingLeft;
    public GameObject goingLeft;
    public GameObject goingRight;

    float lastTime;
    public GameObject projectilePrefab;

    public GameObject heavyProjectilePrefab;
    public bool hasHeavyBullets;

    public int sceneNumber;

    public GameObject gameOverCamera;
    public GameObject gameOverRestart;
    public Text gameOverText;

    public float invincibilityLength;
    private float invincibilityCounter;

    // Start is called before the first frame update
    void Start()
    {
        //For allowing respawn after death
        startPos = transform.position;
        rigid_body = GetComponent<Rigidbody>();
        health = maxHealth;
        SetCountText();
        //To get the time from when the last bullet was shot so no spamming can happen.
        lastTime = Time.time;
        //At the start of the game the player should not have heavy bullets.
        hasHeavyBullets = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //To allow shooting.
        SpawnProjectile();
        //To not allow infinite jumping in the air while still allowing the player to jump with either "w" or "space"
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
        //This piece of code is to show on the player if they are facing left by making the right "gun" disappear and the left one appear.
        if (isFacingLeft == true)
        {
            goingLeft.gameObject.SetActive(true);
            goingRight.gameObject.SetActive(false);
        }
        //This piece of code is to show on the player if they are facing right by making the left "gun" disappear and the right one appear.
        if (isFacingLeft == false)
        {
            goingLeft.gameObject.SetActive(false);
            goingRight.gameObject.SetActive(true);
        }
        //To update what direction the player is currently facing.
        if (Input.GetKey("a"))
        {
            isFacingLeft = true;
        }
        if (Input.GetKey("d"))
        {
            isFacingLeft = false;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Room 1"))
        {
            sceneNumber = 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Room 2"))
        {
            sceneNumber = 2;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Room 7"))
        {
            sceneNumber = 3;
        }
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Activates Heavy Bullets
        if (other.gameObject.tag == "Heavy Bullet Pick Up")
        {
            hasHeavyBullets = true;
            other.gameObject.SetActive(false);
        }
        //Gives player 100 more max health while also full healing them.
        if (other.gameObject.tag == "Extra Health")
        {
            maxHealth = maxHealth + 100;
            health = maxHealth;
            other.gameObject.SetActive(false);
            SetCountText();
        }
        //Test dummy enemy to test health and damage
        if (other.gameObject.tag == "Dummy")
        {
            health = health - 5;
            SetCountText();
        }
        //Heals player according to whatever number the level designer wants.
        if (other.gameObject.tag == "Healing Orb")
        {
            health = health + healingOrb;
            if(health > maxHealth)
            {
                health = maxHealth;
            }
            other.gameObject.SetActive(false);
            SetCountText();
        }
        //Changes the players jump force and allows for higher jumps.
        if (other.gameObject.tag == "Jump Pick Up")
        {
            jump_force = 5;
            other.gameObject.SetActive(false);
        }
        if(other.tag == "Blue Scene Changer")
        {
            Scene_Switch.instance.switchScene(sceneNumber);
        }
        if (other.tag == "Red Scene Changer")
        {
            Scene_Switch.instance.switchScene(sceneNumber);
        }
        if (other.tag == "enemy")
        {
            damageAmount = 15;
            takeDamage();
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

    private void takeDamage()
    {
        if(invincibilityCounter <= 0)
        {
            health = health - damageAmount;
            if (health < 0)
            {
                health = 0;
            }
            StartCoroutine(Blink());
            invincibilityCounter = invincibilityLength;
            SetCountText();
            gameOver();
        }
    }

    private void gameOver()
    {
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
            gameOverCamera.gameObject.SetActive(true);
            gameOverRestart.gameObject.SetActive(true);
            gameOverText.text = "GAMEOVER";
        }
    }

    void SetCountText()
    {
        healthText.text = "HP:" + health.ToString();
    }

    public void SpawnProjectile()
    {
        //Checks to see if player has obtained the heavy bullet pick up. If false will send regular bullets. Otherwise it sends heavy bullets. 
        if(hasHeavyBullets == false)
        {
            //Bullets can be shot every half second to allow for 2 bullets a second.
            if (Input.GetKey("p") && (Time.time - lastTime > 0.5f))
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                if (projectile.GetComponent<Bullet>())
                {
                    projectile.GetComponent<Bullet>().goingLeft = goingLeft;
                }
                lastTime = Time.time;
            }
        }
        else
        {
            if (Input.GetKey("p") && (Time.time - lastTime > 0.5f))
            {
                GameObject projectileHeavy = Instantiate(heavyProjectilePrefab, transform.position, heavyProjectilePrefab.transform.rotation);
                if (projectileHeavy.GetComponent <Bullet>())
                {
                    projectileHeavy.GetComponent<Bullet>().goingLeft = goingLeft;
                }
                lastTime = Time.time;
            }
        }
    }
    public IEnumerator Blink()
    {
        for (int index = 0; index < 10; index++)
        {
            if (index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(.1f);
        }
        GetComponent<MeshRenderer>().enabled = true;
    }
}
