using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class GameController : MonoBehaviour
{
    public int xBound;
    public int yBound;

    public GameObject panel;

    public int maxSize;
    public int currentSize;

    public int point;
    public int highscore;

    public GameObject snakePrefab;
    public Snake head;
    public Snake tail;
    public string dir;
    public Vector2 newPos;
    public Material[] material1;
    GameObject matinfo;
    public AudioSource sound1,sound2 ;

    public Text ScoreText ;
    public Text Times;
    public Text snakeLength;
    float time = 0;
    float time1 = 0.1f;

    string foodName;
    int mat = BeforeGameMain.mat;

    string[] ways;
    KeyCode[] ways1 = new KeyCode[4];


    // Use this for initialization
    void Start()
    {
        matinfo = GameObject.Find("BeforeGameController") as GameObject;

        snakePrefab.GetComponent<Renderer>().material = material1[mat - 1];
        head.GetComponent<Renderer>().material = material1[mat - 1];
        tail.GetComponent<Renderer>().material = material1[mat - 1];
        if (matinfo != null)
            Destroy(matinfo);

        string line = File.ReadAllText("C:/users/" + Environment.UserName + "/documents/SnakeGame/sterring.data");
        ways = line.Split(',');
        for (int i = 0; i < 4; i++)
        {
            ways1[i] = (KeyCode)Enum.Parse(typeof(KeyCode), ways[i]);
        }

        string line1 = File.ReadAllText("C:/users/" + Environment.UserName + "/documents/SnakeGame/audio.data");
        string[] entries = line1.Split(',');
        sound1.volume = float.Parse(entries[1]);
        sound2.volume = float.Parse(entries[1]);


        panel.SetActive(false);
        InvokeRepeating("TimerInvoke", 0.1f, time1);
        highscore = 0;

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChanDir();


        if (point >= highscore) 
        highscore = point;
        if(IsInvoking("TimerInvoke"))
        time += Time.deltaTime;
        Times.text = Convert.ToInt32(time).ToString();

    }

    void TimerInvoke()
    {
        Movement();
        if (currentSize >= maxSize)
        {
            TailFunction();
        }
        else
        {
            currentSize++;
        }
        

        snakeLength.text = maxSize.ToString();
        wrap();
    }

    void Movement()
    {
        GameObject temp;
        newPos = head.transform.position;
        switch (dir)
        {
            case "w":
                newPos = new Vector2(newPos.x, newPos.y + 1);
                break;
            case "s":
                newPos = new Vector2(newPos.x, newPos.y - 1);
                break;
            case "a":
                newPos = new Vector2(newPos.x - 1, newPos.y);
                break;
            case "d":
                newPos = new Vector2(newPos.x + 1, newPos.y);
                break;
        }

        temp = Instantiate(snakePrefab, newPos, transform.rotation);
        head.SetNext(temp.GetComponent<Snake>());
        head = temp.GetComponent<Snake>();
        sound1.Play();
        return;
    }

    void ChanDir()
    {
        if (Input.GetKey(ways1[0]) || Input.GetKey(ways1[1]) || Input.GetKey(ways1[2]) || Input.GetKey(ways1[3]))
        {

            if (dir != "s" && Input.GetKeyDown(ways1[0]))
                if (Input.GetKey(ways1[2]) ==false && Input.GetKey(ways1[3]) == false)
            {
                dir = "w";
            }

            if (dir != "d" && Input.GetKeyDown(ways1[2]) )
                if (Input.GetKey(ways1[1]) == false && Input.GetKey(ways1[0]) == false)
                {
                    dir = "a";
                }
            if (dir != "w" && Input.GetKeyDown(ways1[1]) )
                if (Input.GetKey(ways1[2]) == false && Input.GetKey(ways1[3]) == false)
                {
                     dir = "s";
                }
            if (dir != "a" && Input.GetKeyDown(ways1[3]) )
                if (Input.GetKey(ways1[1]) == false && Input.GetKey(ways1[0]) == false)
                {
                    dir = "d";
                }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            if (panel.activeSelf == false)
            {
                panel.SetActive(true);
                if (IsInvoking() == true)
                    CancelInvoke();
            }
            else
            {
                onCancel();
            }
        }
    }

    public void onCancel()
    {
        Cursor.visible = false;
        if (panel.activeSelf == true)
        {
            panel.SetActive(false);
            if (IsInvoking() == false)
                InvokeRepeating("TimerInvoke", 0.1f, time1);
        }
    }

    void TailFunction()
    {
        Snake tempSnake = tail;
        tail = tail.Getnext();
        tempSnake.RemoveTail();
    }

    void OnEnable()
    {
        
        Snake.hit += hit;
    }

    void OnDisable()
    {
        Snake.hit -= hit;
    }
    
    public void hit (string whatwasthat)
    {
        
       if (whatwasthat == "Food_I(Clone)")      
        {
            
            maxSize++;
            point++;
            scoreAction();
        }

        if (whatwasthat == "Snake_Body(Clone)")
        {
            CancelInvoke("TimerInvoke");
            Exit();
        }

        if (whatwasthat == "Food_II(Clone)")
        {
            maxSize--;
            TailFunction();
            point++;
            scoreAction();
        }
        if (whatwasthat == "Food_III(Clone)")
        {
            CancelInvoke();
            time1 -= 0.02f;
            InvokeRepeating("TimerInvoke", 0.1f, time1);
            point+=5;
            scoreAction();
        }
        if (whatwasthat == "Food_IV(Clone)")
        {
            CancelInvoke();
            time1 += 0.02f;
            InvokeRepeating("TimerInvoke", 0.1f, time1);
            point+=2;
            scoreAction();
        }
        if (whatwasthat == "Food_V(Clone)")
        {
            point = point - 30;
            if (point < 0)
                point = 0;
            scoreAction();
        }
        if (whatwasthat == "Food_VI(Clone)")
        {
            point += 1;
            scoreAction();
        }

    }

    void scoreAction()
    {
        ScoreText.text = point.ToString();
        sound2.Play();
    }

    public void Exit()
    {
        SaveStats();
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void SaveStats()
    {
       File.WriteAllText("C://users/" + Environment.UserName + "/documents/SnakeGame/snake.data", highscore + "," + (int)time );
    }

    void wrap()
    {
        if(dir=="w" && newPos.y>=12.5 && dir !="s")
        {
            head.transform.position = new Vector2(head.transform.position.x, -(head.transform.position.y - 1));
        }
        if (dir == "s" && newPos.y <= -12.5 && dir != "w")
        {
            head.transform.position = new Vector2(head.transform.position.x, -(head.transform.position.y + 1));
        }
        if (dir == "a" && newPos.x <= -16.5 && dir != "d")
        {
            head.transform.position = new Vector2(-(head.transform.position.x+1), head.transform.position.y);
        }
        if (dir == "d" && newPos.x >= 16.5 && dir != "a")
        {
            head.transform.position = new Vector2(-(head.transform.position.x - 1), head.transform.position.y);
        }
    }

    

}
