using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Camera cam;
    [SerializeField] Vector2 mousePos;
    [SerializeField] TextMeshProUGUI scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
         mousePos = Input.mousePosition;
        Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 9));
        if (mousePos.x > 520 && mousePos.x < 1400 && mousePos.y > 800)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(ball, worldPos, ball.transform.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;
        scoreText.text = "Score: " + score;
        Debug.Log(score);
    }
}
