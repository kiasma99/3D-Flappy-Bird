using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 jumpMove = new Vector3(0f, 250f, 0f);
    [SerializeField] float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.state == GameManager.State.Play)
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
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
        if (collision.transform.CompareTag("Wall"))
        {
            GameManager.Instance.state = GameManager.State.End;
        }
    }
}
