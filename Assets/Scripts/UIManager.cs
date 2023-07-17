using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score, spacebarToStart;
    private int scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.state != GameManager.State.Start)
        {
            spacebarToStart.gameObject.SetActive(false);
        }

        if(GameManager.Instance.score != scoreCount)
        {
            scoreCount++;
            score.text = scoreCount.ToString();
        }
    }
}
