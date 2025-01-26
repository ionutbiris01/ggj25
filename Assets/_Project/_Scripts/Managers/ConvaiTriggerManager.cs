using _Project._Scripts.Managers;
using Convai.Scripts.Runtime.Features;
using System;
using UnityEngine;
using static Enums;

public class ConvaiTriggerManager : MonoBehaviour
{
    [SerializeField] private NarrativeDesignTrigger T_Introduction;
    [SerializeField] private NarrativeDesignTrigger T_00_03;
    [SerializeField] private NarrativeDesignTrigger T_03_07;
    [SerializeField] private NarrativeDesignTrigger T_07_10;
    [SerializeField] private NarrativeDesignTrigger T_Deceptive;
    [SerializeField] private NarrativeDesignTrigger T_Thrutful;

    private ConvaiTriggerType lastTriggerInvoked = ConvaiTriggerType.None;

    public bool playerIsDeceptive;

    public void SetPlayerAsDeceptive()
    {
        Debug.LogError("Player is deceptive");
        playerIsDeceptive = true;
    }
    public void SetPlayerAsTruthful()
    {
        Debug.LogError("Player is truthful");
        playerIsDeceptive = false;
    }
    public void TriggerResultPanelEvent()
    {
        Debug.LogError("End");
        EventManager.ToggleResultsPanel(true, playerIsDeceptive);
    }
    private void OnEnable()
    {
        EventManager.OnConvaiTriggered += InvokeConvaiTrigger;
        //EventManager.OnCoffeCupIntensityChanged += CheckSectionChanged;
    }
    private void OnDisable()
    {
        EventManager.OnConvaiTriggered -= InvokeConvaiTrigger;
        //EventManager.OnCoffeCupIntensityChanged -= CheckSectionChanged;
    }
    public void CheckSectionChanged(float _intensity)
    {
        if(_intensity < 0.05f)
        {
            InvokeConvaiTrigger(ConvaiTriggerType.T_Deceptive);
        }
        else if (_intensity >= 0.05f && _intensity < 0.3f)
        {
            InvokeConvaiTrigger(ConvaiTriggerType.T_00_03);
        }
        else if (_intensity >= 0.3f && _intensity < 0.7f)
        {
            InvokeConvaiTrigger(ConvaiTriggerType.T_03_07);
        }
        else if (_intensity >= 0.7f && _intensity < 0.95f)
        {
            InvokeConvaiTrigger(ConvaiTriggerType.T_07_10);
        }
        else if (_intensity >= 0.95f)
        {
            InvokeConvaiTrigger(ConvaiTriggerType.T_Truthful);
        }
    }
    public void InvokeConvaiTrigger(ConvaiTriggerType convaiTriggerType)
    {
        if(convaiTriggerType == lastTriggerInvoked)
        {
            Debug.LogWarning($"Trying to trigger an already active section: {convaiTriggerType}");
            return; 
        }

        string variableName = convaiTriggerType.ToString();

        var field = GetType().GetField(variableName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        if (field != null)
        {
            NarrativeDesignTrigger trigger = field.GetValue(this) as NarrativeDesignTrigger;

            if (trigger != null)
            {
                trigger.InvokeSelectedTrigger();
                lastTriggerInvoked = convaiTriggerType;
                Debug.Log($"Triggered: {convaiTriggerType}");
            }
            else
            {
                Debug.LogError($"Field {variableName} is not assigned in the inspector.");
            }
        }
        else
        {
            Debug.LogError($"No field found for {variableName}.");
        }
    }
}

