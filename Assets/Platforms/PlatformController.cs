using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Responsible for spawning platform sets ahead of player.
/// </summary>
public class PlatformController: MonoBehaviour
{
    public GameObject[] platformSets;
    public GameObject startPlatformSet;

    private LevelController levelController;
    private Player player;
    // Spawn location for next spawn of set of platforms (in x)
    private float nextSpawnLocationX = 0f; // initialised to 0
    private float distanceBetweenSpawns = 660f; // Sensible default assuming all platform sets are the same length
    private float distanceBetweenCheckpointAndNextSpawn = 300f; // Sensible default
    // Checkpoint location, next platform set will be spawned when player crosses checkpoint
    private float checkpointLocation;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming only one level controller
        levelController = FindObjectOfType<LevelController>();

        // Set up for spawn of next set
        UpdateNextSpawnLocation();
        SetNextCheckpointLocation();
    }

    // Update is called once per frame
    void Update()
    {
        // If player passes checkpoint location
        if (player.transform.position.x > checkpointLocation)
        {
            // Spawn next set of platforms at the right location
            SpawnNextPlatformSet();

            // Set up for spawn of next set
            UpdateNextSpawnLocation();
            SetNextCheckpointLocation();
        }

    }

    
    public void SetPlayer(Player newPlayer)
    {
        player = newPlayer;
    }

    public void SpawnStartPlatforms()
    {
        // Spawn first set of platforms and start location (0,0,0)
        GameObject platformSet = Instantiate(startPlatformSet, Vector3.zero, Quaternion.identity);
        platformSet.transform.SetParent(this.transform);
    }

    // Destroy all platforms in game space so we can start a new game
    public void DestroyAllPlatforms()
    {
        foreach (Transform platformSet in transform)
        {
            Destroy(platformSet.gameObject);
        }
    }

    void SetNextCheckpointLocation()
    {
        checkpointLocation = nextSpawnLocationX - distanceBetweenCheckpointAndNextSpawn;
    }

    void SpawnNextPlatformSet()
    {
        // Choose a random set to spawn
        // TODO increase spawn rate of more difficult sets based on distance travelled
        int setToSpawn = Random.Range(0, platformSets.Length);
        // Spawn at next spawn location
        Vector3 spawnLocation = new Vector3(nextSpawnLocationX, 0, 0);
        GameObject platformSet = Instantiate(platformSets[setToSpawn], spawnLocation, Quaternion.identity);
        platformSet.transform.SetParent(this.transform);
    }

    void UpdateNextSpawnLocation()
    {
        nextSpawnLocationX += distanceBetweenSpawns;
    }
}
