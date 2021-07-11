using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private StageInfo usedStage;

    private GameObject player;
    private bool selected = false;
    private Transform camTrans;
    public GameObject playerPrefab;
    private PlayerBase playerBase;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        camTrans = GameObject.FindGameObjectWithTag("CameraTransform").transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        if (StageController.Instance.ReturnStageInfo())
        {
            usedStage = StageController.Instance.ReturnStageInfo();
        }


        if(usedStage && !player)
        {
            Transform spawnPos = GameObject.FindGameObjectWithTag("Spawn").transform;
            CreatePlayer(spawnPos);
        }
    }

    public void InstantiatePlayerAtSpawn()
    {
        Transform spawnPos = GameObject.FindGameObjectWithTag("Spawn").transform;
        Destroy(player);
        CreatePlayer(spawnPos);
    }

    private void CreatePlayer(Transform spawnPos)
    {
        player = (GameObject)Instantiate(playerPrefab, spawnPos.position, Quaternion.identity);
        playerBase = player.GetComponent<PlayerBase>();
        CameraController.Instance.SetFollowTransform(player.transform);
        playerBase.SetPlayerCameraTransform(CameraController.Instance.transform);
    }
}

