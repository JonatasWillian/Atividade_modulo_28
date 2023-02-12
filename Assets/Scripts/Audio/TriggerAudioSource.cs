using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioSource : MonoBehaviour
{
    [Header("Disable Audio")]
    public GameObject musicFight;

    [Header("Music Ambience")]
    public GameObject musicAmbience;

    private void OnTriggerEnter(Collider other)
    {
        musicFight.SetActive(true);
        musicAmbience.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        musicFight.SetActive(false);
        musicAmbience.SetActive(true);
    }
}
