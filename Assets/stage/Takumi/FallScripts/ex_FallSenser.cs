using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomEditor(typeof(FallSenser))]
public class ex_FallSenser : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FallSenser fallSenser = (FallSenser)target;
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.normal.textColor = Color.green;
        GUILayout.Label("パラメータの説明 ", style);
        GUILayout.Label("Clock_items 　回復タイマーをギミックとして運用するために\n " +
            "このクラスに登録する必要があります");
        GUILayout.Label("登録方法は  Element 一覧の右下の➕ボタンを押し\n " +
            "空のフィールドを生成　　　そこへ回復タイマーオブジェクトをドラッグ&ドロップしてください");

    }
}
#endif