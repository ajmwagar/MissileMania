namespace VRTK.Examples
{
    using UnityEngine;

    public class MenuManager : MonoBehaviour
    {
        public GameObject menuObject;


        private bool menuInit = false;
        private bool menuActive = false;

        private void Start()
        {
            GetComponent<VRTK_ControllerEvents>().AliasMenuOn += new ControllerInteractionEventHandler(DoMenuOn);
            GetComponent<VRTK_ControllerEvents>().AliasMenuOff += new ControllerInteractionEventHandler(DoMenuOff);
            menuInit = false;
            menuActive = false;
        }


        private void DoMenuOn(object sender, ControllerInteractionEventArgs e)
        {
            menuObject.SetActive(true);
            menuActive = true;
            ChangeTimeScale();

        }

        private void DoMenuOff(object sender, ControllerInteractionEventArgs e)
        {
            menuObject.SetActive(false);
            menuActive = false;
            ChangeTimeScale();

        }

        private void ChangeTimeScale()
        {
            if (Time.timeScale == 1.0F)
                Time.timeScale = 0.7F;
            else
                Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

    }
}