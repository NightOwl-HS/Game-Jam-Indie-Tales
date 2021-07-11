using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anomaly : MonoBehaviour{

    public int loadStageID;

    private void Update()
    {
        float z = Mathf.PingPong(Time.time / 2, 1f);
        Vector3 axis = new Vector3(1f, 1f, z);
        transform.Rotate(axis, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StageController.Instance.LoadStage(loadStageID);
        }
    }
}
