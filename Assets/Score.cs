using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    LevelController levelController;
    Player player;
    float playerMaxPos = 0; // Used to keep track of the maximum distance player has travelled (reset on death)
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        levelController = FindObjectOfType<LevelController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateScore();

        // Display score
        text.text = score.ToString();
    }

    // Called by level manager
    public void SetPlayer(Player newPlayer)
    {
        player = newPlayer;
    }

    void CalculateScore()
    {
        // TODO improve scoring
        // Start score increase after some distance reached
        // Actions get more points - hit some target in the environment?

        float currentPos = player.transform.position.x;
        // Only update score if player is at max distance travelled
        if (currentPos > playerMaxPos)
        {
            playerMaxPos = currentPos;
            score = Mathf.RoundToInt(playerMaxPos);
        }
    }

    public void ResetScore()
    {
        playerMaxPos = 0;
        score = 0;
    }
}
