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
    public GameStats GameStats;
    static Transform parent;
    public Vector2 offset = new Vector2(1, 1);
    [SerializeField] LayerMask charactersLayer;
    Camera myCam;
    void Start()
    {
        parent = gameObject.transform;
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero, 0.1f, charactersLayer);

            if (hit.collider != null)
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.gameObject.GetComponent<CharacterController>() != null)
                {
                    hit.collider.gameObject.GetComponent<CharacterController>().UseCharacter(hit.collider.gameObject);
                }
            }


            //}
        }
    }
    public void AddChacters(CharacterType characterType)
    {
        var chracter = chracters.FirstOrDefault(c => c.characterType == characterType);
        chracter.characterObj.GetComponent<SpriteRenderer>().color = chracter.characterColor;
        ownChracter.Add(chracter);
        print(chracter.name);
        offset.x = UnityEngine.Random.Range(-1, 1);
        offset.y = UnityEngine.Random.Range(-2, 2);
        var obj = Instantiate(chracter.characterObj, new Vector3(parent.position.x + offset.x, parent.position.y + offset.y, 0), Quaternion.identity);
        obj.transform.parent = gameObject.transform;
    }
    public void UseChacters(Characters characters)
    {
        switch (characters.characterType)
        {
            case CharacterType.Speed:
                print("use speed");
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
                GameStats.isAutoRotate = true;
                GameStats.rotateSpeed = 5f;
                break;
            case CharacterLevel.Bad:
                GameStats.isAutoRotate = true;
                GameStats.rotateSpeed = 7f;
                break;
            case CharacterLevel.Normal:
                GameStats.isAutoRotate = true;
                GameStats.rotateSpeed = 10;
                break;
            case CharacterLevel.Good:
                GameStats.isAutoRotate = false;
                GameStats.rotateSpeed = 0;
                break;
            case CharacterLevel.VeryGood:
                GameStats.isAutoRotate = false;
                GameStats.rotateSpeed = 0;
                break;
        }
    }

    private void ChangeGameSpeed(CharacterLevel characterLevel)
    {
        switch (characterLevel)
        {
            case CharacterLevel.VeryBad:
                GameStats.bolckSpped = 0.25f;
                break;
            case CharacterLevel.Bad:
                GameStats.bolckSpped = 0.5f;
                break;
            case CharacterLevel.Normal:
                GameStats.bolckSpped = 1f;
                break;
            case CharacterLevel.Good:
                GameStats.bolckSpped = 1.5f;
                break;
            case CharacterLevel.VeryGood:
                GameStats.bolckSpped = 2f;
                break;
        }
    }
}
