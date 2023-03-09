
namespace Framework
{
    public class BaseNone : BaseMono<NoneManager>
    {
        protected virtual void Awake()
        {
            mgr = NoneManager.Instance;
        }

    }
}