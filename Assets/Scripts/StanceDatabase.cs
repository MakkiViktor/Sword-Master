using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StanceDatabase : ScriptableObject
{
	#if UNITY_EDITOR
	[MenuItem("Tools/Create/Stance Database")]
	public static void Create()
	{
		StanceDatabase asset = CreateInstance<StanceDatabase>();
		AssetDatabase.CreateAsset(asset, "Assets/StaceDatabase.asset");
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}
	#endif

	public List<StanceData> stanceList;
}