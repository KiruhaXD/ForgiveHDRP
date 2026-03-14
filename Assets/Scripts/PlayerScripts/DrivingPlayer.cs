using System;
using System.Collections;
using DG.Tweening;
using Scripts.PlayerScripts;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class DrivingPlayer : MonoBehaviour
{
    public const string HoldKeyF = "hold_key_f";
    public const string RigBuilderListCountKey = "rig_builder_list_count"; 

    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator carAnimator; 
    [SerializeField] AnimationClip playerAnimationClip;

    [SerializeField] Transform playerTransform;

    //[SerializeField] CharacterController characterController;

    public Image imageInteractHold;

    [SerializeField] RigBuilder rigBuilder;
    public Rigidbody rbDriver;

    //[HideInInspector]
    public bool isInCar = false;

    public int isHoldKeyF = 0; // false
    public int rigBuilderCount = 0;

    private void Awake()
    {
        /*if (PlayerPrefs.HasKey(HoldKeyF)) 
        {
            isHoldKeyF = PlayerPrefs.GetInt(HoldKeyF); // here isHoldKeyF equals 1 and so Image with hold key f not be show
            imageInteractHold.gameObject.SetActive(false);
        }
            
        if (PlayerPrefs.HasKey(RigBuilderListCountKey))
        {
            rigBuilderCount = PlayerPrefs.GetInt(RigBuilderListCountKey);

            for (int i = 0; i < rigBuilderCount; i++) 
            {
                rigBuilder.layers[i].active = false;
            }
        }*/

        if (isInCar == true) 
            playerAnimator.SetBool("isDriving", true);
        
    }

    private void Start()
    {
        imageInteractHold.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && imageInteractHold.fillAmount < 1 && imageInteractHold.gameObject.activeSelf == true
            && isHoldKeyF == 0)
        {
            imageInteractHold.fillAmount += 0.4f * Time.deltaTime;

            imageInteractHold.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 6f);


            if (imageInteractHold.fillAmount == 1)
            {
                imageInteractHold.gameObject.SetActive(false);
                ExitingCar();

                isHoldKeyF = 1; // hold key end

                //PlayerPrefs.SetInt(HoldKeyF, isHoldKeyF);
            }

        }

        else if(imageInteractHold.fillAmount < 1 && imageInteractHold.gameObject.activeSelf == true)
        {
            imageInteractHold.fillAmount -= 0.2f * Time.deltaTime;

            imageInteractHold.transform.DOScale(new Vector3(1f, 1f, 1f), 6f);
        }
    }

    public void ExitingCar() 
    {
        for (int i = 1; i < rigBuilder.layers.Count; i++) 
        {
            rigBuilder.layers[i].active = false;
            //PlayerPrefs.SetInt(RigBuilderListCountKey, rigBuilder.layers.Count);
        }

        carAnimator.SetBool("isOpenDoor", true);
        playerAnimator.SetBool("isExitingCar", true);
        StartCoroutine(EndPlayAnimationExitingCarCoroutine());

    }

    public void EnteringCar() 
    {
        playerAnimator.SetBool("isEnteringCar", true);
        //isInCar = true;
    }

    IEnumerator EndPlayAnimationExitingCarCoroutine() 
    {
        yield return new WaitForSeconds(7);

        //playerTransform.localPosition = new Vector3(108.5f, 19f, 175.5f);
        //playerTransform.localRotation = new Quaternion(0f, 90f, 0f, 90f);

        playerAnimator.SetBool("isIdle", true);
        playerAnimator.SetBool("isDriving", false);

        isInCar = false;
    }

    [ContextMenu("Reset Key Driver (Польз.)")]
    public void DeleteKeys() 
    {
        PlayerPrefs.DeleteKey(HoldKeyF);
        PlayerPrefs.DeleteKey(RigBuilderListCountKey);

        Debug.Log("Удаление ключей Водителя");
    }

}
