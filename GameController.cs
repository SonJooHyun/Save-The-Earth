using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float startWait = 7f;
    public float wait = 2f;

    public Text scoreText, gameOverText, gameTitle1, gameTitle2, gamestart, lives;

    public Button Restart,Right,Left;

    public GameObject Stars;
    private int score;
    private int livescore;
    private bool gameover, restart;

    public Transform[] Points;

    bool isgame = false;
    public GameObject Star;

    void Start ()
    {
        //화면 고정
        Screen.SetResolution(480, 800, false);

        gameOverText.text = "";
        lives.text = "";
        score = 0;
        livescore = 10;

        gameover = false;
        restart = false;

      //  StartCoroutine("spawn");
    }

    public IEnumerator spawn()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameover)
        {  

            int index = Random.Range(0, Points.Length);

            Instantiate(Star, Points[index].position, Points[index].rotation);
            yield return new WaitForSeconds(wait);

        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!isgame)
            {
                StartCoroutine("spawn");
                isgame = true;
            }
            Stars.SetActive(false);
            gamestart.text = "";
            gameTitle1.gameObject.SetActive(false);
            gameTitle2.gameObject.SetActive(false);
            lives.text = "Lives : " + livescore;

        }

        if (restart == true)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }


    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }

    public void SubLives(int newLives)
    {
        livescore -= newLives;
        SubLives();

        CheckGameOver();
    }
    void SubLives()
    {
        lives.text = "Lives : " + livescore;
    }

    void CheckGameOver()
    {
        if (livescore <= 0)
        {
            gameover = true;
            restart = true;

            Restart.gameObject.SetActive(true);
            Right.gameObject.SetActive(false);
            Left.gameObject.SetActive(false);
            gameTitle1.gameObject.SetActive(true);
            gameTitle2.gameObject.SetActive(true);


            gameOverText.text = "Game Over";
            lives.text = "";

            StopCoroutine("spawn");
        }
    }
}
