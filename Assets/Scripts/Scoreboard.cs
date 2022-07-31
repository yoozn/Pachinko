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
    private bool started = false;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        SaveAndLoad.instance.Load();
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
        if (gameManager.startingBalls == 0)
        {
            ChangeScore();
        }
        if (gameManager.ballsLeft == 0)
        {
            Invoke("ChangeScore", 15);
        }





        //Debug.Log(SaveAndLoad.instance.highScore1_1 + "score 2 " + SaveAndLoad.instance.highScore1_2 + "score 3" + SaveAndLoad.instance.highScore1_3);

        //Check if 0 balls left, then check which level is currently played, then check from highest to lowest score, if the new score beat any records.
        //if (gameManager.ballsLeft == 0 && started == false)
        //{
        //    //Debug.Log("0 Balls Left");
        //    if (levelNum == 1)
        //    {
        //        //Debug.Log("0 Balls left, level 1");
        //        //Debug.Log("Score for Level 1: " + gameManager.score);
        //        if (gameManager.score >= highScore1_1)
        //        {
        //            if (SaveAndLoad.instance.highScore1_1 > 0)
        //            {
        //                SaveAndLoad.instance.highScore1_3 = SaveAndLoad.instance.highScore1_2;
        //                SaveAndLoad.instance.name1_3 = SaveAndLoad.instance.name1_2;

        //                SaveAndLoad.instance.highScore1_2 = SaveAndLoad.instance.highScore1_1;
        //                SaveAndLoad.instance.name1_2 = SaveAndLoad.instance.name1_1;
        //            }


        //            SaveAndLoad.instance.highScore1_1 = gameManager.score;
        //            SaveAndLoad.instance.name1_1 = SaveAndLoad.instance.newName;
        //            Debug.Log(SaveAndLoad.instance.highScore1_1);
        //            Debug.Log("Started The First Check");
        //            started = true;





        //        }
        //        else if (gameManager.score >= highScore1_2)
        //        {
        //            if (SaveAndLoad.instance.highScore1_3 > 0)
        //            {
        //                SaveAndLoad.instance.highScore1_3 = SaveAndLoad.instance.highScore1_2;
        //                SaveAndLoad.instance.name1_3 = SaveAndLoad.instance.name1_2;
        //            }

        //            SaveAndLoad.instance.highScore1_2 = gameManager.score;
        //            SaveAndLoad.instance.name1_2 = SaveAndLoad.instance.newName;

        //        }
        //        else if (gameManager.score >= highScore1_3)
        //        {
        //            SaveAndLoad.instance.highScore1_3 = gameManager.score;
        //            SaveAndLoad.instance.name1_3 = SaveAndLoad.instance.newName;

        //        }
        //    }
        //    else if (levelNum == 2)
        //    {
        //        if (gameManager.score >= highScore2_1)
        //        {
        //            SaveAndLoad.instance.highScore2_3 = SaveAndLoad.instance.highScore2_2;
        //            SaveAndLoad.instance.name2_3 = SaveAndLoad.instance.name2_2;

        //            SaveAndLoad.instance.highScore2_2 = SaveAndLoad.instance.highScore2_1;
        //            SaveAndLoad.instance.name2_2 = SaveAndLoad.instance.name2_1;

        //            SaveAndLoad.instance.highScore2_1 = gameManager.score;
        //            SaveAndLoad.instance.name2_1 = SaveAndLoad.instance.newName;



        //        }
        //        else if (gameManager.score >= highScore2_2)
        //        {
        //            SaveAndLoad.instance.highScore2_3 = SaveAndLoad.instance.highScore2_2;
        //            SaveAndLoad.instance.name2_3 = SaveAndLoad.instance.name2_2;

        //            SaveAndLoad.instance.highScore2_2 = gameManager.score;
        //            SaveAndLoad.instance.name2_2 = SaveAndLoad.instance.newName;

        //        }
        //        else if (gameManager.score >= highScore2_3)
        //        {
        //            SaveAndLoad.instance.highScore2_3 = gameManager.score;
        //            SaveAndLoad.instance.name2_3 = SaveAndLoad.instance.newName;

        //        }
        //    }
        //    else if (levelNum == 3)
        //    {
        //        if (gameManager.score >= highScore3_1)
        //        {
        //            SaveAndLoad.instance.highScore3_1 = gameManager.score;
        //            SaveAndLoad.instance.name3_1 = SaveAndLoad.instance.newName;

        //        }
        //        else if (gameManager.score >= highScore3_2)
        //        {
        //            SaveAndLoad.instance.highScore3_2 = gameManager.score;
        //            SaveAndLoad.instance.name3_2 = SaveAndLoad.instance.newName;

        //        }
        //        else if (gameManager.score >= highScore3_3)
        //        {
        //            SaveAndLoad.instance.highScore3_3 = gameManager.score;
        //            SaveAndLoad.instance.name3_3 = SaveAndLoad.instance.newName;

        //        }
        //    }
        //    SaveAndLoad.instance.Save();
        //}
    }



    // needs to only execute once per scene
    void ChangeScore()
    {
        if (started == false)
        {
            started = true;

            //First three statements check if there are any empty scores on the leaderboard
            //if (SaveAndLoad.instance.highScore1_1 == 0)
            //{
            //    SaveAndLoad.instance.highScore1_1 = gameManager.score;
            //    SaveAndLoad.instance.name1_1 = SaveAndLoad.instance.newName;
            //}
            //else if (SaveAndLoad.instance.highScore1_2 == 0)
            //{
            //    SaveAndLoad.instance.highScore1_2 = gameManager.score;
            //    SaveAndLoad.instance.name1_2 = SaveAndLoad.instance.newName;
            //}
            //else if (SaveAndLoad.instance.highScore1_3 == 0)
            //{
            //    SaveAndLoad.instance.highScore1_3 = gameManager.score;
            //    SaveAndLoad.instance.name1_3 = SaveAndLoad.instance.newName;

            //    //Now that we know there are no empty scores, we can check if a new highscore is set in entry 1. if so, buffer all scores by one down.
            //}
            if (levelNum == 1)
            {
                if (gameManager.score > SaveAndLoad.instance.highScore1_1)
                {
                    SaveAndLoad.instance.highScore1_3 = SaveAndLoad.instance.highScore1_2;
                    SaveAndLoad.instance.highScore1_2 = SaveAndLoad.instance.highScore1_1;
                    SaveAndLoad.instance.highScore1_1 = gameManager.score;

                    SaveAndLoad.instance.name1_3 = SaveAndLoad.instance.name1_2;
                    SaveAndLoad.instance.name1_2 = SaveAndLoad.instance.name1_1;
                    SaveAndLoad.instance.name1_1 = SaveAndLoad.instance.newName;
                }
                else if (gameManager.score > SaveAndLoad.instance.highScore1_2)
                {
                    SaveAndLoad.instance.highScore1_3 = SaveAndLoad.instance.highScore1_2;
                    SaveAndLoad.instance.highScore1_2 = gameManager.score;

                    SaveAndLoad.instance.name1_3 = SaveAndLoad.instance.name1_2;
                    SaveAndLoad.instance.name1_2 = SaveAndLoad.instance.newName;
                }
                else if (gameManager.score > SaveAndLoad.instance.highScore1_3)
                {
                    SaveAndLoad.instance.highScore1_3 = gameManager.score;

                    SaveAndLoad.instance.name1_3 = SaveAndLoad.instance.newName;
                }
                // Same thing as above, but for the next level
            }
            else if (levelNum == 2)
            {
                if (gameManager.score > SaveAndLoad.instance.highScore2_1)
                {
                    SaveAndLoad.instance.highScore2_3 = SaveAndLoad.instance.highScore2_2;
                    SaveAndLoad.instance.highScore2_2 = SaveAndLoad.instance.highScore2_1;
                    SaveAndLoad.instance.highScore2_1 = gameManager.score;

                    SaveAndLoad.instance.name2_3 = SaveAndLoad.instance.name2_2;
                    SaveAndLoad.instance.name2_2 = SaveAndLoad.instance.name2_1;
                    SaveAndLoad.instance.name2_1 = SaveAndLoad.instance.newName;
                }
                else if (gameManager.score > SaveAndLoad.instance.highScore2_2)
                {
                    SaveAndLoad.instance.highScore2_3 = SaveAndLoad.instance.highScore2_2;
                    SaveAndLoad.instance.highScore2_2 = gameManager.score;

                    SaveAndLoad.instance.name2_3 = SaveAndLoad.instance.name2_2;
                    SaveAndLoad.instance.name2_2 = SaveAndLoad.instance.newName;
                }
                else if (gameManager.score > SaveAndLoad.instance.highScore2_3)
                {
                    SaveAndLoad.instance.highScore2_3 = gameManager.score;

                    SaveAndLoad.instance.name2_3 = SaveAndLoad.instance.newName;
                }
            }
            else if (levelNum == 3)
            {
                if (gameManager.score > SaveAndLoad.instance.highScore3_1)
                {
                    SaveAndLoad.instance.highScore3_3 = SaveAndLoad.instance.highScore3_2;
                    SaveAndLoad.instance.highScore3_2 = SaveAndLoad.instance.highScore3_1;
                    SaveAndLoad.instance.highScore3_1 = gameManager.score;

                    SaveAndLoad.instance.name3_3 = SaveAndLoad.instance.name3_2;
                    SaveAndLoad.instance.name3_2 = SaveAndLoad.instance.name3_1;
                    SaveAndLoad.instance.name3_1 = SaveAndLoad.instance.newName;
                }
                else if (gameManager.score > SaveAndLoad.instance.highScore3_2)
                {
                    SaveAndLoad.instance.highScore3_3 = SaveAndLoad.instance.highScore3_2;
                    SaveAndLoad.instance.highScore3_2 = gameManager.score;

                    SaveAndLoad.instance.name3_3 = SaveAndLoad.instance.name3_2;
                    SaveAndLoad.instance.name3_2 = SaveAndLoad.instance.newName;
                }
                else if (gameManager.score > SaveAndLoad.instance.highScore3_3)
                {
                    SaveAndLoad.instance.highScore3_3 = gameManager.score;

                    SaveAndLoad.instance.name3_3 = SaveAndLoad.instance.newName;
                }
            }
        }
    }
}
