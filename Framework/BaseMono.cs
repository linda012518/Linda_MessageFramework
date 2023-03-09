using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class BaseMono<T> : MonoBehaviour, IExecuteHandler where T : BaseManager<T>
    {
        protected List<int> list = new List<int>();
        protected T mgr;

        public virtual void Execute(int eventCode, params object[] message)
        {

        }

        protected void Bind(params int[] eventCodes)
        {
            for (int i = 0; i < eventCodes.Length; i++)
            {
                if (list.Contains(eventCodes[i]))
                    continue;

                list.Add(eventCodes[i]);
                mgr.Add(eventCodes[i], this);
            }
        }

        void UnBind()
        {
            if (list != null && list.Count > 0)
            {
                mgr.Remove(list.ToArray(), this);
                list.Clear();
                list = null;
            }
        }

        public virtual void OnDestroy()
        {
            if (list != null)
                UnBind();
        }

        protected void Dispatch(AreaCode areaCode, int eventCode, params object[] message)
        {
            mgr.Dispatch(areaCode, eventCode, message);
        }

    }
}