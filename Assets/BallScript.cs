﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float radio = 0.5f;
    [SerializeField] private Vector3 speed;
    private float paredHorizontal = 5f;
    private float paredVertical = 9.5f;
    private Vector2 _wallLocation;
    private float paletaLocation = 8.5f;
    private Brick[] _bricks;
    private Slider _slider;
    void Start()
    {
    }

    void Update()
    {
        CollisionCheck();
        BrickDetection();
        Move();
    }

    public void AssignProperties(Vector2 wallLocation, Brick[] bricks, Slider slider)
    {
        _wallLocation = wallLocation;
        _bricks = bricks;
        _slider = slider;
    }
    void BrickDetection()
    {
        foreach (Brick brick in _bricks)
        {
            if (brick.gameObject.activeInHierarchy)
            {
                if (BrickCollisionCheck(brick))
                {
                    if (brick.isBreakable)
                    {
                        brick.gameObject.SetActive(false);
                    }
                }
            }
    
        }
    }
    

    void CollisionCheck()
    {
        if (transform.position.x - radio <= -_wallLocation.x || transform.position.x + radio >= _wallLocation.x)
        {
            speed.x = -speed.x;
        }

        if (transform.position.y - radio <= -_wallLocation.y ||transform.position.y + radio >= _wallLocation.y)
        {
            speed.y = -speed.y;
        }

        if (transform.position.y - radio <= _slider.transform.position.y)
        {
            if (transform.position.x + radio <= _slider.transform.position.x - _slider.transform.localScale.x / 2) // Si toco la mitad del lado izquierdo (negativo) me voy para x en el lado izquierdo
            {
                speed.x = Math.Abs(speed.x) * -1;
            }
            if (transform.position.x + radio >= _slider.transform.position.x  + _slider.transform.localScale.x / 2)
            {
                speed.x = Math.Abs(speed.x);
            }
            speed.y = Math.Abs(speed.y);
        }
    }

    bool BrickCollisionCheck(Brick brick)
    {
        if (Math.Abs(transform.position.x +radio - brick.transform.position.x) < 0.5f && Math.Abs(transform.position.y +radio - brick.transform.position.y) < 0.5f)
        {
            speed = -speed;
            return true;

        }

        return false;
    }
    void Move()
    {
        transform.position += speed  * Time.deltaTime;
    }
    
}