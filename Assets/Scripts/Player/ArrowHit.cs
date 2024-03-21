using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ArrowHit : MonoBehaviour
{
    public GameObject arrowPrefab;
    public PlayerInputControls inputcontrtol;
    public PlayerController playerController;
    private void Awake()
    {
        inputcontrtol = new PlayerInputControls();
        inputcontrtol.Gameplay.ESkill.started += Shoot;
     
    }
    private void OnEnable()
    {
        inputcontrtol.Enable();
    }
    private void OnDisable()
    {
        inputcontrtol.Disable();
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        if (!playerController.isAttack)
        {
            //transform.position = playerController.transform.position;
            //Instantiate(arrowPrefab, transform.position,transform.rotation);
            
            GameObject newArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
          
            if (playerController.transform.localScale.x > 0)
            {
                newArrow.transform.right = transform.right;
            }
            else
                newArrow.transform.right = -transform.right;
        }
    }
}
