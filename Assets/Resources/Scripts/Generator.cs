using UnityEngine;

public class Generator : MonoBehaviour
{
    public Vector3 startGeneratedPosition;
    public Vector3 endGeneratedPosition;

    public Vector3 backgroundCenterPosition;
    public Vector3 boundSize;

    Vector3 newFoodPosition;

    GameObject food1;
    GameObject food2;
    GameObject food3;
    GameObject food4;
    GameObject food5;
    GameObject food6;

    int i = 0, j = 0;
    float time = 0, time1 = 0;


    // Use this for initialization
    void Start()
    {
        backgroundCenterPosition = (GameObject.Find("Background") as GameObject).gameObject.transform.position;
        backgroundCenterPosition.x = backgroundCenterPosition.x - 1.5f;
        backgroundCenterPosition.y = backgroundCenterPosition.y - 1.5f;
        boundSize = (GameObject.Find("Background") as GameObject).GetComponent<Collider>().bounds.size;

        startGeneratedPosition = new Vector3(backgroundCenterPosition.x - (boundSize.x / 2), (backgroundCenterPosition.y - (boundSize.y / 2) * -1));
        endGeneratedPosition = new Vector3(backgroundCenterPosition.x + (boundSize.x / 2), (backgroundCenterPosition.y + (boundSize.y / 2) * -1));
    }

    // Update is called once per frame
    void Update()
    {
        food1 = GameObject.Find("Food_I(Clone)") as GameObject;
        food2 = GameObject.Find("Food_II(Clone)") as GameObject;
        food3 = GameObject.Find("Food_III(Clone)") as GameObject;
        food4 = GameObject.Find("Food_IV(Clone)") as GameObject;
        food5 = GameObject.Find("Food_V(Clone)") as GameObject;
        food6 = GameObject.Find("Food_VI(Clone)") as GameObject;
        time += Time.deltaTime;
        time1 += Time.deltaTime;

        check1();
        if (i >= 5)
        {
            check2();
            i = 0;
        }

        if (j >= 11)
        {
            check3();
            j = 0;
        }

        if ((int)time >= 35 && food4 == null)
        {
            FoodGenerate4();
            time = 0;
        }
        if ((int)time >= 15 && food4 != null)
        {
            check4();
            Destroy(food4);
            time = 0;
        }

        if ((int)time1 >= 30 && food5 == null)
        {
            FoodGenerate5();
            time1 = 0;
        }
        if ((int)time1 >= 60 && food5 != null)
        {
            check5();
            Destroy(food5);
            time1 = 0;
        }
        //if (Input.GetKeyDown(KeyCode.J))
        //    check6();
    }

    public void vectorGenerating()
    {
         newFoodPosition = new Vector3(Random.Range((int)startGeneratedPosition.x, (int)endGeneratedPosition.x), Random.Range((int)startGeneratedPosition.y, (int)endGeneratedPosition.y));

    }

    void FoodGenerate1()
    {
        vectorGenerating();
        Instantiate(Resources.Load("Food_I"), newFoodPosition, Quaternion.identity);
    }

    void FoodGenerate2()
    {
        vectorGenerating();
        Instantiate(Resources.Load("Food_II"), newFoodPosition, Quaternion.identity);
    }

    void FoodGenerate3()
    {
        vectorGenerating();
        Instantiate(Resources.Load("Food_III"), newFoodPosition, Quaternion.identity);
    }

    void FoodGenerate4()
    {
        vectorGenerating();
        Instantiate(Resources.Load("Food_IV"), newFoodPosition, Quaternion.identity);
    }

    void FoodGenerate5()
    {
        vectorGenerating();
        Instantiate(Resources.Load("Food_V"), newFoodPosition, Quaternion.identity);
    }

    void FoodGenerate6()
    {
        vectorGenerating();
        Instantiate(Resources.Load("Food_VI"), newFoodPosition, Quaternion.identity);
    }

    void check1()
    {
        food1 = GameObject.Find("Food_I(Clone)") as GameObject;
        if (food1 != null)
        {
            return;
        }
        else
        {
            FoodGenerate1();
            i++;
            j++;

        }
    }

    void check2()
    {
        food2 = GameObject.Find("Food_II(Clone)") as GameObject;

        if (food2 != null)
        {
            return;
        }
        else
        {
            FoodGenerate2();
        }
    }

    void check3()
    {
        food3 = GameObject.Find("Food_III(Clone)") as GameObject;

        if (food3 != null)
        {
            return;
        }
        else
        {
            FoodGenerate3();

        }
    }

    void check4()
    {
        food4 = GameObject.Find("Food_IV(Clone)") as GameObject;

        if (food4 != null)
        {
            return;
        }
        else
        {
            FoodGenerate4();
            time = 0;
        }
    }

    void check5()
    {

        food5 = GameObject.Find("Food_V(Clone)") as GameObject;

        if (food5 != null)
        {
            return;
        }
        else
        {
            FoodGenerate5();
            time1 = 0;
        }
    }

    void check6()
    {
        food6 = GameObject.Find("Food_VI(Clone)") as GameObject;
        
          {
            if (food6 != null)
            {
                Destroy(GameObject.Find("Food_VI(Clone)") as GameObject);
            }
            else
            {
                FoodGenerate6();
   
            }
        }
    }
}