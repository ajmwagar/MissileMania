using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedIndexer : MonoBehaviour {
    public bool IndexerEnabled;
    public TextMesh IndexerText;
    public GameObject UndefinedTrackers;
    public SteamVR_TrackedObject BatTroller;
    public SteamVR_TrackedObject TrackedTurret;
    public SteamVR_TrackedObject TrackedShield;

    int currentDevice = 3;

    void OnEnable()
    {
        if (IndexerEnabled)
        {
            BatTroller.index = SteamVR_TrackedObject.EIndex.None;
            TrackedTurret.index = SteamVR_TrackedObject.EIndex.None;
            TrackedShield.index = SteamVR_TrackedObject.EIndex.None;

            BatTroller.gameObject.SetActive(false);
            TrackedTurret.gameObject.SetActive(false);
            TrackedShield.gameObject.SetActive(false);

            UndefinedTrackers.SetActive(true);
        } else
        {
            UndefinedTrackers.SetActive(false);
            gameObject.SetActive(false);
        }
    }

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
                    BatTroller.gameObject.SetActive(true);
                    BatTroller.index = trackedObjectIndex;
                    trackedObject.SetActive(false);
                    IndexerText.text = "Place Turret";
                    currentDevice++;
                    break;
                case 4:
                    Debug.Log("Setting turret to: " + trackedObjectIndex);
                    TrackedTurret.gameObject.SetActive(true);
                    TrackedTurret.index = trackedObjectIndex;
                    trackedObject.SetActive(false);
                    IndexerText.text = "Place Shield";
                    currentDevice++;
                    break;
                case 5:
                    Debug.Log("Setting shield to: " + trackedObjectIndex);
                    TrackedShield.gameObject.SetActive(true);
                    TrackedShield.index = trackedObjectIndex;
                    trackedObject.SetActive(false);
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
