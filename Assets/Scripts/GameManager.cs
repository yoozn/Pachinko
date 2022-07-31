using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //ADD RECORDS TO EACH LEVEL
    //MAKE SANDBOX LEVEL LEVEL 3,
    //make all levels into sandbox levels
    [SerializeField] private GameObject ball;
    [SerializeField] private Camera cam;
    [SerializeField] Vector2 mousePos;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] public int ballsLeft;
    [SerializeField] TextMeshProUGUI ballsLeftText;
    private GameObject highlightZone;
    private float spawnXZoneMin;
    private float spawnXZoneMax;
    private float spawnYZoneMin;
    private float spawnYZoneMax;
    public int startingBalls;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        highlightZone = GameObject.Find("HighlightZone");
        spawnYZoneMin = 4f;
        spawnYZoneMax = 4.9f;
        spawnXZoneMax = 4.5f;
        spawnXZoneMin = -4.45f;
        startingBalls = ballsLeft;
        UpdateScore(0);
        UpdateBalls(0);
    }

    // Update is called once per frame
    void Update()
    {
         mousePos = Input.mousePosition;
        Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 9));
        if (worldPos.x > spawnXZoneMin && worldPos.x < spawnXZoneMax && worldPos.y > spawnYZoneMin && worldPos.y < spawnYZoneMax)
        {
            if (Input.GetMouseButtonDown(0) && ballsLeft >= 1)
            {
                Instantiate(ball, worldPos, ball.transform.rotation);
                UpdateBalls(-1);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }

    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;
        scoreText.text = "Score: " + score;
        Debug.Log(score);
    }

    public void UpdateBalls(int balls)
    {
        ballsLeft += balls;
        ballsLeftText.text = "Balls left: " + ballsLeft;
    }


    // Used by button, to switch scenes to menu
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        SaveAndLoad.instance.Save();
    }

    public void ToLevel1()
    {
        SceneManager.LoadScene(2);
        SaveAndLoad.instance.Save();
    }

    public void ToLevel2()
    {
        SceneManager.LoadScene(3);
        SaveAndLoad.instance.Save();
    }

    public void ToLevel3()
    {
        SceneManager.LoadScene(4);
        SaveAndLoad.instance.Save();
    }

    public void ToLevel1sandbox()
    {
        SceneManager.LoadScene(5);
    }

    public void ToLevel2sandbox()
    {
        SceneManager.LoadScene(6);
    }

    public void ToLevel3sandbox()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SaveAndLoad.instance.Save();
    }

    public void ToRandomGenScene()
    {
        SceneManager.LoadScene(7);
    }

    public void ToLevel4()
    {
        SceneManager.LoadScene(8);
    }
}
