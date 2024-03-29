using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cntBystander : MonoBehaviour
{
    public int value = 0; // 値を保持する変数

    // 値を増やす関数
    public void IncreaseValue()
    {
        value += 1;
    }

    // 値を減らす関数
    public void DecreaseValue()
    {
        value -= 1;
    }

    // 値を取得する関数
    public int GetValue()
    {
        return value;
    }
}
