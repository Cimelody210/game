using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController: MonoBehaviour
{
    public bool IsInvicible {get; set;}
    public UnityEvent OnDied;
    public UnityEvent OnDamage;
    public UnityEvent OnHealthChanged;

    public void TakeManage(float damageAmount)
    {
        if(_currentHealth == 0)
            return;
        if(IsInvicible)
            return;
        audioSource.PlayOneShot(damageSound);
        _currentChanged -= damageAmount;
        OnHealthChanged.Invoke();
    }
}
