using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class getInputChecker
{
    public static bool IsJumpInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    } 

    public static bool IsPauseInput()
    {
        return Input.GetKeyDown(KeyCode.P);
    }

    public static bool IsAttackInput()
    {
        return Input.GetButtonDown("Fire1");
    }
}
