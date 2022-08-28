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
        if (ScoreManager.score >= level * 1000)
        {
            level += 1;
            Light.color = new Color
                            (
                              Random.Range(0f, 1f),
                              Random.Range(0f, 1f),
                              Random.Range(0f, 1f)
                            );
        }
        levelText.text = level.ToString();
        Grid.GameStats.bolckSpped -= 0.1f;
    }
}
