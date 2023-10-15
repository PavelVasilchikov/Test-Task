using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private float posX, posY;
    public Joystick joystick;
    private Rigidbody2D rigidbody2D;
    public Camera camera;

    [SerializeField]
    public float leftLimit, rightLimit, topLimit, bottomLimit;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        posX = joystick.Horizontal * speed;
        posY = joystick.Vertical * speed;
        rigidbody2D.velocity = new Vector2(posX, posY);
        camera.transform.position = new Vector2(Math.Clamp(transform.position.x, leftLimit, rightLimit), Math.Clamp(transform.position.y, bottomLimit, topLimit));
    }


}
