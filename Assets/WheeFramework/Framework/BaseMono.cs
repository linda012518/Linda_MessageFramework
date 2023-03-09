using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class BaseMono : MonoBehaviour, IExecuteHandler
    {
        protected List<int> list = new List<int>();

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
                MessageManager.Instance.Add(eventCodes[i], this);
            }
        }

        void UnBind()
        {
            if (list != null && list.Count > 0)
            {
                MessageManager.Instance.Remove(list.ToArray(), this);
                list.Clear();
                list = null;
            }
        }

        public virtual void OnApplicationQuit()
        {
            if (list != null)
                UnBind();
        }

        protected void Dispatch(int eventCode, params object[] message)
        {
            MessageManager.Instance.Execute(eventCode, message);
        }

    }
}