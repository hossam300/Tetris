using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterLevel level;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        level = CharacterLevel.VeryGood;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= CharcterManager.Instance.GameStats.MoodTimer)
        {
            timer -= Time.deltaTime;
            switch (level)
            {
                case CharacterLevel.VeryBad:
                    //  Destroy(gameObject, 2f);
                    break;
                case CharacterLevel.Bad:
                    level = CharacterLevel.VeryBad;
                    break;
                case CharacterLevel.Normal:
                    level = CharacterLevel.Bad;
                    break;
                case CharacterLevel.Good:
                    level = CharacterLevel.Normal;
                    break;
                case CharacterLevel.VeryGood:
                    level = CharacterLevel.Good;
                    break;
            }
        }
        else if (timer < CharcterManager.Instance.GameStats.MoodTimer)
        {
            if (timer <= 0)
            {
                timer = CharcterManager.Instance.GameStats.MoodTimer;
            }
            else
                timer -= Time.deltaTime;
        }
    }

    public void UseCharacter(GameObject gameObject)
    {
        var character = CharcterManager.Instance.ownChracter.FirstOrDefault(c => c.characterObj.name == gameObject.name);
        character.characterLevel = gameObject.GetComponent<CharacterController>().level;
        CharcterManager.Instance.UseChacters(character);
    }

    public void ChangeCharacterLevel(CharacterLevel characterLevel)
    {
        level = characterLevel;
    }
}