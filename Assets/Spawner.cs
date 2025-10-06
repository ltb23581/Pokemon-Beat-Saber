using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pokeballs;    // assign your Pokéball prefabs here
    public Transform[] points;        // assign the spawn points here
    public AudioSource music;         // drag your AudioSource here
    public float bpm = 130f;          // beats per minute of your song
    public float startDelay = 5f;     // seconds before the song & spawning start

    private float secondsPerBeat;
    private float nextBeatTime;
    private bool musicStarted = false;

    void Start()
    {
        secondsPerBeat = 60f / bpm;   // length of one beat
        nextBeatTime = startDelay;    // first beat will spawn after delay
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
        // Spawn ball each time we reach the next beat
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
