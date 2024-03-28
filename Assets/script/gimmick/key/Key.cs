using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Key : MonoBehaviour
{
    private Vector3 startposition;//初期位置を記憶
    private Vector3 startrotation;//初期の角度を保存
    public bool mode = false;//false:ある鍵Aを持った状態である鍵Bに触れても何も起きない true: 最後に触った鍵に上書きされる
    [SerializeField] private Vector3 keyposition = new Vector3(0,0,-1);//プレイヤーの子オブジェクトになった際の座標
    [HideInInspector] public static bool Getkeyglobal = false;//全体の鍵取得情報
    [HideInInspector] public bool Getkeylocal = false;//この鍵取得情報
    [HideInInspector] public bool Open = false;//鍵消滅
    private BoxCollider boxcollider;
    // Start is called before the first frame update
    void Start()
    {
        startposition = this.transform.position;
        startrotation = this.transform.eulerAngles;
        boxcollider = GetComponent <BoxCollider>();
        boxcollider.isTrigger = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (mode == false)
        {
            if (Getkeylocal)
            {
                this.transform.localPosition = keyposition;//鍵取を持っている時のの鍵の位置を設定
            }
            if (Open)//
            {
                Destroy(this.gameObject);
            }
        }
        else
        {

            if (Getkeylocal)
            {
                this.transform.localPosition = keyposition;//鍵取を持っている時のの鍵の位置を設定
            }
            else
            {
                //オブジェクトの親子関係を解除し元の位置に戻す
                this.transform.parent = null;
                this.transform.position = startposition;
                this.transform.eulerAngles = startrotation;
            }
            if (Getkeyglobal)
            {
                Getkeylocal = false;
            }
            if (Open)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (mode == false)
            {
                if (Getkeyglobal == false)
                {
                    //鍵をプレイヤーの子オブジェクトにする
                    transform.parent = GameObject.Find("SD_unitychan_humanoid").transform;
                    Getkeyglobal = true;
                    Getkeylocal = true;
                }
            }
            else
            {
                //鍵の取得状況を解除
                if (Getkeyglobal)
                {
                    Getkeyglobal = false;
                }
                else
                {
                    Getkeyglobal = true;
                }
                //鍵を取得
                Getkeylocal = true;
                transform.parent = GameObject.Find("SD_unitychan_humanoid").transform;
            }
        }
    }
}