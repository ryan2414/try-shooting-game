﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerController))]
public class Player : MonoBehaviour
{

    public float movespeed = 5;

    Camera viewCamera;

    PlayerController controller;

    
    void Start()
    {
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;

    }

   
    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moneVelocity = moveInput.normalized * movespeed;
        controller.Move(moneVelocity);

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast(ray,out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);

        }
    }
}
