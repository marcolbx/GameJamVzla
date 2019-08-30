using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerBoss : MonoBehaviour
{
    public AudioSource firstSong;
    public AudioSource secondSongIntro;
    public AudioSource secondSong;
    public AudioSource typeWriterSound;
    public GameObject firstBoss;
    private float health;
    private float playedTimer = 0.5f;
    private bool playedOnceFirstSong = false; 
    private bool playedOnce = false;
    private bool playedOnceSecond = false;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        secondSongIntro.Pause();
        secondSong.Pause();
        player = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(firstBoss != null)
        health = firstBoss.GetComponent<BossFirst>().health;

        if(player != null)
        {
            if(playedOnceFirstSong == false)
            if(Vector3.Distance(firstBoss.transform.position,player.position) < 5f)
        {
            Debug.Log("1stSONG");
            firstSong.Play();
            typeWriterSound.Pause();
            playedOnceFirstSong = true;
        }
        }
        

        if(health <= 0 && playedOnce==false && playedTimer == 0.5f)
        {
            Debug.Log("2ndSONG");
            secondSongIntro.Play();
            firstSong.Pause();
            playedTimer -= Time.deltaTime;
            playedOnce = true;
            
        }
        if(secondSongIntro.isPlaying == false && playedOnce ==true && playedOnceSecond == false)
        {
            Debug.Log("3rdSONG");
            secondSong.PlayScheduled(75f);
            playedOnceSecond = true;
        }
        
        

    }
}
