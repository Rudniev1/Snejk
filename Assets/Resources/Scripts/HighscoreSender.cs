using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;
using System.Text;


public class HighscoreSender : MonoBehaviour {

    string fileName = "C://users/" + Environment.UserName + "/documents/SnakeGame/snake1.data";
    public Text pozycja;
    public Text nazwa;
    public Text wynik;
    public Text czas;


    int counter = 0;

    // Use this for initialization
    void Start () {
        Load();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Load()
    {

        try
        {
            string line;

            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            List<Wyniki> list = new List<Wyniki>();

            using (theReader)
            {
                // While there's lines left in the text file, do this:
                do
                {
                    line = theReader.ReadLine();
                    

                    if (line != null)
                    {

                        string[] entries = line.Split(',');

                        if (entries.Length > 0)
                        {
                            string n1, n2, n3;
                            n1 = entries[0];
                            n2 = entries[1];
                            n3 = entries[2];

                            list.Add(new Wyniki(n1, n2, n3));
                            
                        }

                    }
                }
                while (line != null);
                theReader.Close();
                
            }

              Sort(list);

           
                for (int i = 0; i < list.Count && i<=10; i++)
                {
                    counter++;
                    pozycja.text = pozycja.text + counter.ToString() + ".\n";
                    nazwa.text = nazwa.text + list[i].Nazwa + "\n";
                    wynik.text = wynik.text + list[i].Wynik + "\n";
                    czas.text = czas.text + list[i].Czas + "\n";
                }
        }

        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
            
        }


    }

    public void Sort(List<Wyniki> lista)
    {
        int n = lista.Count;
        Wyniki bufor = null;
        {
            for (int i = 0; i < n; i++)
                for (int j = 1; j < n - i; j++) //pętla wewnętrzna
                    if (Convert.ToInt32(lista[j - 1].Wynik) < Convert.ToInt32(lista[j].Wynik))
                    {
                        //zamiana miejscami
                        bufor = lista[j - 1];
                        lista[j - 1] = lista[j];
                        lista[j] = bufor;
                    }
        }
    }

    public void resetStats()
    {
        File.Delete("C://users/" + Environment.UserName + "/documents/SnakeGame/snake1.data");

        pozycja.text = null;
        nazwa.text = null;
        wynik.text = null;
        czas.text = null; 
    }

}

public class Wyniki
{
    private string nazwa;
    private string wynik;
    private string czas;

    public Wyniki(string n, string w, string c)
    {
        nazwa = n;
        wynik = w;
        czas = c;
    }

    public string Nazwa
    {
        get { return nazwa; }
        set
        {
            nazwa = value;
        }
    }

    public string Wynik
    {
        get { return wynik; }
        set
        {
            wynik = value;
        }
    }

    public string Czas
    {
        get { return czas; }
        set
        {
            czas = value;
        }
    }
}