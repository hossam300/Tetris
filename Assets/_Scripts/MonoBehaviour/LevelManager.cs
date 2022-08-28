using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static int level;

    TextMeshProUGUI levelText;
    [SerializeField] Light2D Light;
    // Use this for initialization
    void Awake()
    {
        levelText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        Light.color = new Color
                           (
                             Random.Range(0f, 1f),
                             Random.Range(0f, 1f),
                             Random.Range(0f, 1f)
                           );
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.score >= level * CharcterManager.Instance.GameStats.ChangeLeveScore)
        {
            level += 1;
            Light.color = new Color
                            (
                              Random.Range(0f, 1f),
                              Random.Range(0f, 1f),
                              Random.Range(0f, 1f)
                            );
            CharcterManager.Instance.GameStats.bolckSpped -= CharcterManager.Instance.GameStats.levelIncressSpeed;
            AudioManager.Instance.PlaySoundFxSource(CharcterManager.Instance.GameStats.ChangeLevelAudio);
             var type = (CharacterType)Random.Range(1, 2);
            CharcterManager.Instance.AddChacters(type);
            AudioManager.Instance.MainSource.pitch += 0.25f;
        }
        levelText.text = level.ToString();
    }
}
