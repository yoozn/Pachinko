using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    private int highScore1_1;
    private int highScore1_2;
    private int highScore1_3;
    private int highScore2_1;
    private int highScore2_2;
    private int highScore2_3;
    private int highScore3_1;
    private int highScore3_2;
    private int highScore3_3;
    private string newName;
    private string name1_1;
    private string name1_2;
    private string name1_3;
    private string name2_1;
    private string name2_2;
    private string name2_3;
    private string name3_1;
    private string name3_2;
    private string name3_3;
    [SerializeField] int levelNum;
    [SerializeField] TextMeshProUGUI record1;
    [SerializeField] TextMeshProUGUI record2;
    [SerializeField] TextMeshProUGUI record3;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (levelNum == 1)
        {
            highScore1_1 = SaveAndLoad.instance.highScore1_1;
            highScore1_2 = SaveAndLoad.instance.highScore1_2;
            highScore1_3 = SaveAndLoad.instance.highScore1_3;

            name1_1 = SaveAndLoad.instance.name1_1;
            name1_2 = SaveAndLoad.instance.name1_2;
            name1_3 = SaveAndLoad.instance.name1_3;

            record1.text = "1. " + name1_1 + ": " + highScore1_1;
            record2.text = "2. " + name1_2 + ": " + highScore1_2;
            record3.text = "3. " + name1_3 + ": " + highScore1_3;
        } else if (levelNum == 2)
        {
            highScore2_1 = SaveAndLoad.instance.highScore2_1;
            highScore2_2 = SaveAndLoad.instance.highScore2_2;
            highScore2_3 = SaveAndLoad.instance.highScore2_3;

            name2_1 = SaveAndLoad.instance.name2_1;
            name2_2 = SaveAndLoad.instance.name2_2;
            name2_3 = SaveAndLoad.instance.name2_3;

            record1.text = "1. " + name2_1 + ": " + highScore2_1;
            record2.text = "2. " + name2_2 + ": " + highScore2_2;
            record3.text = "3. " + name2_3 + ": " + highScore2_3;
        } else if (levelNum == 3)
        {
            highScore3_1 = SaveAndLoad.instance.highScore3_1;
            highScore3_2 = SaveAndLoad.instance.highScore3_2;
            highScore3_3 = SaveAndLoad.instance.highScore3_3;

            name3_1 = SaveAndLoad.instance.name3_1;
            name3_2 = SaveAndLoad.instance.name3_2;
            name3_3 = SaveAndLoad.instance.name3_3;

            record1.text = "1. " + name3_1 + ": " + highScore3_1;
            record2.text = "2. " + name3_2 + ": " + highScore3_2;
            record3.text = "3. " + name3_3 + ": " + highScore3_3;
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        //Check if 0 balls left, then check which level is currently played, then check from highest to lowest score, if the new score beat any records.
        if (gameManager.ballsLeft == 0)
        {
            if (levelNum == 1)
            {
                if (gameManager.score > highScore1_1)
                {
                    highScore1_1 = gameManager.score;
                } else if (gameManager.score > highScore1_2)
                {
                    highScore1_2 = gameManager.score;
                } else if (gameManager.score > highScore1_3)
                {
                    highScore1_3 = gameManager.score;
                }
            } else if (levelNum == 2)
            {
                if (gameManager.score > highScore2_1)
                {
                    highScore2_1 = gameManager.score;
                }
                else if (gameManager.score > highScore2_2)
                {
                    highScore2_2 = gameManager.score;
                }
                else if (gameManager.score > highScore2_3)
                {
                    highScore2_3 = gameManager.score;
                }
            } else if (levelNum == 3)
            {
                if (gameManager.score > highScore3_1)
                {
                    highScore3_1 = gameManager.score;
                }
                else if (gameManager.score > highScore3_2)
                {
                    highScore3_2 = gameManager.score;
                }
                else if (gameManager.score > highScore3_3)
                {
                    highScore3_3 = gameManager.score;
                }
            }
            SaveAndLoad.instance.Save();
        }
        
    }
}
