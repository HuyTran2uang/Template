using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private Dictionary<string, AudioSource> _audioDictionary = new Dictionary<string, AudioSource>();

    public void Play(string name, Vector3 position)
    {
        _audioDictionary[name].transform.position = position;
        _audioDictionary[name].Play();
    }
}
