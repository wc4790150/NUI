﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using NUI;
using System;

public class TextSample : MonoBehaviour {
    private NText text;
    private NInputField input;

	// Use this for initialization
	void Start () {
        text = transform.Find("NText").GetComponent<NText>();
        input = transform.Find("NInputField").GetComponent<NInputField>();
        transform.Find("ButtonAppendText").GetComponent<Button>().onClick.AddListener(OnBtnAppendText);
        transform.Find("ButtonAppendLink").GetComponent<Button>().onClick.AddListener(OnBtnAppendLink);
        transform.Find("ButtonAppendImage").GetComponent<Button>().onClick.AddListener(OnBtnAppendImage);
        transform.Find("ButtonInsertText").GetComponent<Button>().onClick.AddListener(OnBtnInsertText);
        transform.Find("ButtonInsertLink").GetComponent<Button>().onClick.AddListener(OnBtnInsertLink);
        transform.Find("ButtonInsertImage").GetComponent<Button>().onClick.AddListener(OnBtnInsertImage);
        text.OnLink = OnLink;
    }

    void OnBtnAppendText()
    {
        input.AppendLink("Append Text", fontSize: 32);
    }

    void OnBtnAppendLink()
    {
        input.AppendLink("LinkText", "linkParam", underlineColor: Color.red);
    }

    void OnBtnAppendImage()
    {
        input.AppendImage(0);
    }

    void OnBtnInsertText()
    {
        input.InsertLink("insert text", input.caretPosition, null);
    }

    void OnBtnInsertLink()
    {
        input.InsertLink("insert link", input.caretPosition, "param2");
    }

    void OnBtnInsertImage()
    {
        input.InsertImage(0, input.caretPosition, animLength: 5);
    }

    void OnLink(string param)
    {
        Debug.Log("超链接:" + param);
    }

    static int Int32Parse(string text)
    {
        int result = 0;
        if (Int32.TryParse(text, out result))
            return result;
        return 0;
    }

    void OnBtnAsset()
    {
#if UNITY_EDITOR
        AssetDatabase.CreateAsset(new NTextSpritePackage(), "Assets/TextSpritePackage.asset");
#endif
    }
}
