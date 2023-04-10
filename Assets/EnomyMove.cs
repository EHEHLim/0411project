using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnomyMove : MonoBehaviour
{
    public GameObject ball;
    private float moveSpeed = 5f;
    public bool setEnd = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(GameManager.Instance.canSetStart == false)
        {
            if (ball.GetComponent<Ball>().direction == 1 && GameManager.Instance.canSetStart == false)
            {
                if (ball.GetComponent<Transform>().position.y > transform.position.y)
                {
                    transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
                }
                else
                {
                    transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
                }
            }
        }
    }
}
