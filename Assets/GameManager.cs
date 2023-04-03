using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    private int playerScore = 0;
    private int enomyScore = 0;
    public bool canSetStart = true;
    public TextMeshProUGUI txt;

    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(Score());
        StartCoroutine(Game());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Game()
    {
        GameObject.Find("Enomy").GetComponent<EnomyMove>().ball = Instantiate(ball, new Vector3(0, 0, 0), ball.GetComponent<Transform>().rotation);
        canSetStart = false;
        yield return new WaitUntil(() => canSetStart == true);
        StartCoroutine(Score());
        //yield return new WaitForSeconds(1f);
        if(playerScore < 5 && enomyScore < 5)
        {
            StartCoroutine(Game());
        }
    }

    IEnumerator Score()
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
