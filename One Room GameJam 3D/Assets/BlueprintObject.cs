using UnityEngine;

public class BlueprintObject : MonoBehaviour{
    public GameObject placablePrefab;
    private TestBuilding building;

    private void Awake()
    {
        building = TestBuilding.Instance;
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
