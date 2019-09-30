using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//@Author Krystian Sarowski ft. Kevin Andersen


public class PlayerController : MonoBehaviour
{
    //Direction and speed at which the player will travel.
    Vector3 velocity = Vector3.zero;

    Vector3 mousePos = Vector3.zero;

    //Speed at which the player moves.
    public float speed = 0.1f;

    //Checks if the player is moving or not.
    bool moving = false;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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

        //increase mass and scale of player when players size is > the planets
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Planet")
        {
            if(rb2d.mass > coll.gameObject.GetComponent<Rigidbody2D>().mass)
            {
                rb2d.mass += coll.gameObject.GetComponent<PlanetController>().massGain;
                transform.localScale = new Vector3(rb2d.mass, rb2d.mass, 0.0f);
                Destroy(coll.gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    
}

