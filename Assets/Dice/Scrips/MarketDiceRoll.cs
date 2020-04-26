﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketDiceRoll : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Throw()
    {
        diceVelocity = rb.velocity;

        float dirX = Random.Range(0, 1000);
        float dirY = Random.Range(0, 1000);
        float dirZ = Random.Range(0, 1000);
        transform.position = new Vector3(0, 5, 8);
        transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * 500);
        rb.AddTorque(dirX, dirY, dirZ);

    }
}
