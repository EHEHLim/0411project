using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.name == "Wall")
        {
            if (collision.GetComponentInParent<Transform>().name == "Player")
            {
                collision.GetComponentInParent<PlayerMove>().canUp = false;
            }
            
        }

        if (gameObject.name == "Wall (1)")
        {
            if (collision.GetComponentInParent<Transform>().name == "Player")
            {
                collision.GetComponentInParent<PlayerMove>().canDown = false;
            }
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(gameObject.name == "Wall")
        {
            if (collision.GetComponentInParent<Transform>().name == "Player")
            {
                collision.GetComponentInParent<PlayerMove>().canUp = true;
            }
            
        }

        if (gameObject.name == "Wall (1)")
        {
            if (collision.GetComponentInParent<Transform>().name == "Player")
            {
                collision.GetComponentInParent<PlayerMove>().canDown = true;
            }
            
        }
    }
}
