using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.SceneManagement;
//using UnityEditor.SceneManagement;
#endif

#if UNITY_EDITOR
[CustomEditor(typeof(turn_clock))]
public class ex_trun_clock : Editor
{
    private turn_clock _component;

    private void OnEnable()
    {
        _component = target as turn_clock;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorGUI.BeginChangeCheck();
        turn_clock trun_Clock = (turn_clock)target;

        EditorGUILayout.BeginHorizontal();
        trun_Clock.Enable_show_all_palam = EditorGUILayout.Toggle("製作者メニュー表示", trun_Clock.Enable_show_all_palam);
        EditorGUILayout.EndHorizontal();
        if (trun_Clock.Enable_show_all_palam)
        {
            DrawDefaultInspector();
        }

        

        EditorGUILayout.LabelField("リスポーン時にリポップするか bool　enable_revial");
        EditorGUILayout.BeginHorizontal();
        trun_Clock.enable_revial = EditorGUILayout.Toggle(trun_Clock.enable_revial, GUILayout.Width(48));
        EditorGUILayout.EndHorizontal();
        _component.enable_revial = trun_Clock.enable_revial;

        EditorGUILayout.LabelField("アイテムが取得されてから、一定時間の経過でリポップするか bool　enable_repop");
        EditorGUILayout.BeginHorizontal();
        trun_Clock.enable_repop = EditorGUILayout.Toggle(trun_Clock.enable_repop, GUILayout.Width(48));
        EditorGUILayout.EndHorizontal();
        _component.enable_repop = trun_Clock.enable_repop;

        EditorGUILayout.LabelField("このアイテムを取得したことで回復するゲージ量 int本 recover_value");
        EditorGUILayout.BeginHorizontal();
        trun_Clock.recover_value = EditorGUILayout.IntField(trun_Clock.recover_value, GUILayout.Width(48));
        EditorGUILayout.EndHorizontal();
        _component.recover_value = trun_Clock.recover_value;

        
        //EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());

        // GUIの更新があったら実行
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(_component, "chenge_value");
            
            EditorUtility.SetDirty(trun_Clock);
        }
    }
}
#endif