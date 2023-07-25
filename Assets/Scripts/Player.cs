using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] AudioSource flySound, hitSound;
    [SerializeField] Vector3 jumpMove = new Vector3(0f, 250f, 0f);
    [SerializeField] float moveSpeed = 5f;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isPlay)
        {
            flySound.volume = GameManager.Instance.sfxValue / 100;
            hitSound.volume = GameManager.Instance.sfxValue / 100;

            Time.timeScale = 1;
            moveSpeed = 5f + 0.1f * GameManager.Instance.score / 5;
            float x = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(x, 0f, 0f) * moveSpeed * Time.deltaTime;

            if (x < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 15f);
            }
            else if (x > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -15f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!GameManager.Instance.isSFXMute) flySound.Play();
                rb.velocity = Vector3.zero;
                rb.AddForce(jumpMove);
            }
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall") && GameManager.Instance.isPlay)
        {
            if (!GameManager.Instance.isSFXMute) hitSound.Play();
            GameManager.Instance.state = GameManager.State.End;
        }
    }
}
