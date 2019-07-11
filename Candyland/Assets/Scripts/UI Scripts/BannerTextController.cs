using System;
using UnityEngine;
using TMPro;

public class BannerTextController : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetText(string input)
    {
        text.text = input;
    }
}