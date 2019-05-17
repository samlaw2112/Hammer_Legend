using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    LevelController levelController;
    Player player;
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
        // Score shouldn't go down if player goes backwards
        // Start score increase after some distance reached
        // Actions get more points - hit some target in the environment?
        score = Mathf.RoundToInt(player.transform.position.x);
    }
}
