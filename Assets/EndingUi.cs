using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndingUi : MonoBehaviour
{
    public RawImage panel;
    public TextMeshProUGUI txt;

    private bool isFading = false;
    private void Awake()
    {
        StartCoroutine(FadeIn(GameObject.Find("Panel").GetComponent<RawImage>()));
    }

    // Update is called once per frame
    void Update()
    {
        if(isFading == false)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                StartCoroutine(ReStart("SampleScene"));
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                StartCoroutine(ReStart("Main"));
            }
        }
    }
    IEnumerator ReStart(string str)
    {
        StartCoroutine(FadeOut(panel));
        yield return new WaitUntil(() => isFading == false);
        GameManager.Instance.PlayerScore = 0;
        GameManager.Instance.EnomyScore = 0;
        SceneManager.LoadScene(str);
    }

    public IEnumerator FadeIn(RawImage panel)
    {
        isFading = true;
        panel.color = new Color(0f, 0f, 0f, 1f);
        while (panel.color.a > 0f)
        {
            panel.color -= new Color(0, 0, 0, 0.03f);
            yield return new WaitForSeconds(0.01f);
        }
        isFading = false;
    }

    public IEnumerator FadeOut(RawImage panel)
    {
        isFading = true;
        panel.color = new Color(0f, 0f, 0f, 0f);
        while (panel.color.a < 1f)
        {
            panel.color += new Color(0, 0, 0, 0.03f);
            yield return new WaitForSeconds(0.01f);
        }
        isFading = false;
    }
}
