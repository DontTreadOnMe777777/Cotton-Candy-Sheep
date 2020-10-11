﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    public float speed;
    public Transform wolf;
    private Rigidbody rb;
    private Vector3 movement;
    public bool followingWolf = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followingWolf)
            FollowWolf();
    }

    void FixedUpdate()
    {
        if (followingWolf)
            MoveSheep(movement);
    }

    private void MoveSheep(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    void FollowWolf()
    {
        Vector3 direction = wolf.position - transform.position;
        direction.Normalize();
        movement = direction;
    }


}