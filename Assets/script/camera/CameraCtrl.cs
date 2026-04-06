using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField] GameObject stage;
    [SerializeField] string stage_centername;
    [SerializeField] GameObject player;
    [SerializeField] string player_name;

    Vector3 player_prev;

    [SerializeField] Transform Playermode;
    [SerializeField] Transform Stagemode;

    [SerializeField] private float camera_rotate_magnification = 1.5f;
    [SerializeField] private float moveLerpSpeed = 5.0f;
    [SerializeField] private float rotLerpSpeed = 5.0f;

    [SerializeField] private float stickThreshold = 0.5f;   // スティック入力のしきい値

    bool isPlayerMode = true;

    // 縦入力の入れっぱなしで連続反応しないようにする
    private bool rightStickVerticalUsed = false;

    void Awake()
    {
        if (stage == null)
        {
            stage = GameObject.Find(stage_centername);
        }
        if (player == null)
        {
            player = GameObject.Find(player_name);
        }
        player_prev = player.transform.position;
      
    }

    void Update()
    {
        // マウス横移動
        float mouseX = Input.GetAxis("Mouse X");

        // 右スティック入力
        float rightX = Input.GetAxis("RightStickHorizontal");
        float rightY = Input.GetAxis("RightStickVertical");

        // 回転入力はマウスか右スティックのどちらか大きい方を採用
        float rotateInput = Mathf.Abs(rightX) > Mathf.Abs(mouseX) ? rightX : mouseX;
        float mx = rotateInput * camera_rotate_magnification;

        // キーボードでも切り替え可能にしておく
        if (Input.GetKeyDown(KeyCode.Z)|| Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            isPlayerMode = !isPlayerMode;
            Debug.Log("CameraMode Player = " + isPlayerMode);
        }

        // 右スティック上で PlayerMode
        // 右スティック下で StageMode
        if (!rightStickVerticalUsed)
        {
            if (rightY > stickThreshold)
            {
                isPlayerMode = false;
                rightStickVerticalUsed = true;
                Debug.Log("CameraMode Player = true");
            }
            else if (rightY < -stickThreshold)
            {
                isPlayerMode = true;
                rightStickVerticalUsed = true;
                Debug.Log("CameraMode Player = false");
            }
        }

        // スティックを中央付近に戻したら再度入力可能にする
        if (Mathf.Abs(rightY) < 0.2f)
        {
            rightStickVerticalUsed = false;
        }

        Vector3 player_curmove = player.transform.position - player_prev;
        Playermode.transform.position += player_curmove;

        // 左クリック または 右スティック横入力で回転
        if (Input.GetMouseButton(0) || Mathf.Abs(rightX) > 0.1f)
        {
            Playermode.RotateAround(player.transform.position, Vector3.up, mx);
            Stagemode.RotateAround(stage.transform.position, Vector3.up, mx);
        }

        Transform targetMode = isPlayerMode ? Playermode : Stagemode;

        transform.position = Vector3.Lerp(
            transform.position,
            targetMode.position,
            moveLerpSpeed * Time.deltaTime
        );

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetMode.rotation,
            rotLerpSpeed * Time.deltaTime
        );

        player_prev = player.transform.position;
    }
}