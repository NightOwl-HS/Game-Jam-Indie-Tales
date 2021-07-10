using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public List<StageInfo> stages = new List<StageInfo>();
    //public List<GameObject[]> list = new List<GameObject[]>();

    public static StageController Instance;
    private StageInfo stageUsing;
    //public GameObject[][] stages;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        stageUsing = stages[0];    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadStage(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadStage(2);
        }
    }

    public void LoadStage(int givenIndex)
    {
        for (int i = 0; i < stages.Count; i++)
        {
            if(stages[i].id == givenIndex)
            {
                DestroyAllStageObjects();
                stageUsing = stages[i];
                LoadAllStageObjects();
            }
        }
    }

    private void DestroyAllStageObjects()
    {
        for (int i = 0; i < stageUsing.stageObjects.Length; i++)
        {
            Destroy(stageUsing.stageObjects[i]);
        }
    }

    private void LoadAllStageObjects()
    {
        for (int i = 0; i < stageUsing.stageObjects.Length; i++)
        {
            Instantiate(stageUsing.stageObjects[i], stageUsing.stageObjects[i].transform.position, stageUsing.stageObjects[i].transform.rotation);
            Debug.Log("Yeet!");
        }
    }
}