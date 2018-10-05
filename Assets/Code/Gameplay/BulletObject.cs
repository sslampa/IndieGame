﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObject : GameplayObject {

    private const int k_bulletLifespan = 1;

    public int m_BulletStrength = 100; // how much damage it does to an object
    public float m_FireForce;

    // Use this for initialization
    void Start ()
    {
        base.HandleBirth();

        m_rigidBody.AddForce(transform.forward * m_FireForce);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If the bullet has been alive for longer than its lifespan, kill it
        if (Time.time - m_timeOfBirth > k_bulletLifespan)
        {
            HandleDeath();
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        // If the bullet collides with anything, kill it
        HandleDeath();
    }

    protected override void HandleDeath()
    {
        base.HandleDeath();
    }
}
