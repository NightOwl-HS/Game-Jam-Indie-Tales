using UnityEngine;
[CreateAssetMenu(fileName = "New Stage", menuName = "Stages/New Stage")]
public class StageInfo : ScriptableObject
{
    public GameObject[] stageObjects;
    public int id;

}
