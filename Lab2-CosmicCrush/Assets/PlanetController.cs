using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    //Direction and speed at which the planet will travel.
    public Vector3 velocity = Vector3.zero;

    //Speed at which the planet moves.
    public float speed = 0.1f;

    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100));
        rb2d.AddForce(velocity.normalized * speed);
    }
}
