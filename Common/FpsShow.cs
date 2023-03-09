using UnityEngine;

namespace Common
{
    public class FpsShow : MonoBehaviour
    {
        public static float f_Fps;
        public float f_UpdateInterval = 0.5f; //每个0.5秒刷新一次  

        float f_LastInterval; //游戏时间  
        int i_Frames = 0;//帧数  
        GUIStyle mStyle;

        void Awake()
        {
            Application.targetFrameRate = 120;
            mStyle = new GUIStyle();
            mStyle.fontSize = 50;
        }

        void OnGUI()
        {
            if (f_Fps > 50)
            {
                mStyle.normal.textColor = new Color(0, 1, 0);
            }
            else if (f_Fps > 40)
            {
                mStyle.normal.textColor = new Color(1, 1, 0);
            }
            else
            {
                mStyle.normal.textColor = new Color(1.0f, 0, 0);
            }


            GUI.Label(new Rect(50, 50, 200, 100), "FPS:" + f_Fps.ToString("f2") , mStyle);

        }

        void Update()
        {
            ++i_Frames;

            if (Time.realtimeSinceStartup > f_LastInterval + f_UpdateInterval)
            {
                f_Fps = i_Frames / (Time.realtimeSinceStartup - f_LastInterval);

                i_Frames = 0;

                f_LastInterval = Time.realtimeSinceStartup;
            }
        }
    }
}

