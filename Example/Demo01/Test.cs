using Framework;
using UnityEngine;

public class Test : BaseMono
{

    protected void Awake()
    {
        Bind(666);
    }

    public override void Execute(int eventCode, params object[] message)
    {
        Debug.Log(eventCode + "=" + message.Length + "=" + message[0]);
    }
}
