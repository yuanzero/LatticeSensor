using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject[] objects;

    public bool on1;
    public bool on2;
    public bool on3;

    private void FixedUpdate()
    {
        if (on1)
        {
            ChangeObjectColorRed();
        }
        else
        {
            objects[0].GetComponent<Renderer>().material.color = Color.white;
            objects[2].GetComponent<Renderer>().material.color = Color.white;
        }

        if (on2)
        {
            ChangeObjectColorBlue();
        }
        else
        {
            objects[3].GetComponent<Renderer>().material.color = Color.white;
            objects[4].GetComponent<Renderer>().material.color = Color.white;
        }

        if (on3)
        {
            ChangeObjectColorGreen();
        }
        else
        {
            objects[1].GetComponent<Renderer>().material.color = Color.white;
            objects[5].GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void IniObjectColors()
    {

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void ChangeObjectColors()
    {
        Color[] colors = new Color[6];
        colors[0] = Color.red;
        colors[1] = Color.blue;
        colors[2] = Color.green;
        colors[3] = Color.yellow;
        colors[4] = Color.cyan;
        colors[5] = Color.magenta;

        for (int i = 0; i < objects.Length; i++)
        {

            objects[i].GetComponent<Renderer>().material.color = colors[i];
        }
    }

    public void ChangeObjectColorRed()
    {
        objects[0].GetComponent<Renderer>().material.color = Color.red;
        objects[2].GetComponent<Renderer>().material.color = Color.red;
    }

    public void ChangeObjectColorBlue()
    {
        objects[3].GetComponent<Renderer>().material.color = Color.blue;
        objects[4].GetComponent<Renderer>().material.color = Color.blue;
    }

    public void ChangeObjectColorGreen()
    {
        objects[1].GetComponent<Renderer>().material.color = Color.green;
        objects[5].GetComponent<Renderer>().material.color = Color.green;
    }


}
