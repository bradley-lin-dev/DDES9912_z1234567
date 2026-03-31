using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;


public class KeyboardMap : MonoBehaviour
{
    [SerializeField]
    Transform[] keys;

    [SerializeField]
    string textToType = "HELLO WORLD";
    
    Dictionary<char, Transform> keyLocationMap;

    Vector3[] keysToPress;

    enum KeyboardChars
    {
        Q,
        W,
        E,
        R,
        T,
        Y,
        U,
        I,
        O,
        P,
        A,
        S,
        D,
        F,
        G,
        H,
        J,
        K,
        L,
        Z,
        X,
        C,
        V,
        B,
        N,
        M
    }

    void Start()
    {
        keyLocationMap = new Dictionary<char, Transform>();
        for (int i = 0; i < Enum.GetNames(typeof(KeyboardChars)).Length; i++)
        {
            keyLocationMap.Add(((KeyboardChars)i).ToString()[0], keys[i]);
        }

        keyLocationMap.Add((char)32, keys[26]);
        keyLocationMap.Add((char)8, keys[27]);

        for (char i = 'A'; i <= 'Z'; i++)
        {
            Debug.Log("Key: " + ((KeyboardChars)i) + ", Transform: " + keyLocationMap[i].name + ", Position: " + keyLocationMap[i].position);
        }

        keysToPress = new Vector3[textToType.Length];
        for (int i = 0; i < textToType.Length; i++)
        {
            keysToPress[i] = keyLocationMap[textToType[i]].position;
        }
    }

    void PutChildTransforms()
    {
        keys = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            keys[i] = transform.GetChild(i);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
