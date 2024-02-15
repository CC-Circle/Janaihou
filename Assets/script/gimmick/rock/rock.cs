using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    // プレハブ格納用
    public GameObject CubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateRock());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreateRock()
    {
        while (true)
        {
            // 生成位置
            Vector3 pos = new Vector3(1.67f, 7.76f, 22.78f);
            // プレハブを指定位置に生成
            Instantiate(CubePrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(3.0f);

        }
    }
}

