using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Worked on by Bryan Ramirez.

public class Button : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject button;
    public GameObject gameOverCamera;
    public GameObject canvas;
    public void ButtonMoveScene(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void ButtonDisable()
    {
        button.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        gameOverCamera.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
    }
}
