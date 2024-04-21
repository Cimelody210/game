using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar: MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _healthForegroundImage;
    public void UpdateHealthBar(HealthController healthController){
        _healthForegroundImage.fillAmount  = healthController.RemainingHealthPercentage;
    }
}