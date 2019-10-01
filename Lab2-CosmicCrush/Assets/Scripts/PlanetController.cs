using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    //Direction and speed at which the planet will travel.
    public Vector3 velocity = Vector3.zero;

    //Speed at which the planet moves.
    public float speed = 0.1f;

    //Rigidbody of the planet.
    public Rigidbody2D rb2d;

    //Player object.
    public GameObject player;

    //Check if the player is being attracted by the planet.
    bool isPlayerAttracted;

    //The mass amount player will gain from eating this planet.
    public float massGain = 0.1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        velocity = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100));
        rb2d.AddForce(velocity.normalized * speed);
    }

    void FixedUpdate()
    {
        if(isPlayerAttracted)
        {
            if(rb2d.mass > player.GetComponent<Rigidbody2D>().mass)
            {
                Vector3 VectorToPlanet = (transform.position - player.transform.position).normalized;
                VectorToPlanet *= (rb2d.mass - player.GetComponent<Rigidbody2D>().mass) * 5;

                player.GetComponent<Rigidbody2D>().AddForce(VectorToPlanet);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D t_colliderInfo)
    {
        if (t_colliderInfo.gameObject == player)
        {
            isPlayerAttracted = true;
            Debug.Log("Player is attracted");
        }
    }

    private void OnTriggerExit2D(Collider2D t_colliderInfo)
    {
        if (t_colliderInfo.gameObject == player)
        {
            isPlayerAttracted = false;
        }
    }
}
