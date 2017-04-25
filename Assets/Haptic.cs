using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NullSpace.SDK;


public class Haptic : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

        Heartbeat = StartCoroutine(MyHeartbeat());
    }

    Coroutine Heartbeat;
    bool IsHeartBeating = false;

    IEnumerator MyHeartbeat()
    {
        IsHeartBeating = true;
        var seq = new HapticSequence();
        //seq.AddEffect(0.0, new CodeEffect("double_click", 1 - (playerHealth / playerMaxHealth), (playerMaxHealth / playerHealth)));
      //  seq.AddEffect(0.0, new HapticEffect("double_click",0.6f));
        while (IsHeartBeating)
        {
            seq.Play(AreaFlag.Chest_Left);
            yield return new WaitForSeconds(1.0f);
            //yield return new WaitForSeconds((playerHealth / playerMaxHealth));
        }
    }

    // Update is called once per frame
    void Update () {

    /*    if (Input.GetKeyUp(KeyCode.T))
        {
            var seq = new HapticSequence();
         //  seq.AddEffect(0.0, new CodeEffect("double_click", 1 - (playerHealth / playerMaxHealth), (playerMaxHealth / playerHealth)));
            seq.AddEffect(0.0, new CodeEffect("double_click"));
            seq.Play(AreaFlag.All_Areas);
        
        }*/

    }

    void OnCollisionEnter(Collision collision)
    {
        var seq = new HapticSequence();
        //  seq.AddEffect(0.0, new CodeEffect("double_click", 1 - (playerHealth / playerMaxHealth), (playerMaxHealth / playerHealth)));
        //seq.AddEffect(0.0, new HapticEffect("double_click",0.9f));
        seq.Play(AreaFlag.All_Areas);
    }
}
