using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class turn_clock : MonoBehaviour
{

    public TIME_MANAGER time_manager;
    public bool enable_repop = true;
    public bool enable_revial = true;//アイテム取得後の再出現

    public GameObject effect;
    public GameObject effect_ui;

    public bool Enable_show_all_palam = false;

    public int recover_value = 1;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(0,2,0);
        //parent = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            this.transform.position = new Vector3(transform.position.x,transform.position.y+10,transform.position.z);

            StartCoroutine(DelayCoroutine(time_manager.repop_item_get, () =>
            {
                // n秒後にここの処理が実行される
                if (this.gameObject.transform.position.y > 9 && this.gameObject.GetComponent<turn_clock>().enable_revial == true)
                {
                    //Debug.Log("called");
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 10, this.gameObject.transform.position.z);
                }

            }));

            if (time_manager.debug_slider.value < 8)
            {
                
                time_manager.debug_slider.value = time_manager.debug_slider.value + recover_value;
                time_manager.current_clock_value = time_manager.max_clock / 8 * (time_manager.debug_slider.value + recover_value);
                Instantiate(effect,other.gameObject.transform.position,Quaternion.identity);
                effect_ui.GetComponent<ParticleSystem>().Play();
                
            }
        }
    }

    //遅延子ルーチン用
    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }

}
