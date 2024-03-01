using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lvl_2 : MonoBehaviour
{
    [SerializeField]
    private bool button1_IsPressed;
    [SerializeField]
    private bool button2_IsPressed;

    [SerializeField]
    private GameObject portal;

    void Start()
    {
        button1_IsPressed = false;
        button2_IsPressed = false;
    }

        
    void Update()
    {
        LvlSolution();
    }

    void LvlSolution()
    {
        portal.gameObject.SetActive(button1_IsPressed && button2_IsPressed);
    }

    public void Button1Press()
    {
        button1_IsPressed = true;
    }

    public void Button1Release()
    {
        button1_IsPressed = false;
    }

    public void Button2Press()
    {
        button2_IsPressed = true;
    }

    public void Button2Release()
    {
        button2_IsPressed = false;
    }
}

