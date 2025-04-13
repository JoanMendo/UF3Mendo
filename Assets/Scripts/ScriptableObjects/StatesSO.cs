using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public abstract class StatesSO : ScriptableObject
{

    public float lastStartTime;
    public float lastEndTime;
    public float cooldown;

    public abstract void EnterState(PlayerInputData playerData);
    public abstract void UpdateState(PlayerInputData playerDat);
    public abstract void ExitState(PlayerInputData playerDat);

}


