﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerBoss : MonoBehaviour
{
    public AudioSource firstSong;
    public AudioSource secondSongIntro;
    public AudioSource secondSong;
    public GameObject firstBoss;
    private float health;
    private float playedTimer = 0.5f;
    private bool playedOnce = false;
    private bool playedOnceSecond = false;
    // Start is called before the first frame update
    void Start()
    {
        secondSongIntro.Pause();
        secondSong.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if(firstBoss != null)
        health = firstBoss.GetComponent<BossFirst>().health;
        if(health <= 0 && playedOnce==false && playedTimer == 0.5f)
        {
            secondSongIntro.Play();
            firstSong.Pause();
            playedTimer -= Time.deltaTime;
            playedOnce = true;
            
        }
        if(secondSongIntro.isPlaying == false && playedOnce ==true && playedOnceSecond == false)
        {
            Debug.Log("2ndSONG");
            secondSong.PlayScheduled(75f);
            playedOnceSecond = true;
        }
        
        

    }
}