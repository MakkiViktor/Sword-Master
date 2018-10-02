using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "New StanceDataBase", menuName = "StanceDatabase")]
public class StanceDatabase : ScriptableObject
{
	public List<StanceData> stanceList;
}