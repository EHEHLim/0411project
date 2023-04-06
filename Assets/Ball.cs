using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float radi;
    public int direction = 1;

    private Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();

        while (true)
        {
            float rd = Random.Range(-180 , 180);
            if((rd > 65 && rd < 115) || (rd < -65 && rd > -115))
            {
                continue;
            }
            tr.eulerAngles += new Vector3(0, 0, rd);
            if((rd < 65 && rd > 0) || (rd > -65 && rd < 0))
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
            break;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        tr.position += tr.right* moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "WALL")
        {
            tr.eulerAngles = new Vector3(0, 0, tr.eulerAngles.z * -1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name == "Player")
        {
            direction = 1;
            tr.eulerAngles = new Vector3(0, 0, Random.Range(-65, 65));
            if (collision.gameObject.GetComponent<PlayerMove>().isParring)
            {
                moveSpeed = 30f;
            }
            else
            {
                moveSpeed = 10f;
            }
        }

        if (collision.name == "Enomy")
        {
            direction = -1;
            tr.eulerAngles = new Vector3(0, 0, Random.Range(115, 245));
            moveSpeed = 10f;
        }

        if(collision.name == "PlayerScore")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScore++;
            GameObject.Find("GameManager").GetComponent<GameManager>().canSetStart = true;
            Destroy(gameObject);
        }
        if (collision.name == "EnomyScore")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EnomyScore++;
            GameObject.Find("GameManager").GetComponent<GameManager>().canSetStart = true;
            Destroy(gameObject);
        }
    }
}
