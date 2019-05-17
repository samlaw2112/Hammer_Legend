using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideShredder : MonoBehaviour
{
    LevelController levelController;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponentInParent<Player>();
        Platform platform = collider.GetComponent<Platform>();
        if (player)
        {
            levelController.DestroyPlayerAndStartNewGame();
        }
        else if (platform)
        {
            Destroy(collider.gameObject);
        }

    }

}
