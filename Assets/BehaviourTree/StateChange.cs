using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/StateChange")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "StateChange", message: "Me quiero morir", category: "Events", id: "a3d047ad25eada4995be304ac6f2904f")]
public partial class StateChange : EventChannelBase
{
    public delegate void StateChangeEventHandler();
    public event StateChangeEventHandler Event; 

    public void SendEventMessage()
    {
        Event?.Invoke();
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        Event?.Invoke();
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        StateChangeEventHandler del = () =>
        {
            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as StateChangeEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as StateChangeEventHandler;
    }
}

