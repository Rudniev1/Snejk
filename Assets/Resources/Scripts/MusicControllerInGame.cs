using System;
using System.IO;
using UnityEngine;

public class MusicControllerInGame : MonoBehaviour {

    GameObject music;
	// Use this for initialization
	void Start () {
        string line = File.ReadAllText("C:/users/" + Environment.UserName + "/documents/SnakeGame/audio.data");
        string[] entries = line.Split(',');

        music = GameObject.FindGameObjectWithTag("Music");
        if (music != null)
        {
            Destroy(music);
        }

        GetComponent<AudioSource>().volume = float.Parse(entries[0]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
