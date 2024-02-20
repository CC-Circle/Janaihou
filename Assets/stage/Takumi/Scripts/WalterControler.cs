using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalterControlert : MonoBehaviour
{
    private Material _mat;
    [SerializeField] private float walter_speed;
    [SerializeField] private bool Xscroll = false;//trueでx,falseでy方向にスクロール
    private Vector2 walter_moveX,walter_moveY;
    // Update is called once per frame
    void Start()
    {

        _mat = GetComponent<Renderer>().material;
        walter_moveX = new Vector2(walter_speed, 0);
        walter_moveY = new Vector2(0, walter_speed);
        _mat.SetVector("_Scroll_A", -walter_moveY);
        _mat.SetVector("_Scroll_B", -walter_moveY);
    }
    void Update()
    {

        if (Xscroll == true)//xスクロール
        {
            
            if (TIME_MANAGER.is_revtime == true)
            {
                _mat.SetVector("_Scroll_A", walter_moveX);
                _mat.SetVector("_Scroll_B", walter_moveX);
            }
            else
            {
                _mat.SetVector("_Scroll_A", -walter_moveX);
                _mat.SetVector("_Scroll_B", -walter_moveX);
            }

        }
        else//yスクロール
        {
            

            if (TIME_MANAGER.is_revtime == true)
            {
                _mat.SetVector("_Scroll_A", walter_moveY);
                _mat.SetVector("_Scroll_B", walter_moveY);
            }
            else
            {
                _mat.SetVector("_Scroll_A", -walter_moveY);
                _mat.SetVector("_Scroll_B", -walter_moveY);
            }

        }

    }
}
