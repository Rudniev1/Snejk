using System;
using System.IO;
using UnityEngine;


public class MusicController : MonoBehaviour {

    GameObject[] music;

    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("Music");
        if (music.Length == 2)
        {
            Destroy(music[1]);
        }

        string line = File.ReadAllText("C:/users/" + Environment.UserName + "/documents/SnakeGame/audio.data");
        string[] entries = line.Split(',');
        music[0].GetComponentInChildren<AudioSource>().volume = float.Parse(entries[0]);

    }
   


}
