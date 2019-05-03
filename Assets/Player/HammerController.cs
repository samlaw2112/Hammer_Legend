using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for detecting collisions with platforms and propelling the player forward
/// </summary>

public class HammerController : MonoBehaviour
{
    [Tooltip("Scalar applied to calculation of player launch from hammer hit on platform.")]
    public float launchSpeedX;
    [Tooltip("Scalar applied to calculation of player launch from hammer hit on platform.")]
    public float launchSpeedY;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming there will only ever be one player
        player = FindObjectOfType<Player>();
    }

    // If hammer collides with a platform propel the player forwards
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hammer detecting collision");

        if (collision.collider.gameObject.GetComponent<Platform>())
        {
            // TODO Improve calculation of impact angle - currently always fly orthogonal to platform edge
            // TODO increase velocity for perfect impact

            // Only apply launch if hammer hits platform during swing
            if (player.GetInSwing())
            {
                // Move the player forwards along normal of the collision
                player.GetComponent<Rigidbody2D>().velocity += 
                    new Vector2(collision.contacts[0].normal.x * launchSpeedX, collision.contacts[0].normal.y * launchSpeedY) ;
            }

        }

    }
}
