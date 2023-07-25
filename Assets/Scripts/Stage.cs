using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] Vector3 stageMove = new Vector3 (0, 0, -2f);
    [SerializeField] WallController wallController;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlay)
        {
            stageMove = new Vector3(0, 0, -(2 + 0.4f * GameManager.Instance.score / 5));
            transform.Translate(stageMove * Time.deltaTime);
            if (transform.position.z <= -8)
            {
                transform.position += new Vector3(0, 0, 60f);
                wallController.SetRandomPosition(false);
            }
        }
        else stageMove = Vector3.zero;
    }
}
