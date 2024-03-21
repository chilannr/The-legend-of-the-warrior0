using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public PlayerStatBar playerStatBar;
    [Header("ÊÂ¼þ¼àÌý")]
    public CharacterEventOS healthEvent;
    private void OnEnable()
    {
        healthEvent.OnEventRaised += OnhealthEvent;
    }

    private void OnhealthEvent(Character character)
    {
        var persentage = character.currentHealth / character.maxHealth;
        playerStatBar.OnHealthChange(persentage);
    }

    private void OnDisable()
    {
        healthEvent.OnEventRaised -= OnhealthEvent;
    }

}
