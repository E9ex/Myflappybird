using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class gamemanager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI scoretext;
    public GameObject playbutton;
    public GameObject gameroverımage;
    private int score;

    private void Awake()
    {
        //Application.targetFrameRate = 60;//60 fps den fazla olmasın.
        pause();
    }

    public void Play()
    {
        score = 0;
        scoretext.text = score.ToString();

        playbutton.SetActive(false);
        gameroverımage.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void pause()
    {
        Time.timeScale = 0f;// oyun durur. deltatime!!
        player.enabled = false;
    }

    public void gameover()
    {
        gameroverımage.SetActive(true);
        playbutton.SetActive(true);
        pause();
    }
    

    public void Increase()
    {
        score++;
        scoretext.text = score.ToString();
    }
}
