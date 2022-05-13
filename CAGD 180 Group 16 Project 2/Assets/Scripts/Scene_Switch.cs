using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Switch : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    public GameObject heavyBullet; 

    public static Scene_Switch instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(bullet);
        DontDestroyOnLoad(heavyBullet);
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
