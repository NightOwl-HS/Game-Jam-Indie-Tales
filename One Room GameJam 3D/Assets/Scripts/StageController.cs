using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public List<StageInfo> stages = new List<StageInfo>();
    //public List<GameObject[]> list = new List<GameObject[]>();

    public static StageController Instance;

    private GameController controller;

    private StageInfo stageUsing;

    private List<GameObject> stageUsingElements = new List<GameObject>();
    //public GameObject[][] stages;

    public StageInfo ReturnStageInfo()
    {
        return stageUsing;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        controller = GameController.Instance;
        LoadStage(1);   
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
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LoadStage(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LoadStage(4);
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
        if (!stageUsing) return;
        for (int i = 0; i < stageUsing.stageObjects.Length; i++)
        {
            Destroy(stageUsingElements[i].gameObject);
            stageUsingElements.Remove(stageUsingElements[i]);
        }
    }

    private void LoadAllStageObjects()
    {
        for (int i = 0; i < stageUsing.stageObjects.Length; i++)
        {
            GameObject temp = (GameObject)Instantiate(stageUsing.stageObjects[i], stageUsing.stageObjects[i].transform.position, stageUsing.stageObjects[i].transform.rotation);
            stageUsingElements.Add(temp);
            controller.InstantiatePlayerAtSpawn();
            Debug.Log("Yeet!");
        }
    }
}
