using System;
using TMPro;
using UnityEngine;

public class PhoneNumber : MonoBehaviour
{
    public TextMeshProUGUI text;
    private long left;
    private long right;
    private long mid;

    void Start()
    {
        left = 0;
        right = 9999999999; // max possible number
        UpdateMid();
    }

    public void Reset()
    {
        left = 0;
        right = 9999999999; // max possible number
        UpdateMid();
    }

    private void UpdateMid()
    {
        mid = (left + right) / 2;
        text.text = mid.ToString();
        Debug.Log($"Range: {left} - {right}, Mid: {mid}");
    }

    public void Binary(int det)
    {
        // det: 0 = too high, 1 = too low
        if (det == 0)
        {
            right = mid - 1; // search lower half
        }
        else if (det == 1)
        {
            left = mid + 1; // search upper half
        }
        UpdateMid();
    }
}
