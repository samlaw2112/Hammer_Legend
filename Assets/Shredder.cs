using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Shreds player on enter and tells spawner to respawn the player
/// </summary>
public class Shredder : MonoBehaviour
{
    PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponentInParent<Player>();
        if (player)
        {
            playerController.DestroyPlayer();
        }
    }
}
