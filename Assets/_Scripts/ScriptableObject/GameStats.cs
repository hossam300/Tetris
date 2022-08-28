using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameStats", menuName ="Settings/Stats")]
public class GameStats : ScriptableObject
{
    public int Score = 0;
    public int ChangeLeveScore = 1000;
    public float bolckSpped = 1;
    public float rotateSpeed = 1;
    public bool isAutoRotate = false;
    public AudioClip landAudio;
    public AudioClip rowDestroyAudio;
    public AudioClip GameOver;
    public AudioClip ChangeLevelAudio;
}
