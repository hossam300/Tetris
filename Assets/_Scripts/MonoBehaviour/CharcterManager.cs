using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class CharcterManager : StaticInstance<CharcterManager>
{
    // Start is called before the first frame update
    public List<Characters> chracters = new List<Characters>();
    public List<Characters> ownChracter = new List<Characters>();
    static Transform parent;
    void Start()
    {
        parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.score >= LevelManager.level * 1000)
        {
            AddChacters((CharacterType)Enum.ToObject(typeof(CharacterType), UnityEngine.Random.Range(1, 4)));
        }
    }
    public void AddChacters(CharacterType characterType)
    {
        var chracter = chracters.FirstOrDefault(c => c.characterType == characterType);
        chracter.characterObj.GetComponent<SpriteRenderer>().color = chracter.characterColor;
        ownChracter.Add(chracter);
        Instantiate(chracter.characterObj, parent.position, Quaternion.identity);
    }
    public void UseChacters(Characters characters)
    {
        switch (characters.characterType)
        {
            case CharacterType.Speed:
                ChangeGameSpeed(characters.characterLevel);
                break;
            case CharacterType.Rotate:
                Rotate(characters.characterLevel);
                break;
            case CharacterType.missile:
                missile(characters.characterLevel);
                break;
            case CharacterType.bomb:
                bomb(characters.characterLevel);
                break;

        }
        Destroy(characters.characterObj, 05f);

    }

    private void bomb(CharacterLevel characterLevel)
    {
        switch (characterLevel)
        {
            case CharacterLevel.VeryBad:
                break;
            case CharacterLevel.Bad:
                break;
            case CharacterLevel.Normal:
                break;
            case CharacterLevel.Good:
                break;
            case CharacterLevel.VeryGood:
                break;
        }
    }

    private void missile(CharacterLevel characterLevel)
    {
        switch (characterLevel)
        {
            case CharacterLevel.VeryBad:
                break;
            case CharacterLevel.Bad:
                break;
            case CharacterLevel.Normal:
                break;
            case CharacterLevel.Good:
                break;
            case CharacterLevel.VeryGood:
                break;
        }
    }

    private void Rotate(CharacterLevel characterLevel)
    {
        switch (characterLevel)
        {
            case CharacterLevel.VeryBad:
                Grid.GameStats.isAutoRotate = true;
                Grid.GameStats.rotateSpeed = 0.25f;
                break;
            case CharacterLevel.Bad:
                Grid.GameStats.isAutoRotate = true;
                Grid.GameStats.rotateSpeed = 0.5f;
                break;
            case CharacterLevel.Normal:
                Grid.GameStats.isAutoRotate = true;
                Grid.GameStats.rotateSpeed = 1;
                break;
            case CharacterLevel.Good:
                Grid.GameStats.isAutoRotate = false;
                break;
            case CharacterLevel.VeryGood:
                Grid.GameStats.isAutoRotate = false;
                break;
        }
    }

    private void ChangeGameSpeed(CharacterLevel characterLevel)
    {
        switch (characterLevel)
        {
            case CharacterLevel.VeryBad:
                Grid.GameStats.bolckSpped = 2;
                break;
            case CharacterLevel.Bad:
                Grid.GameStats.bolckSpped = 1.5f;
                break;
            case CharacterLevel.Normal:
                Grid.GameStats.bolckSpped = 1f;
                break;
            case CharacterLevel.Good:
                Grid.GameStats.bolckSpped = 0.5f;
                break;
            case CharacterLevel.VeryGood:
                Grid.GameStats.bolckSpped = 0.25f;
                break;
        }
    }
}
