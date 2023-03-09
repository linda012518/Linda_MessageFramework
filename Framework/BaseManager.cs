using Common;
using System.Collections.Generic;

namespace Framework
{
    /// <summary>
    /// 每个模块的基类
    /// </summary>
    public abstract class BaseManager<T> : Singleton<T>, IExecuteHandler where T : Singleton<T>
    {
        /// <summary>存储 消息的事件码 和 哪个脚本 关联 的字典</summary>
        Dictionary<int, List<IExecuteHandler>> _dict = new Dictionary<int, List<IExecuteHandler>>();

        /// <summary>处理自身的消息</summary>
        public virtual void Execute(int eventCode, params object[] message)
        {
            if (!_dict.ContainsKey(eventCode))
            {
                Log.LogWarning("没有注册 ： " + eventCode);
                return;
            }

            //一旦注册过这个消息 给所有的脚本 发过去
            List<IExecuteHandler> list = _dict[eventCode];
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Execute(eventCode, message);
            }
        }

        /// <summary>添加事件</summary>
        public void Add(int eventCode, IExecuteHandler mono)
        {
            List<IExecuteHandler> list = null;

            //之前没有注册过
            if (!_dict.ContainsKey(eventCode))
            {
                list = new List<IExecuteHandler>();
                list.Add(mono);
                _dict.Add(eventCode, list);
                return;
            }

            //之前注册过
            list = _dict[eventCode];
            if (list.Contains(mono) == false)
                list.Add(mono);
        }

        /// <summary>添加多个事件 一个脚本关心多个事件</summary>
        public void Add(int[] eventCodes, IExecuteHandler mono)
        {
            for (int i = 0; i < eventCodes.Length; i++)
            {
                Add(eventCodes[i], mono);
            }
        }

        /// <summary>移除事件</summary>
        public void Remove(int eventCode, IExecuteHandler mono)
        {
            //没注册过 没法移除 报个警告
            if (!_dict.ContainsKey(eventCode))
            {
                Log.LogWarning("没有这个事件" + eventCode + "注册");
                return;
            }

            List<IExecuteHandler> list = _dict[eventCode];

            if (list.Count == 1)
                _dict.Remove(eventCode);
            else
                list.Remove(mono);
        }

        /// <summary>移除多个</summary>
        public void Remove(int[] eventCodes, IExecuteHandler mono)
        {
            for (int i = 0; i < eventCodes.Length; i++)
            {
                Remove(eventCodes[i], mono);
            }
        }

        public void Dispatch(AreaCode areaCode, int eventCode, params object[] message)
        {
            MsgCenter.Dispatch(areaCode, eventCode, message);
        }

    }
}