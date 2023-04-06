using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public RawImage obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.anyKeyDown)
        {
            StartCoroutine(GameStart());
        }
    }

    IEnumerator GameStart()
    {
        while(obj.color.a < 1f)
        {
            obj.color += new Color(0, 0, 0, 0.02f);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("SampleScene");
    }
}
