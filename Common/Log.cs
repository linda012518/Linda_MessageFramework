using UnityEngine;

namespace Common
{
    public delegate void LogNativeFun(string msg);

    public class Log
    {
        static LogNativeFun _logNative;

        public static LogNativeFun LogNative { set {_logNative = value;} }

        public static void LogError(object msg, string tag = "Unity")
        {
#if UNITY_EDITOR
            Debug.LogError(tag + " : " + msg);
#else
            if (_logNative != null)
                _logNative(tag + " : " + msg);
#endif
        }

        public static void LogInfo(object msg, string tag = "Unity")
        {
#if UNITY_EDITOR
            Debug.Log(tag + " : " + msg);
#else
            if (_logNative != null)
                _logNative(tag + " : " + msg);
#endif
        }

        public static void LogWarning(object msg, string tag = "Unity")
        {
#if UNITY_EDITOR
            Debug.LogWarning(tag + " : " + msg);
#else
            if (_logNative != null)
                _logNative(tag + " : " + msg);
#endif
        }
    }
}