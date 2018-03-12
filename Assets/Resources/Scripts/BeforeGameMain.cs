using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeforeGameMain : MonoBehaviour {

    
    public static int mat = 1;

    GameObject matinfo;
    public Sprite[] imgScen;
    public Sprite[] imgMats;
    public Image image1,image2;
    int scen = 1;

	// Use this for initialization
	void Start () {
        image1.sprite = imgScen[0];
        image2.sprite = imgMats[0];

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toMenu()
    {
        matinfo = GameObject.Find("BeforeGameController") as GameObject;
        if (matinfo != null)
            Destroy(matinfo);
        SceneManager.LoadScene(0);
    }

    public void play()
    {
        if (scen == 1)
            SceneManager.LoadScene(4);
        if (scen == 2)
            SceneManager.LoadScene(5);
        if (scen == 3)
            SceneManager.LoadScene(6);

    }

    public void nextScene()
    {
        scen++;
        if (scen > 3)
            scen = 3;
        image1.sprite = imgScen[scen - 1];
    }

    public void prevScene()
    {
        scen--;
        if (scen < 1)
            scen = 1;
        image1.sprite = imgScen[scen - 1];

    }

    public void nextMaterial()
    {
        mat++;
        if (mat > 3)
            mat = 3;
        image2.sprite = imgMats[mat - 1];
    }

    public void prevMaterial()
    {
        mat--;
        if (mat < 1)
            mat = 1;
        image2.sprite = imgMats[mat - 1];
    }
}
