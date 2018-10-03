﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : GameplayObject {

    public BulletObject m_BulletObjectPrefab;
    public Transform m_BulletSpawnPoint;
    public Transform m_BulletStorage;

    private const float k_rotateSpeed = 1.5f;
    private const float k_fireRateLimit = 0.1f;
    private float m_fireRateTimer;
    private Vector3 m_rotationYAxis = new Vector3(0, 0, 0);


    // Use this for initialization
    void Start ()
    {
        base.HandleBirth();
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleMovement();
	}

    protected override void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_rigidBody.AddForce(transform.forward * m_MovementForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_rigidBody.AddForce(-transform.forward * m_MovementForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Rotate(1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Rotate(-1);
        }

        if (Input.GetMouseButton(0))
        {
            if (Time.time - m_fireRateTimer > k_fireRateLimit)
            {
                m_fireRateTimer = Time.time;
                Instantiate(m_BulletObjectPrefab, m_BulletSpawnPoint.position, m_BulletSpawnPoint.rotation, m_BulletStorage);
            }
        }
    }

    private void Rotate(float y)
    {
        if (y != 0)
        {
            m_rotationYAxis.Set(0f, y, 0f);
            m_rotationYAxis = m_rotationYAxis.normalized * k_rotateSpeed;
            Quaternion deltaRotation = Quaternion.Euler(m_rotationYAxis);
            m_rigidBody.MoveRotation(transform.rotation * deltaRotation);
        }
    }

    protected override void HandleDeath()
    {
        throw new System.NotImplementedException();
    }
}