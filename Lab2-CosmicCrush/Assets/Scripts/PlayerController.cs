﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//@Author Krystian Sarowski ft. Kevin Andersen


public class PlayerController : MonoBehaviour
{
    //Direction and speed at which the player will travel.
    Vector3 velocity = Vector3.zero;

    //The position of the mouse on screen.
    Vector3 mousePos = Vector3.zero;

    //Speed at which the player moves.
    public float speed = 0.1f;

    //Checks if the player is moving or not.
    bool moving = false;

    //Rigidbody of the player.
    Rigidbody2D rb2d;

    //Sprite Renderer of the player.
    SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        spriteRender = GetComponent<SpriteRenderer>();

        spriteRender.sprite = Resources.Load<Sprite>("Sprites/planet4");
    }

    // Update is called once per frame
    void Update()
    {
        //Convert screen mouse position to world position.
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //We do not want to change the z position so we set it to the one of the player.
        mousePos.z = transform.position.z;
        velocity = (mousePos - transform.position).normalized;

        if (Input.GetKey(KeyCode.Space))
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }

    void FixedUpdate()
    {
        if (moving)
        {
            rb2d.AddForce(velocity * speed);
        }
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Planet")
        {
            if(rb2d.mass > coll.gameObject.GetComponent<Rigidbody2D>().mass)
            {
                MassGrowth(coll.gameObject.GetComponent<PlanetController>().massGain);
                Destroy(coll.gameObject);

            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    //Increases the players mass based on the passed in massGain.
    //It then resizes the player to match the mass and changes the player sprite at certain mass barriers.
    void MassGrowth(float massGain)
    {
        rb2d.mass += massGain;
        transform.localScale = new Vector3(rb2d.mass, rb2d.mass, 0.0f);

        if(rb2d.mass >= 0.45f && rb2d.mass < 1.0f)
        {
            spriteRender.sprite = Resources.Load<Sprite>("Sprites/planet3");
        }

        else if(rb2d.mass >= 1.0f && rb2d.mass < 2.0f)
        {
            spriteRender.sprite = Resources.Load<Sprite>("Sprites/planet2");
        }

        else if(rb2d.mass >= 2.0f)
        {
            spriteRender.sprite = Resources.Load<Sprite>("Sprites/planet1");
        }
    }
    
}

