using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public RawImage panel;

    private void Awake()
    {
        panel = GetComponentInChildren<RawImage>();
        StartCoroutine(GameManager.Instance.FadeIn(panel));

        StartCoroutine(GameManager.Instance.Game());
        StartCoroutine(GameManager.Instance.Score());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
