using System.Collections;
using System.Collections.Generic;
using ConstsEnums;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
[System.Serializable]
public struct KeyPair
{
    public InputSettings Key;
    public string Value;
}

[CreateAssetMenu(fileName = "KeyValues", menuName = "New KeyValueData")]
public class KeyValueData : ScriptableObject
{
    public List<KeyPair> KeyValues;
}