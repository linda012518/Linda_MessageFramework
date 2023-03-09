using System.Threading.Tasks;
using UnityEngine;

public class A_02 : BaseA
{
    void Start()
    {
        Bind(456);
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
        Debug.Log("A_02");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Dispatch(123, "hello, my name is A_02 !!!");
        }
    }
}
