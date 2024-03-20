using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject keyobject;
    Key key;
    private Animator animain;
    void Start()
    {
        animain = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        key = keyobject.GetComponent<Key>();
        if (key.Getkeylocal == true)
        {
            animain.SetBool("AnimaStart", true);
            Key.Getkeyglobal = false;//全体の鍵取得情報を削除する
            key.Open = true;//鍵の方を破壊する
            //Destroy(this.gameObject);
        }
    }
    public void OnAnimationEnd()
    {
        Destroy(this.gameObject);
    }
}
