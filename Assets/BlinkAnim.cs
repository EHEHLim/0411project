using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkAnim : MonoBehaviour
{
    float time;
    public TextMeshProUGUI tmp;
    public float r;
    public float g;
    public float b;
    // Update is called once per frame
    void Update()
    {
        if (time < 0.5f)
        {
            tmp.color = new Color(r, g, b, 1 - time);
        }
        else
        {
            tmp.color = new Color(r, g, b, time) ;
            if(time > 1f)
            {
                time = 0;
            }
        }

        time += Time.deltaTime;
        
    }
}
