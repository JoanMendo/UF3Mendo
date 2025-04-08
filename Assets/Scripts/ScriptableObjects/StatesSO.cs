using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public abstract class StatesSO : ScriptableObject
{
    public List<Transition> transitions = new List<Transition>();
    public abstract void EnterState(PlayerInputData playerData);
    public abstract void UpdateState(PlayerInputData playerDat);
    public abstract void ExitState(PlayerInputData playerDat);

}

[System.Serializable]
public class Transition
{
    public StatesSO targetState;
    public bool hasPriority;

    public Transition(StatesSO targetState, bool hasPriority)
    {
        this.targetState = targetState;
        this.hasPriority = hasPriority;
    }
}
