using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    public string[] facingDir = { "North_Facing", "NorthWest_Facing", "West_Facing", "SouthWest_Facing", "South_Facing", "SouthEast_Facing", "East_Facing", "NorthEast_Facing" };
    public string[] runDir = { "North_Run", "NorthWest_Run", "West_Run", "SouthWest_Run", "South_Run", "SouthEast_Run", "East_Run", "NorthEast_Run" };

    int lastDir;
    private void Awake()
    {
        anim = GetComponent<Animator>();

        float result1 = Vector2.SignedAngle(Vector2.up, Vector2.right);
        Debug.Log("R1 " + result1);

        float result2 = Vector2.SignedAngle(Vector2.up, Vector2.left);
        Debug.Log("R2 " + result2);

        float result3 = Vector2.SignedAngle(Vector2.up, Vector2.down);
        Debug.Log("R3 " + result3);
    }

public void SetDirection(Vector2 _direction)
    {
        string[] directionArray = null;
        if (_direction.magnitude < 0.01){
            directionArray = facingDir;
        }
        else
        {
            directionArray = runDir;

            lastDir = DirectionToIndex(_direction);
        }
        anim.Play(directionArray[lastDir]);
    }

    private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 norDir = _direction.normalized;

        float step = 360 / 8;
        float offset = step / 2;

        float angle = Vector2.SignedAngle(Vector2.up, norDir);

        angle += offset;

        if(angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
