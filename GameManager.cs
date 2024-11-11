using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject coin;
    private int lives;
    private int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateEnemy2", 3f, 30f);
        InvokeRepeating("CreateCoin", 1f, 10f);
        score = 0;
        lives = 3;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f,9f),8f,0), Quaternion.identity);
    }

    void CreateEnemy2()
    {
        Instantiate(enemy2, new Vector3(-12f, Random.Range(4f,8f), 0), Quaternion.identity);
    }

    void CreateCoin()
    {
        Instantiate(coin, new Vector3(Random.Range(-9f,9f), Random.Range(-5f, 0), 0), Quaternion.identity);
    }

    public void EarnScore(int howMuch)
    {
        score = score + howMuch;
        scoreText.text = "Score: " + score;
    }

    public void LifeDisplay(int howMuch)
    {
        lives = lives - howMuch;
        livesText.text = "Lives: " + lives;

    }

}