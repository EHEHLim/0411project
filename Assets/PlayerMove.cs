using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Transform tr;
    public float moveSpeed = 5f;
    public bool canUp = true;
    public bool canDown = true;
    private SpriteRenderer sr;
    public bool isParring = false;
    public float parringTime = 0.7f;
    public bool canParring = true;
    public float parringCooldown = 3f;
    private void Awake()
    {
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
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

        if (Input.GetKeyDown(KeyCode.Space) && canParring)
        {
            StartCoroutine(Parring());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Wall")
        {
            canUp = false;
        }

        if(collision.name == "Wall (1)")
        {
            canDown = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Wall")
        {
            canUp = true;
        }

        if(collision.name == "Wall (1)")
        {
            canDown = true;
        }
    }

    IEnumerator Parring()
    {
        sr.color = Color.red;
        canUp = false;
        canDown = false;
        isParring = true;
        canParring = false;
        yield return new WaitForSeconds(parringTime);
        isParring = false;
        canUp = true;
        canDown = true;
        sr.color = Color.white;
        yield return new WaitForSeconds(parringCooldown);
        canParring = true;
    }
    
}
