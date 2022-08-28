using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character_", menuName = "Characters/Add")]
public class Characters : ScriptableObject
{
    public new string name;
    public CharacterType characterType;
    public CharacterLevel characterLevel;
    public Color characterColor;
    public GameObject characterObj;
}
[System.Serializable]
public enum CharacterType
{
    Speed = 1,
    Rotate = 2,
    missile = 3,
    bomb = 4,
   
}
[System.Serializable]
public enum CharacterLevel
{
    VeryBad = -2,
    Bad = -1,
    Normal = 0,
    Good = 1,
    VeryGood = 2,
}