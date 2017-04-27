using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrackedIndexer : MonoBehaviour {
    public bool IndexerEnabled;
    public TextMesh IndexerText;
    public GameObject UndefinedPrefab;
    public GameObject CameraRig;
    public SteamVR_TrackedObject SonicScrewdriver;
    public SteamVR_TrackedObject BatTroller;
    public SteamVR_TrackedObject TrackedTurret;
    public SteamVR_TrackedObject TrackedShield;

    int currentDevice;
    int totalDevices;

    void OnEnable()
    {
        currentDevice = 1;
        totalDevices = 0;

        if (IndexerEnabled)
        {
            for (int i = 0; i < SteamVR.connected.Length; i++)
            {
                if (SteamVR.connected[i])
                {
                    var deviceClass = OpenVR.System.GetTrackedDeviceClass((uint)i);
                    if (deviceClass == ETrackedDeviceClass.Controller ||
                        deviceClass == ETrackedDeviceClass.GenericTracker)
                    {
                        GameObject trackedDevice = Instantiate(UndefinedPrefab);
                        trackedDevice.transform.parent = CameraRig.transform;
                        trackedDevice.SetActive(true);
                        trackedDevice.BroadcastMessage("SetDeviceIndex", (int)i, SendMessageOptions.DontRequireReceiver);
                        totalDevices++;
                    }
                }
            }

            SonicScrewdriver.index = SteamVR_TrackedObject.EIndex.None;
            BatTroller.index = SteamVR_TrackedObject.EIndex.None;
            TrackedTurret.index = SteamVR_TrackedObject.EIndex.None;
            TrackedShield.index = SteamVR_TrackedObject.EIndex.None;

            SonicScrewdriver.gameObject.SetActive(false);
            BatTroller.gameObject.SetActive(false);
            TrackedTurret.gameObject.SetActive(false);
            TrackedShield.gameObject.SetActive(false);

            IndexerText.text = "Place Bat";
        }
        else
        {
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
                case 1:
                    Debug.Log("Setting bat to: " + trackedObjectIndex);
                    BatTroller.gameObject.SetActive(true);
                    BatTroller.index = trackedObjectIndex;
                    trackedObject.SetActive(false);
                    IndexerText.text = "Place Turret";
                    currentDevice++;
                    break;
                case 2:
                    Debug.Log("Setting turret to: " + trackedObjectIndex);
                    TrackedTurret.gameObject.SetActive(true);
                    TrackedTurret.index = trackedObjectIndex;
                    trackedObject.SetActive(false);
                    IndexerText.text = "Place Shield";
                    currentDevice++;
                    break;
                case 3:
                    Debug.Log("Setting shield to: " + trackedObjectIndex);
                    TrackedShield.gameObject.SetActive(true);
                    TrackedShield.index = trackedObjectIndex;
                    trackedObject.SetActive(false);
                    IndexerText.text = "Place Sonic Screwdriver";
                    currentDevice++;
                    break;
                case 4:
                    Debug.Log("Setting Sonic to: " + trackedObjectIndex);
                    SonicScrewdriver.gameObject.SetActive(true);
                    SonicScrewdriver.index = trackedObjectIndex;
                    trackedObject.SetActive(false);
                    currentDevice++;
                    break;
            }

            Debug.Log("Device " + currentDevice + "of " + totalDevices + "indexed.");
            if (currentDevice > totalDevices)
            {
                gameObject.SetActive(false);
                enabled = false;
            }
        }
    }
}
