using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class SettingsController : MonoBehaviour {

    public Slider slider1,slider2;
    public Text text1, text2;
    public GameObject panel1, panel2;
    GameObject music;

    Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text up, down, left, right;
    GameObject CurrentKey;
    private Color32 normal = new Color32(123, 245, 114, 255);
    private Color32 selected = new Color32(236, 116, 36, 255);

    // Use this for initialization
    void Start () {

        string line = File.ReadAllText("C://users/"+Environment.UserName+"/documents/SnakeGame/audio.data");
        string[] entries = line.Split(',');
        slider1.value = float.Parse(entries[0]);
        slider2.value = float.Parse(entries[1]);
        text1.text = ((int)(slider1.value * 100)).ToString();
        text2.text = ((int)(slider2.value * 2000)).ToString();

        string line1 = File.ReadAllText("C://users/" + Environment.UserName + "/documents/SnakeGame/sterring.data");
        string[] entries1 = line1.Split(',');
       
        keys.Add("Up", (KeyCode)Enum.Parse(typeof(KeyCode), entries1[0]));
        keys.Add("Down", (KeyCode)Enum.Parse(typeof(KeyCode), entries1[1]));
        keys.Add("Left", (KeyCode)Enum.Parse(typeof(KeyCode), entries1[2]));
        keys.Add("Right", (KeyCode)Enum.Parse(typeof(KeyCode), entries1[3]));

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();

        seekNames(up);
        seekNames(down);
        seekNames(left);
        seekNames(right);


        panel1.SetActive(true);
        panel2.SetActive(false);
	}

    void seekNames(Text nazwa)
    {
        if(nazwa.text == "UpArrow")
        {
            nazwa.text = "Strzałka Góra";
        }
        if (nazwa.text == "DownArrow")
        {
            nazwa.text = "Strzałka Dół";
        }
        if (nazwa.text == "LeftArrow")
        {
            nazwa.text = "Strzałka Lewo";
        }
        if (nazwa.text == "RightArrow")
        {
            nazwa.text = "Strzałka Prawo";
        }
        if (nazwa.text == "Return")
        {
            nazwa.text = "Enter";
        }
    }


    public void slider1Change()
    {
        text1.text = ((int)(slider1.value * 100)).ToString();
        music = GameObject.Find("Music");
        music.GetComponentInChildren<AudioSource>().volume = slider1.value;

    }

    public void slider2Change()
    {
        text2.text = ((int)(slider2.value * 2000)).ToString();
    }

    public void SaveStats()
    {
        File.WriteAllText("C://users/" + Environment.UserName + "/documents/SnakeGame/audio.data", slider1.value+","+slider2.value);
        File.WriteAllText("C://users/" + Environment.UserName + "/documents/SnakeGame/sterring.data", keys["Up"].ToString()+","+ keys["Down"].ToString()+","+ keys["Left"].ToString() + ","+ keys["Right"].ToString());
    }

    public void butnToMenu()
    {
        SaveStats();
        SceneManager.LoadScene(0);
    }
   

    public void butnAudio()
    {
            panel2.SetActive(false);
            panel1.SetActive(true);

    }

    public void butnControl()
    {    
        panel2.SetActive(true);
        panel1.SetActive(false);

    }

    private void OnGUI()
    {
        
        if (CurrentKey != null)
        {
            Event e = Event.current;
            if(e.isKey)
            {
                keys[CurrentKey.name] = e.keyCode;
                CurrentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                seekNames(CurrentKey.transform.GetChild(0).GetComponent<Text>());
                CurrentKey.GetComponent<Image>().color = normal;
                CurrentKey = null;
            }
        }
    }
    public void onSetingKeys(GameObject current)
    {
        if(CurrentKey != null)
        {
            CurrentKey.GetComponent<Image>().color = normal;
        }
        CurrentKey = current;
        CurrentKey.GetComponent<Image>().color = selected;

    } 
}
