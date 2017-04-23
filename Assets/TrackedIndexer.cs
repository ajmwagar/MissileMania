using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedIndexer : MonoBehaviour {
    public TextMesh IndexerText;
    public SteamVR_TrackedObject BatTroller;
    public SteamVR_TrackedObject TrackedTurret;
    public SteamVR_TrackedObject TrackedShield;

    int currentDevice = 3;

    void OnTriggerEnter(Collider trackedObjectCollider)
    {
        if(trackedObjectCollider.gameObject.GetComponentInParent<SteamVR_TrackedObject>() != null && trackedObjectCollider.gameObject.tag == "UndefinedTracker" )
        {
            GameObject trackedObject = trackedObjectCollider.gameObject.transform.parent.gameObject;
            SteamVR_TrackedObject.EIndex trackedObjectIndex = trackedObjectCollider.gameObject.GetComponentInParent<SteamVR_TrackedObject>().index;
            if (trackedObjectIndex == SteamVR_TrackedObject.EIndex.Hmd)
            {
                Debug.Log("Ignoring HMD");
                return;
            }

            switch (currentDevice)
            {
                case 3:
                    Debug.Log("Setting bat to: " + trackedObjectIndex);
                    BatTroller.index = trackedObjectIndex;
                    trackedObject.SetActive(false);
                    IndexerText.text = "Place Turret";
                    currentDevice++;
                    break;
                case 4:
                    Debug.Log("Setting turret to: " + trackedObjectIndex);
                    TrackedTurret.index = trackedObjectIndex;
                    trackedObject.SetActive(false);
                    IndexerText.text = "Place Shield";
                    currentDevice++;
                    break;
                case 5:
                    Debug.Log("Setting shield to: " + trackedObjectIndex);
                    TrackedShield.index = trackedObjectIndex;
                    trackedObject.SetActive(false);
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
