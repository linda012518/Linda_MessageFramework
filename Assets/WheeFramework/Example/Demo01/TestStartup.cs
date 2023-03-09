using Framework;
using UnityEngine;

public class TestStartup : MonoBehaviour
{
    private void Start()
    {
        MsgCenter.Init();
        MsgCenter.Dispatch(AreaCode.None, 666, "abc");
    }

    private void OnDestroy()
    {
        MsgCenter.Destroy();
    }
}
