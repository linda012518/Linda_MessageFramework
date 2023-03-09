using Framework;
using UnityEngine;

public class Startup_A : MonoBehaviour
{
    void Start()
    {
        MsgCenter.Init();
        MsgCenter.AddModule(AreaCode.Test, A_Manager.Instance);
    }

    private void OnDestroy()
    {
        MsgCenter.Destroy();
    }
}
