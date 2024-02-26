using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 3; // Inspectorビューで変更可能
    Animator animator;



    bool running; // フィールド
    bool Runing
    { // プロパティ
        get { return running; }
        set
        { // 値が異なるセット時のみanimator.SetBoolを呼ぶようにします
            if (value != running)
            {
                running = value;
                animator.SetBool("Running", running);
            }
        }
    }
    Camera cameraSource;
    private void Start()
    {
        animator = GetComponent<Animator>();
        cameraSource = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        // 水平方向キー
        float x = Input.GetAxis("Horizontal");
        // 垂直方向キー
        float z = Input.GetAxis("Vertical");
        // 方向
        var direction = new Vector3(x, 0, z);
        // 移動用キーが押されていれば
        if (direction.magnitude > 0)
        {
            Vector3 cameraForward = Vector3.Scale(cameraSource.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 moveForward = cameraForward * z + cameraSource.transform.right * x;


            // 向きを変える
            transform.rotation = Quaternion.LookRotation(moveForward);
            // 前に移動する
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            Runing = true; // プロパティによるセット
        }
        else
        {
            Runing = false; // プロパティによるセット
        }
    }
}
