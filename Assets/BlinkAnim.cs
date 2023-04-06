using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkAnim : MonoBehaviour
{
    float time;
    public TextMeshProUGUI tmp;
    // Update is called once per frame
    void Update()
    {
        if (time < 0.5f)
        {
            tmp.color = new Color(0, 0, 0, 1 - time);
        }
        else
        {
            tmp.color = new Color(0, 0, 0, time) ;
            if(time > 1f)
            {
                time = 0;
            }
        }

        time += Time.deltaTime;
        
    }
}
