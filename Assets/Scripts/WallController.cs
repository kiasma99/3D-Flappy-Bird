using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private float height, upHeight, downHeight, width, leftWidth, rightWidth;
    private Vector3 defaultUpWall, defaultDownWall, defaultLeftWall, defaultRightWall;
    // Start is called before the first frame update
    void Start()
    {
        defaultUpWall = transform.GetChild(0).gameObject.transform.position - transform.parent.gameObject.transform.position;
        defaultDownWall = transform.GetChild(1).gameObject.transform.position - transform.parent.gameObject.transform.position;
        defaultLeftWall = transform.GetChild(2).gameObject.transform.position - transform.parent.gameObject.transform.position;
        defaultRightWall = transform.GetChild(3).gameObject.transform.position - transform.parent.gameObject.transform.position;
        SetRandomPosition(true);
    }

    void Update()
    {
        if(transform.position.z < -2.5)
        {
            transform.gameObject.SetActive(false);
        }
    }

    public void SetRandomPosition(bool Start)
    {
        transform.gameObject.SetActive(true);
        transform.GetChild(0).gameObject.transform.position = defaultUpWall;
        transform.GetChild(1).gameObject.transform.position = defaultDownWall;
        transform.GetChild(2).gameObject.transform.position = defaultLeftWall;
        transform.GetChild(3).gameObject.transform.position = defaultRightWall;

        if (Start && transform.parent.gameObject.transform.position.z == 0 && transform.position.z == 0) return;

        height = Random.Range(4, 6.4f);
        upHeight = Random.Range(1, height);
        downHeight = height - upHeight;
        transform.GetChild(0).gameObject.transform.position += new Vector3(0, -1f, 0) * upHeight + transform.parent.gameObject.transform.position;
        transform.GetChild(1).gameObject.transform.position += new Vector3(0, 1f, 0) * downHeight + transform.parent.gameObject.transform.position;

        width = Random.Range(0, 5f);
        leftWidth = Random.Range(0, width);
        rightWidth = width - leftWidth;
        transform.GetChild(2).gameObject.transform.position += new Vector3(1f, 0, 0) * leftWidth + transform.parent.gameObject.transform.position;
        transform.GetChild(3).gameObject.transform.position += new Vector3(-1f, 0, 0) * rightWidth + transform.parent.gameObject.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.score++;
        }
    }
}
