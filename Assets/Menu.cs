using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Menu1;
    public bool MenuOn;
    public bool triggerButtonDown = false;
    public bool menuButtonDown = false;
    public float TimePassed = 0.00f;
    public int Indexed = 0;
    
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId Axis0 = Valve.VR.EVRButtonId.k_EButton_Axis0;
    private Valve.VR.EVRButtonId Axis1 = Valve.VR.EVRButtonId.k_EButton_Axis1;
    private Valve.VR.EVRButtonId Axis2 = Valve.VR.EVRButtonId.k_EButton_Axis2;
    private Valve.VR.EVRButtonId Axis3 = Valve.VR.EVRButtonId.k_EButton_Axis3;
    private Valve.VR.EVRButtonId Axis4 = Valve.VR.EVRButtonId.k_EButton_Axis4;
    private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;

    private SteamVR_Controller.Device controller
    {

        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);

        }

    }

    private SteamVR_TrackedObject trackedObj;

    void Start()
    {
        MenuOn = true;
      
        // trackedObj = GetComponent();

    }

    public void backClick()
    {
        MenuOn = !MenuOn;
        Menu1.SetActive(MenuOn);
        Debug.Log("Fire!");
    }
    void Update()
    {
        TimePassed = Time.deltaTime;
        if (controller == null)
        {

            Debug.Log("Controller not initialized");

            return;

        }
       
        menuButtonDown = controller.GetPress(menuButton);

        if (menuButtonDown)
        {
            MenuOn = !MenuOn;
            Menu1.SetActive(MenuOn);
            Debug.Log("Fire!");
        }
    }
}





