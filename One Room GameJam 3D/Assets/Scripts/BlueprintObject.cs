using UnityEngine;

public class BlueprintObject : MonoBehaviour{
    public GameObject placablePrefab;
    private BuildingSystem building;

    private void Awake()
    {
        building = BuildingSystem.Instance;
    }

    private void Update()
    {
        transform.position = building.mousePos();
    }

    public void CreatePlacable()
    {
        Instantiate(placablePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
