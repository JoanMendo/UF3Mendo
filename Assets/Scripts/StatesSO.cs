using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public abstract class StatesSO : ScriptableObject
{
    public List<StatesSO> states;
    public abstract void EnterState(PlayerController player);
    public abstract void UpdateState(PlayerController player);
    public abstract void ExitState(PlayerController player);

}
