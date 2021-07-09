using UnityEngine;

public class TestBuilding : MonoBehaviour
{
    public GameObject placableBlueprintPrefab;
    private BlueprintObject tempObject;

    public static TestBuilding Instance;

    private Vector3 tempPos;
    private bool selectedGhost = false;

    public LayerMask placableLayer;

    private Camera cam;

    private void Awake()
    {
        Instance = this;        
    }
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Debug.Log(placableBlueprintPrefab);
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(camRay, out RaycastHit rayHit, float.MaxValue, placableLayer)){
            tempPos = new Vector3(rayHit.point.x, rayHit.point.y + placableBlueprintPrefab.transform.localScale.y / 2, rayHit.point.z);           
        }

        if (Input.GetMouseButtonDown(1) && !selectedGhost)
        {
            PlaceBlueprintObject(tempPos);
            selectedGhost = true;
        }
        else if(Input.GetMouseButtonDown(1) && selectedGhost)
        {
            Destroy(tempObject.gameObject);
            selectedGhost = false;
        }
        
        if (Input.GetMouseButtonDown(0) && tempObject){
            tempObject.CreatePlacable();
            selectedGhost = false;
        }
        
    }

    public Vector3 mousePos()
    {
        return tempPos;
    }

    private void PlaceBlueprintObject(Vector3 placePos){
        tempObject = Instantiate(placableBlueprintPrefab, placePos, Quaternion.identity).GetComponent<BlueprintObject>();
    }
}
