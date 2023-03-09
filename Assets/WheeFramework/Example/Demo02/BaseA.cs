using Framework;

public class BaseA : BaseMono<A_Manager>
{
    void Awake()
    {
        mgr = A_Manager.Instance;
    }
}
