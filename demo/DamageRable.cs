using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.Drawing;
using Unity.VisualScripting;

public class DamageRable: MonoBehaviour
{
    [SerializeField]
    private bool isInvicible =false;
    public float invicibilityTime  = 0.25f;
    void Awake()
    {
        buttons = GetComponentInChilren<Button>();
        textMeshPro = GetComponentInChilren<TextMeshPro>();
        HideButtons();
    }
    public bool Hit(int damage, Vector2 knockback)
    {
        if(isLive && !isInvicible)
        {
            Health -= damage;
            isInvicible = true;
            animator.SetTrigger(AnimationString.hitTrigger);
            LockVelocity  = true;
            damagehit?.Invoke(damage, knockback);
            CharacterEnvents.characterDamaged.Invoke(gameObject, damage);

            if (Health <= 0)
            {
                scenceManager.ShowButtons();
            }
            else if(gameObject.CompareTag("Boss"))
            {
                scenceManager.ShowButtons();
            }
            return true;
        }
        return false;

    }
    public void HideButtons()
    {
        foreach(var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
        foreach(var tmp in textMeshPro)
        {
            tmp.gameObject.SetActive(false);
        }
    }

    public void ShowButtons()
    {
        foreach(var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
        foreach(var tmp in textMeshPro)
        {
            tmp.gameObject.SetActive(true);
        }

    }

    void Start()
    {

    }

    void Update()
    {

    }
}