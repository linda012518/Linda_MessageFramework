using Common;
using System.Collections.Generic;

namespace Framework
{
    public class MsgCenter
    {

        static Dictionary<AreaCode, IExecuteHandler> _dicManager;

        public static void Init()
        {
            _dicManager = new Dictionary<AreaCode, IExecuteHandler>();
            _dicManager.Add(AreaCode.None, NoneManager.Instance);
        }

        public static void AddModule(AreaCode areaCode, IExecuteHandler handler)
        {
            if (_dicManager.ContainsKey(areaCode) == false)
                _dicManager.Add(areaCode, handler);
            else
                Log.LogWarning("MsgCenter.AddModule:  has this key <" + areaCode + ">");
        }

        public static void Destroy()
        {
            _dicManager.Clear();
            _dicManager = null;
        }

        public static void Dispatch(AreaCode areaCode, int eventCode, params object[] message)
        {
            if (_dicManager.ContainsKey(areaCode))
                _dicManager[areaCode].Execute(eventCode, message);
            else
                Log.LogWarning("MsgCenter.Dispatch:  this manager is not init");
        }

    }
}