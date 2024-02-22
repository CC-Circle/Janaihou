using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
        GUILayout.Label("Max_clockの値が大きいことに比例して\n " +
            "ゲージ一本が減る時間も長くなります ちょうど良い値に調整して下さい");
    }
}
