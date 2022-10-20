using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class getInputKeyboard : getInputChecker
{
    public override bool IsJumpInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public override bool IsPauseInput()
    {
        return Input.GetKeyDown(KeyCode.P);
    }

    public override bool IsAttackInput()
    {
        return Input.GetButtonDown("Fire1");
    }

}
