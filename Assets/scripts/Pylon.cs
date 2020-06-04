﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pylon : MonoBehaviour
{

    GameObject selected1;

    void Update()
    {
        // Checked of de linker muisknop ingedrukt is
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            int layerMask1 = LayerMask.GetMask("Water");

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layerMask1))
            {

                //Checked of en welke pylon geselecteerd word
                if (hit.collider.CompareTag("Pylon"))
                {
                    
                    //Zet de player omhoog om aan te geven dat de pylon is aangeklikt
                    if (selected1 == null)
                    {

                        selected1 = hit.collider.gameObject;
                        selected1.transform.position = new Vector3(selected1.transform.position.x, selected1.transform.position.y + 0.1f, selected1.transform.position.z);
                        selected1.GetComponent<Rigidbody>().useGravity = false;

                    }
                    else
                    {
                        selected1.GetComponent<Rigidbody>().useGravity = true;
                        selected1 = null;
                    }
                }

                //Verplaatst de pylon naar het gekozen level
                if (hit.collider.CompareTag("playerLevel"))
                {
                    if (selected1 != null)
                    {
                        selected1.transform.position = new Vector3(hit.collider.transform.position.x, selected1.transform.position.y , selected1.transform.position.z);
                        selected1.GetComponent<Rigidbody>().useGravity = true;
                        selected1 = null;
                    }
                }
            }
        }

        //deselecteerd de gekozen pylon
        if (Input.GetMouseButtonDown(1)) selected1 = null;

    }
}