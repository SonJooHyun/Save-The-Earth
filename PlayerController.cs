using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 5;

    int position2 = 2;

    private bool isright = true;
    private bool isleft = true;

    void Start()
    {

    }

    void Update()
    {
        if (position2 < 1)
        {
            isright = true;
            isleft = false;
        }
        if (position2 > 3)
        {
            isright = false;
            isleft = true;
        }
        if (position2 == 2)
        {
            isright = true;
            isleft = true;
        }
    }

    public void LButtonDown()
    {
        if (isleft == true)
        {
            transform.position += new Vector3(-3, 0, 0);
            position2--;
            isleft = false;
        }
    }

    public void RButtonDown()
    {
        if (isright == true)
        {
            transform.position += new Vector3(3, 0, 0);
            position2 ++;
            isright = false;
        }
    }
}
