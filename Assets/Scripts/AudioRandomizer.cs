using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{
    public AudioSource audio;
    public List<AudioClip> audioClips;

    // Запускает случайный аудиоклип.
    public void RandomizeAudio()
    {
        int random = Random.Range(0, 19);
        audio.PlayOneShot(audioClips[random]);
    }
}
