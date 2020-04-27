﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    int MoveTimer;
    Vector3 pos;
    public bool Pressed;
    public bool AutomaticEnabled;

    //Creates dices to be linked for throwing
    [SerializeField] private MarketDiceRoll MarketDR;
    [SerializeField] private NumberDiceRoll NumberDR;
    [SerializeField] private SecondMarketDice SecondMD;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        //Checks if the mouse is pressed on the button
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.CompareTag("DiceButton"))
                {
                    Pressed = true;

                    //Sets a boolean on so that the bluedice detection can start
                    AutomaticEnabled = true;
                }
            }
        }

        ButtonDown();
        transform.position = pos;
    }

    void Throw()
    {
        //Executes each dices script for throwing the die
        MarketDR.Throw();
        NumberDR.Throw();
        SecondMD.Throw();
    }

    void ButtonDown()
    {
        //Moves the button down and up to give a "pressed" effect
        if (Pressed)
        {
            MoveTimer++;
            if(MoveTimer == 1)
            {
                Throw();
            }
            if (MoveTimer < 53)
            {
                pos.y -= 0.008f;
            }
            else if (MoveTimer < 105)
            {
                pos.y += 0.008f;
            }
            else
            {
                Pressed = false;
                MoveTimer = 0;
            }
        }
    }
}
