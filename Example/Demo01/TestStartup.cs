using Framework;
using UnityEngine;

public class TestStartup : MonoBehaviour
{
    private void Start()
    {
        MessageManager.Instance.Execute(666, "abc");
    }

    private void OnDestroy()
    {
        MessageManager.Instance.Destroy();
    }
}
