using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for detecting collisions with platforms and propelling the player forward
/// </summary>

public class HammerController : MonoBehaviour
{
    [Tooltip("Scalar applied to calculation of player launch from hammer hit on platform.")]
    public float launchSpeed;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming there will only ever be one play
        player = FindObjectOfType<PlayerController>();
        Debug.Log("Found player: " + player);
    }

    // If hammer collides with a platform propel the player forwards
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hammer detecting collision");

        if (collision.collider.gameObject.GetComponent<Platform>())
        {
            //TODO Improve calculation of impact angle - currently always fly orthogonal to platform edge

            // Move the player forwards along normal of the collision
            player.GetComponent<Rigidbody2D>().velocity = collision.contacts[0].normal * launchSpeed;

        }

    }
}
