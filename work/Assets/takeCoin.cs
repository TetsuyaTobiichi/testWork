using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class takeCoin : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    private Collider2D coinColl;
    private string pattern = @"Score:\s*(\d+)";
    private AudioSource audioSource;  
    

    void Awake()
    {
        audioSource= GetComponent<AudioSource>();
        coinColl = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            GetComponent<Renderer>().enabled = false;
            audioSource.Play();
            Invoke("DestroyCoin", audioSource.clip.length);
            
        }
    }
    void DestroyCoin()
    {
        Destroy(coinColl.gameObject);
    }
    void OnDestroy()
    {   //получение сохраненных данных
        int score = PlayerPrefs.GetInt("score", 0);
        score += 1;
        Debug.Log(score);
        PlayerPrefs.SetInt("score", score);
        
        text.text = "Score: " + score;
        
    }
}