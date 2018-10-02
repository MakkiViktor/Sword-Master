using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "New Stance", menuName = "Stance")]
public class StanceData : ScriptableObject
{
	public Animation UpperCut;
	public Animation UpperParry;
	public Animation RightCut;
	public Animation RightParry;
	public Animation LeftCut;
	public Animation LeftParry;
}