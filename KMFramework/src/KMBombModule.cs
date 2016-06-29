﻿using UnityEngine;

/*
 * This class acts as a proxy for the game's bomb module, don't subclass but instead 
 */
public class KMBombModule : MonoBehaviour
{
    
    /// <summary>
    /// The identifier for the module as referenced in missions. e.g. "BigButton"
    /// </summary>
    public string ModuleType;

    /// <summary>
    /// The nice display name shown to players. e.g. "The Button"
    /// </summary>
    public string ModuleDisplayName;

    public delegate bool KMPassEvent();
    public delegate bool KMStrikeEvent();

    public delegate void KMModuleActivateEvent();
    public delegate void KMModuleDeactivateEvent();

    public delegate int KMRuleGenerationSeedDelegate();

    //DO NOT USE IN MOD, Used by the game to hook into the bomb
    public KMStrikeEvent OnStrike;
    public KMPassEvent OnPass;
    public KMRuleGenerationSeedDelegate GetRuleGenerationSeedHandler;

    //Used by the mod, hook into these to properly activate and deactivate your custom module
    public KMModuleActivateEvent OnActivate;
    public KMModuleDeactivateEvent OnDeactivate;

    //Call this when the entire module is solved
    public void HandlePass()
    {
        if (OnPass != null)
        {
            OnPass();
        }
    }

    //Call this on any mistake that you want to cause a bomb strike
    public void HandleStrike()
    {
        if (OnStrike != null)
        {
            OnStrike();
        }
    }

    public int GetRuleGenerationSeed()
    {
        if (GetRuleGenerationSeedHandler != null)
        {
            return GetRuleGenerationSeedHandler();
        }

        return -1;
    }
}