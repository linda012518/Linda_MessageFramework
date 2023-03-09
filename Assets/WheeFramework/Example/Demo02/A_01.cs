using System.Threading.Tasks;
using UnityEngine;

public class A_01 : BaseA
{
    void Start()
    {
        Bind(123);
    }

    public override async void Execute(int eventCode, params object[] message)
    {
        Debug.Log(eventCode + "=" + message.Length + "=" + message[0]);
        Debug.Log(gameObject.name);

        await Task.CompletedTask;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Dispatch(AreaCode.Test, 456, "hello, my name is A_01 !!!");
        }
    }
}
