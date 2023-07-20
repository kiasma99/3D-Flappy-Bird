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
    public int bestScore;
    public int score;

    private void Awake()
    {
        bestScore = 0;
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
        if (state == State.Play && Input.GetKeyDown(KeyCode.Escape))
        {
            state = State.Stop;
        }
    }
}
