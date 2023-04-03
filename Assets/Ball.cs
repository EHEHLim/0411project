using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float radi;
    private int xDirection = 1;
    private int yDirection = 1;

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
        tr.eulerAngles = new Vector3(0, 0, 180 - tr.eulerAngles.z);
        
        if (collision.name == "Player")
        {
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
            moveSpeed = 10f;
        }
    }
}
