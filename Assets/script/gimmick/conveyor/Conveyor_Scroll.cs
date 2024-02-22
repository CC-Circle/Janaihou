using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor_Scroll : MonoBehaviour
{
    private Renderer m_renderer = null;
    [SerializeField] private float m_speed = 1.0f;

    private Vector2 m_offset = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトの forward 方向に合わせて移動量を計算
        Vector3 forwardDirection = transform.forward;
        m_offset += new Vector2(forwardDirection.x, forwardDirection.z) * m_speed * Time.deltaTime;

        // マテリアルに offset をセット
        m_renderer.material.mainTextureOffset = m_offset;
    }
}
