using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Shreds player on enter and tells spawner to respawn the player
/// </summary>
public class Shredder : MonoBehaviour
{
    LevelController levelController;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponentInParent<Player>();
        if (player)
        {
            levelController.DestroyPlayer();
        }
    }
}
