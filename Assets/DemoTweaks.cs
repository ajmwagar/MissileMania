using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoTweaks : MonoBehaviour
{
    public GameObject IndexerSphere;
    public TrackedIndexer IndexerScript;
    public Transform TerrainTransform;

    public KeyCode StartIndex = KeyCode.I;
    public KeyCode FloorUp = KeyCode.UpArrow;
    public KeyCode FloorDown = KeyCode.DownArrow;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(StartIndex))
        {
            if (IndexerSphere.activeInHierarchy)
            {
                Debug.Log("Stopping indexing...");
                IndexerScript.enabled = false;
                IndexerSphere.SetActive(false);
            }
            else
            {
                Debug.Log("Starting indexing...");
                IndexerSphere.SetActive(true);
                IndexerScript.enabled = true;
            }
        }

        if (Input.GetKeyDown(FloorUp))
        {
            Debug.Log("Moving floor up...");
            Vector3 newPosition = new Vector3(TerrainTransform.localPosition.x, TerrainTransform.localPosition.y + 0.01f, TerrainTransform.localPosition.z);
            TerrainTransform.position = newPosition;
        }

        if (Input.GetKeyDown(FloorDown))
        {
            Debug.Log("Moving floor down...");
            Vector3 newPosition = new Vector3(TerrainTransform.localPosition.x, TerrainTransform.localPosition.y - 0.01f, TerrainTransform.localPosition.z);
            TerrainTransform.position = newPosition;
        }
    }
}