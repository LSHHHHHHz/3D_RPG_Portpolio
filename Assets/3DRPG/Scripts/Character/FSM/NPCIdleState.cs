using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCIdleState : IState
{
    private readonly NPC character;
    private Vector3[] dirs;
    float elapsedTime;
    int num;
    Quaternion toRotation;
    public NPCIdleState(NPC character)
    {
        this.character = character;
    }
    public void Enter()
    {
        dirs = new Vector3[] { new(0, 0, 0), new(0, 90, 0), new(0, 180, 0), new(0, 270, 0) };
        elapsedTime = 0;
        num = Random.Range(0, dirs.Length);
        toRotation = Quaternion.Euler(dirs[num]);
    }

    public void Exit()
    {
    }

    public void Update()
    {
        if (elapsedTime <5)
        {
            character.transform.rotation = Quaternion.RotateTowards(character.transform.rotation, toRotation, character.rotationSpeed* Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            character.ChangeState(new NPCIdleState(character));
        }
    }
}
