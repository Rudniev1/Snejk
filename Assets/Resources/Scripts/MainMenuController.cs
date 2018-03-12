using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Directory.CreateDirectory("C:/users/" + Environment.UserName + "/documents/SnakeGame");
        if(!File.Exists("C:/users/" + Environment.UserName + "/documents/SnakeGame/sterring.data"))
        File.AppendAllText("C:/users/" + Environment.UserName + "/documents/SnakeGame/sterring.data", "UpArrow,DownArrow,LeftArrow,RightArrow");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HS()
    {
        SceneManager.LoadScene(1);
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void BeforeGame()
    {
        SceneManager.LoadScene(2);
    }

    public void settings()
    {
        SceneManager.LoadScene(7);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
