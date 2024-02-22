using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomEditor(typeof(turn_clock))]
public class ex_trun_clock : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        turn_clock trun_Clock = (turn_clock)target;
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.normal.textColor = Color.green;
        GUILayout.Label("パラメータの説明 ", style);
        GUILayout.Label("enable_repop このチェックボックスがONなら\n " +
            "キャラリスポーン時に時計が出現します");
        GUILayout.Label("enable_revial このチェックボックスがONなら\n " +
            "ゲージ0時一定時間後に時計が出現します");
    }
}
#endif