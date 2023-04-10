using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    private int playerScore = 0;
    private int enomyScore = 0;
    public bool canSetStart = true;
    public TextMeshProUGUI txt;
    public bool isPlayerWin = true;
    private static GameManager instance = null;
    private bool isFading = false;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public bool IsFading
    {
        get { return isFading; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Game()
    {
        yield return new WaitUntil(() => isFading == false);
        GameObject.Find("Enomy").GetComponent<EnomyMove>().ball = Instantiate(ball, new Vector3(0, 0, 0), ball.GetComponent<Transform>().rotation);
        canSetStart = false;
        yield return new WaitUntil(() => canSetStart == true);
        StartCoroutine(Score());
        //yield return new WaitForSeconds(1f);
        if(playerScore < 5 && enomyScore < 5)
        {
            StartCoroutine(Game());
        }
        else
        {
            if(playerScore == 5)
            {
                isPlayerWin = true;
            }
            else
            {
                isPlayerWin = false;
            }
            StartCoroutine(FadeOut(GameObject.Find("Panel").GetComponent<RawImage>()));
            yield return new WaitUntil(() => (IsFading == false));
            SceneManager.LoadScene("Ending");
        }
    }

    public IEnumerator FadeIn(RawImage panel)
    {
        isFading = true;
        panel.color = new Color(0f, 0f, 0f, 1f);
        while(panel.color.a > 0f)
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

    public IEnumerator Score()
    {
        txt.color = new Color(1, 1, 1, 1);
        txt.text = enomyScore + " : " + playerScore;
        while(txt.color.a > 0f)
        {
            txt.color -= new Color(0, 0, 0, 0.02f);
            yield return new WaitForSeconds(0.01f);
        }

    }

    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    public int EnomyScore
    {
        get { return enomyScore; }
        set { enomyScore = value; }
    }
}
