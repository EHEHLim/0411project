using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnomyMove : MonoBehaviour
{
    public bool canUp = true;
    public bool canDown = true;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, ball.GetComponent<Transform>().position.y, 0); 
    }
}
