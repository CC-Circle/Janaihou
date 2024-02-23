using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomEditor(typeof(TIME_MANAGER))]
public class ex_TIME_MANAGER : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TIME_MANAGER time_manager = (TIME_MANAGER)target;
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.normal.textColor = Color.green;
        GUILayout.Label("パラメータの説明 ",style);
        GUILayout.Label("Max_clock この値が大きいことに比例して\n " +
            "ゲージ一本が減る時間も長くなります ちょうど良い値に調整して下さい");
        GUILayout.Label("Respone_clock_value この値の数がリスポーン時の\n " +
            "ゲージの本数です　適宜調整");
        GUILayout.Label("after_extinguishing_time この値の数がタイマー再出現の時間間隔です\n " +
            "\"after_extinguishing_time\"秒後に取得後の回復タイマーが出現します");
        GUILayout.Label("after_nogage_respone この値の数がゲージ枯渇後のリスポーン時間間隔です\n " +
           "\"after_nogage_respone\"秒後にキャラクターが最新のリスポーン地点へ出現します");


    }
}
#endif