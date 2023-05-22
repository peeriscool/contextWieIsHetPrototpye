using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level
{

}
public class LevelState : State<level>
{
    public FSM<level> Owner;
    public LevelState(FSM<level> _owner)
    {
        Owner = _owner;
    }
}
