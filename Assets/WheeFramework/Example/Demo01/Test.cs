using Framework;
using UnityEngine;

public class Test : BaseNone
{

    protected override void Awake()
    {
        base.Awake();
        Bind(666);
    }

    public override void Execute(int eventCode, params object[] message)
    {
        Debug.Log(eventCode + "=" + message.Length + "=" + message[0]);
    }
}
