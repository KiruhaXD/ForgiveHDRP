using UnityEngine;

namespace Scripts.MissionsScripts
{
    public class ShowMissions : MonoBehaviour
    {
        [SerializeField] GameObject panelMissions;
        [SerializeField] GameObject[] arrayMissions;

        [SerializeField] GameObject[] arrayImagesItemsInteract;

        private void Start()
        {
            panelMissions.SetActive(false);
        }

        public void ShowFirstMission()
        {
            panelMissions.SetActive(true);
            arrayMissions[0].SetActive(true);
            arrayImagesItemsInteract[0].SetActive(true);
        }

        public void ShowSecondMission()
        {
            arrayMissions[1].SetActive(true);
            arrayImagesItemsInteract[1].SetActive(true);
        }

        public void ShowThirdMission()
        {
            arrayMissions[2].SetActive(true);
            arrayImagesItemsInteract[2].SetActive(true);
        }


    }
}
