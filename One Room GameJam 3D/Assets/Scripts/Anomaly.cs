using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anomaly : MonoBehaviour{

    public int loadStageID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StageController.Instance.LoadStage(loadStageID);
        }
    }
}
