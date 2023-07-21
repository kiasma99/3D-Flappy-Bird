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
        if(GameManager.Instance.state == GameManager.State.Play)
        {
            transform.Translate(stageMove * Time.deltaTime);
            if (transform.position.z <= -8)
            {
                transform.position = new Vector3(0, 0, 92f);
                wallController.SetRandomPosition(false);
            }
        }
    }
}
