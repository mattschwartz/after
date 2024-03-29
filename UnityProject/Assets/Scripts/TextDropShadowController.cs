﻿using UnityEngine;
using System.Collections;

public class TextDropShadowController : MonoBehaviour {

    public GUIText ShadowText;
    private GUIText Text;

    void Start()
    {
        Text = GetComponent<GUIText>();
        Text.pixelOffset = new Vector2(0, 2);
        ShadowText.pixelOffset = new Vector2(2, 0);
    }

    void FixedUpdate()
    {
       ShadowText.text = Text.text;
    }
}
