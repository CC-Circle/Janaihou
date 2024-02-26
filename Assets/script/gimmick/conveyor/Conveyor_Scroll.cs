using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor_Scroll : MonoBehaviour
{
    private Renderer m_renderer = null;
    [SerializeField] private float m_speed = 1.0f;


    private Vector2 m_offset = Vector2.zero;
    Material[] mats;//今回マテリアルが複数個あったので


    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        mats = m_renderer.materials;
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトの forward 方向に合わせて移動量を計算
        Vector3 forwardDirection = transform.forward;
        if (TIME_MANAGER.is_revtime)
        {   
            m_offset += Vector2.up * m_speed * Time.deltaTime;
        }
        else
        {
            m_offset -= Vector2.up * m_speed * Time.deltaTime;
        }
        // マテリアルに offset をセット
        mats[0].mainTextureOffset = m_offset;
    }
}
