using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AfterMenuController : MonoBehaviour {
    public InputField text1;
    public Button button1;
    string fileName = "C://users/" + Environment.UserName + "/documents/SnakeGame/snake.data";
    

    // Use this for initialization
    void Start () {
        button1.enabled = false;
        EventSystem.current.SetSelectedGameObject(text1.gameObject, null);
        text1.OnPointerClick(new PointerEventData(EventSystem.current));
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    public void onEditText()
    {
        if (text1.text == null || text1.text == "")
            button1.enabled = false;
        else 
            button1.enabled = true;
    }

    public void toMenu()
    {
        Load();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    private void Load()
    {

        try
        {
            string line;

            StreamReader theReader = new StreamReader(fileName, System.Text.Encoding.Default);

            using (theReader)
            {
                // While there's lines left in the text file, do this:


                line = File.ReadAllLines(fileName).Last();

                    if (line != null)
                    {
                        
                        string[] entries = line.Split(',');
                        if (entries.Length > 0)
                        {
                            File.AppendAllText("C://users/" + Environment.UserName + "/documents/SnakeGame/snake1.data",  text1.text + ","+ entries[0] + "," + entries[1] + " \n");

                        }

                    }
                
                theReader.Close();
            }
        }

        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
        }
    }
}
