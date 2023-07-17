using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] Vector3 stageMove = new Vector3 (0, 0, -2f);
    [SerializeField] WallController[] wallControllers;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.state == GameManager.State.Play)
        {
            transform.Translate(stageMove * Time.deltaTime);
            if (transform.position.z <= -28)
            {
                transform.position = new Vector3(0, 0, 122f);
                for (int i = 0; i < wallControllers.Length; i++)
                {
                    wallControllers[i].SetRandomPosition(false);
                }
            }
        }
    }
}
