using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pokeballs;    
    public Transform[] points;        
    public AudioSource music;         
    public float bpm = 130f;          
    public float startDelay = 5f;     

    private float secondsPerBeat;
    private float nextBeatTime;
    private bool musicStarted = false;

    void Start()
    {
        secondsPerBeat = 60f / bpm;   
        nextBeatTime = startDelay;    
        Invoke(nameof(StartMusic), startDelay);
    }

    void StartMusic()
    {
        if (music != null)
        {
            music.Play();
            musicStarted = true;
        }
    }

    void Update()
    {
        if (musicStarted && music != null && music.isPlaying && music.time + startDelay >= nextBeatTime)
        {
            SpawnBall();
            nextBeatTime += secondsPerBeat;
        }
    }

    void SpawnBall()
    {
        int pointIndex = Random.Range(0, 2);
        Transform spawn = points[pointIndex];

        int prefabIndex = Random.Range(0, 2);
        GameObject ball = Instantiate(pokeballs[prefabIndex], spawn.position, Quaternion.Euler(0, 180, 0));
    }
}
