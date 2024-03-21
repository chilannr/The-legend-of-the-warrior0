using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
public class Sign : MonoBehaviour
{
    private PlayerInputControls playerInput;
    public GameObject signSprite;
    public IInteractable targetItem;

    private Animator anim;
    public Transform playerTransform;


    private bool canPress;
    private void Awake()
    {

         //anim = GetComponentInChildren<Animator>();
        //Debug.Log(signSprite.transform.localScale);
        anim = signSprite.GetComponent<Animator>();
        playerInput = new PlayerInputControls();
        playerInput.Enable();
    }
    private void OnEnable()
    {
        InputSystem.onActionChange += OnActionChange;
        playerInput.Gameplay.Confim.started += OnConfirm;
    }

 

    private void Update()
    {
        signSprite.GetComponent<SpriteRenderer>().enabled = canPress;
        signSprite.transform.localScale = playerTransform.localScale;
    }
    
    private void OnConfirm(InputAction.CallbackContext obj)
    {
        if (canPress)
        {
            targetItem.TriggerAction();
            GetComponent<AudioDefination>()?.PlayAudioClip();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            canPress = true;
            targetItem = collision.GetComponent<IInteractable>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canPress = false;
    } 
    private void OnActionChange(object arg1, InputActionChange actionChange)
    {
       if(actionChange == InputActionChange.ActionStarted)
        {
            //Debug.Log(((InputAction)arg1).activeControl.device);
            var d = ((InputAction)arg1).activeControl.device;
            switch (d.device)
            {
                case Keyboard:
                    anim.Play("keyboard");
                    break;
                case DualShockGamepad:
                    break;
            }
        }
    }
}
