using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Transform tr;
    public float moveSpeed = 5f;
    public bool canUp = true;
    public bool canDown = true;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && canUp)
        {
            tr.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }

        if((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && canDown)
        {
            tr.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }

    
}
