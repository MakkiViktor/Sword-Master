using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class StanceData : ScriptableObject
{
	#if UNITY_EDITOR
	[MenuItem("Tools/Create/Stance Data")]
	public static void Create()
	{
		StanceData asset = CreateInstance<StanceData>();
		AssetDatabase.CreateAsset(asset, "Assets/StanceData.asset");
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}
	#endif

	public string stanceName;
	public int randomNumberAboutThisStance;
}