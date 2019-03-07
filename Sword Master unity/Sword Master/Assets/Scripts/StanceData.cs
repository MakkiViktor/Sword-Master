using System.Collections;
using System.Collections.Generic;
using ConstsEnums;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public struct NamedStanceAnimation{
	public AnimationClip animation;
	public AnimationStates state;
}

[CreateAssetMenu(fileName = "Stance", menuName = "New Stance")]
public class StanceData : ScriptableObject
{
	public string stanceName;
	public List<NamedStanceAnimation> stanceAnimation; 
}