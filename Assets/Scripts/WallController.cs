using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private MeshRenderer m_MeshRenderer;
    private float height, upHeight, downHeight, width, leftWidth, rightWidth;
    private Vector3 defaultUpWall, defaultDownWall, defaultLeftWall, defaultRightWall;
    // Start is called before the first frame update
    void Start()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
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
        m_MeshRenderer.enabled = true;
        transform.gameObject.SetActive(true);
        transform.GetChild(0).gameObject.transform.position = defaultUpWall;
        transform.GetChild(1).gameObject.transform.position = defaultDownWall;
        transform.GetChild(2).gameObject.transform.position = defaultLeftWall;
        transform.GetChild(3).gameObject.transform.position = defaultRightWall;

        if (Start && transform.parent.gameObject.transform.position.z == 0 && transform.position.z == 0)
        {
            m_MeshRenderer.enabled = false;
            return;
        }

        height = Random.Range(4.5f, 5.5f);
        upHeight = Random.Range(0.5f, height - 0.5f);
        downHeight = height - upHeight;
        transform.GetChild(0).gameObject.transform.position += new Vector3(0, -1f, 0) * upHeight + transform.parent.gameObject.transform.position;
        transform.GetChild(1).gameObject.transform.position += new Vector3(0, 1f, 0) * downHeight + transform.parent.gameObject.transform.position;

        width = Random.Range(10f, 12f);
        leftWidth = Random.Range(0.5f, width - 0.5f);
        rightWidth = width - leftWidth;
        transform.GetChild(2).gameObject.transform.position += new Vector3(1f, 0, 0) * leftWidth + transform.parent.gameObject.transform.position;
        transform.GetChild(3).gameObject.transform.position += new Vector3(-1f, 0, 0) * rightWidth + transform.parent.gameObject.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.score++;
            if(GameManager.Instance.score > 0 && !GameManager.Instance.isSFXMute) audioSource.Play();
        }
    }
}
