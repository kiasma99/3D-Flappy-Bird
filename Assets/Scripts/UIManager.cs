using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score, spacebarToStart, resultScore, resultBestScore, newRecord;
    [SerializeField] GameObject result;
    private int scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = -1;
        result.SetActive(false);
        newRecord.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.state != GameManager.State.Start)
        {
            spacebarToStart.gameObject.SetActive(false);
        }

        if(GameManager.Instance.state == GameManager.State.Play && GameManager.Instance.score != scoreCount)
        {
            scoreCount++;
            score.text = scoreCount.ToString();
        }

        if(GameManager.Instance.state == GameManager.State.End)
        {
            result.SetActive(true);
            if (GameManager.Instance.score > GameManager.Instance.bestScore)
            {
                GameManager.Instance.bestScore = GameManager.Instance.score;
                resultScore.color = Color.yellow;
                resultBestScore.color = Color.yellow;
                newRecord.gameObject.SetActive(true);
            }
            resultScore.text = GameManager.Instance.score.ToString();
            resultBestScore.text = GameManager.Instance.bestScore.ToString();
        }
    }

    public void TryAgain()
    {
        GameManager.Instance.state = GameManager.State.Start;
        GameManager.Instance.score = -1;
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        GameManager.Instance.state = GameManager.State.Start;
        GameManager.Instance.score = -1;
        SceneManager.LoadScene("Main");
    }
}
