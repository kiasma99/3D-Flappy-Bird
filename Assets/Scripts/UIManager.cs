using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score, spacebarToStart, resultScore, resultBestScore, newRecord;
    [SerializeField] GameObject resultObject, optionObject;
    private GameManager.State tempState;
    private Coroutine startCoroutine;
    private int scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        startCoroutine = StartCoroutine(Twinkle(spacebarToStart));
        scoreCount = -1;
    }
    private IEnumerator Twinkle(TextMeshProUGUI text)
    {
        Color color = text.color;
        while (true)
        {
            for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
            {
                color.a = alpha;
                text.color = color;
                yield return new WaitForSecondsRealtime(0.1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.state != GameManager.State.Start)
        {
            spacebarToStart.gameObject.SetActive(false);
            StopCoroutine(startCoroutine);
        }

        if(GameManager.Instance.isPlay && GameManager.Instance.score != scoreCount)
        {
            scoreCount++;
            score.text = scoreCount.ToString();
        }

        if(GameManager.Instance.state == GameManager.State.End)
        {
            resultObject.SetActive(true);
            if (GameManager.Instance.score > GameManager.Instance.bestScore)
            {
                GameManager.Instance.bestScore = GameManager.Instance.score;
                PlayerPrefs.SetInt("BestScore", GameManager.Instance.bestScore);
                resultScore.color = Color.yellow;
                resultBestScore.color = Color.yellow;
                newRecord.gameObject.SetActive(true);
                StartCoroutine(Twinkle(newRecord));
            }
            resultScore.text = GameManager.Instance.score.ToString();
            resultBestScore.text = GameManager.Instance.bestScore.ToString();
        }

        if (GameManager.Instance.isPlay && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        tempState = GameManager.Instance.state;
        GameManager.Instance.state = GameManager.State.Stop;
        optionObject.SetActive(true);
    }

    public void Restart()
    {
        if(tempState == GameManager.State.Start)
        {
            spacebarToStart.gameObject.SetActive(true);
            startCoroutine = StartCoroutine(Twinkle(spacebarToStart));
        }
        GameManager.Instance.state = tempState;
        optionObject.SetActive(false);
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
