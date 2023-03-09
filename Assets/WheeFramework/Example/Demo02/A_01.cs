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

    public override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
        Debug.Log("A_01");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Dispatch(456, "hello, my name is A_01 !!!");
        }
    }
}
