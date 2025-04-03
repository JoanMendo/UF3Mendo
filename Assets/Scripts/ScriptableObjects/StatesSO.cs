using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public abstract class StatesSO : ScriptableObject
{
    public List<Transition> transitions = new List<Transition>();
    public abstract void EnterState(PlayerController player);
    public abstract void UpdateState(PlayerController player);
    public abstract void ExitState(PlayerController player);

}

[System.Serializable]
public class Transition
{
    public StatesSO targetState;
    public bool hasExitTime;

    public Transition(StatesSO targetState, bool hasExitTime)
    {
        this.targetState = targetState;
        this.hasExitTime = hasExitTime;
    }
}
