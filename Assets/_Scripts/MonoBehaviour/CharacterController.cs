using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterLevel level;
    public float timer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        level = CharacterLevel.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= Grid.GameStats.bolckSpped)
        {
            timer -= Time.deltaTime;
            switch (level)
            {
                case CharacterLevel.VeryBad:
                    Destroy(gameObject, 2f);
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
        else if (timer < Grid.GameStats.bolckSpped)
        {
            if (timer <= 0)
            {
                timer = Grid.GameStats.bolckSpped;
            }
            else
                timer -= Time.deltaTime;
        }
    }
    public void ChangeCharacterLevel(CharacterLevel characterLevel)
    {
        level = characterLevel;
    }
}