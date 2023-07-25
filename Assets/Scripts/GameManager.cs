using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public enum State
    {
        Start,
        Play,
        Stop,
        End
    }
    public State state;
    public AudioSource bgmAudio;
    public float bgmValue, sfxValue;
    public bool isBGMMute, isSFXMute;
    public int bestScore;
    public int score;

    public bool isPlay => state == State.Play;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("BestScore")) bestScore = PlayerPrefs.GetInt("BestScore");
        else bestScore = 0;

        if (PlayerPrefs.HasKey("BGMValue")) bgmValue = PlayerPrefs.GetFloat("BGMValue");
        else bgmValue = 100;

        if (PlayerPrefs.HasKey("SFXValue")) sfxValue = PlayerPrefs.GetFloat("SFXValue");
        else sfxValue = 100;

        if (PlayerPrefs.HasKey("isBGMMute")) isBGMMute = PlayerPrefs.GetInt("isBGMMute") == 1 ? true : false;
        else isBGMMute = false;

        if (PlayerPrefs.HasKey("isSFXMute")) isSFXMute = PlayerPrefs.GetInt("isSFXMute") == 1 ? true : false;
        else isSFXMute = false;

        if (isBGMMute) bgmAudio.enabled = false;

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        state = State.Start;
        score = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Start && Input.GetKeyDown(KeyCode.Space))
        {
            state = State.Play;
        }

        bgmAudio.volume = bgmValue / 100;
    }
}
