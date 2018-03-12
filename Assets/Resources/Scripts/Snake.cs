using UnityEngine;
using System.Collections;
using System;

public class Snake : MonoBehaviour {

    private Snake next;
    static public Action<string> hit;

    public void SetNext(Snake IN)
    {
        next = IN;
    }

    public Snake Getnext()
    {
        return next;
    }

    public void RemoveTail()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (hit != null)
        {
            hit(other.transform.name);
        }
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
        }
       }

}
