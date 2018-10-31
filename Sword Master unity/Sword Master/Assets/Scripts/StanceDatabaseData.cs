using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "New StanceDatabase", menuName = "StanceDatabase")]
public class StanceDatabase : ScriptableObject
{
	public string StanceDBname;
	public List<StanceData> stanceList;
}