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

        EditorGUI.BeginChangeCheck();
        TIME_MANAGER time_manager = (TIME_MANAGER)target;

        
        EditorGUILayout.BeginHorizontal();
        time_manager.Enable_show_all_palam = EditorGUILayout.Toggle("製作者メニュー表示", time_manager.Enable_show_all_palam);
        EditorGUILayout.EndHorizontal();
        if (time_manager.Enable_show_all_palam)
        {
            DrawDefaultInspector();
        }

        // GUIの更新があったら実行
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(time_manager);
        }

        EditorGUILayout.LabelField("最大タイマーゲージタイム（flaot秒）max_clock");
        EditorGUILayout.BeginHorizontal();
        time_manager.max_clock = EditorGUILayout.FloatField(time_manager.max_clock, GUILayout.Width(48));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("リスポーンした時の逆転時計のゲージの最低値 (int本) respone_clock_value");
        EditorGUILayout.BeginHorizontal();
        time_manager.respone_clock_value = EditorGUILayout.IntField(time_manager.respone_clock_value, GUILayout.Width(48));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("ゲージ消費をするか bool decreasing_gage");
        EditorGUILayout.BeginHorizontal();
        time_manager.decreasing_gage = EditorGUILayout.Toggle(time_manager.decreasing_gage, GUILayout.Width(48));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("アイテムが取得されてから、アイテムがリポップするまでの時間 (float秒) repop_item_get");
        EditorGUILayout.BeginHorizontal();
        time_manager.repop_item_get = EditorGUILayout.FloatField(time_manager.repop_item_get, GUILayout.Width(48));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("逆転時計のゲージが枯渇した後に、プレイヤーがリスポーンするまでのタイム　(float秒) after_nogage_respone");
        EditorGUILayout.BeginHorizontal();
        time_manager.after_nogage_respone = EditorGUILayout.FloatField(time_manager.after_nogage_respone, GUILayout.Width(48));
        EditorGUILayout.EndHorizontal();
        

        /*
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
        */

    }
}
#endif