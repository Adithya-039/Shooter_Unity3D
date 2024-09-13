using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float damage = 10f;

    private PlayerMovement movementComponent;
    private PlayerUI uiComponent;

    //public delegate void Del_OneFloatParameter (float damageTaken);
    //public Del_OneFloatParameter del_DamageTaken;

    private void Awake()
    {
        movementComponent = GetComponent<PlayerMovement>();
        if (movementComponent != null)
        {
            Debug.Log("OnPlayer");
            uiComponent = GetComponent<PlayerUI>();
        }
        else
        {
            Debug.Log("On Enemy");
        }
    }

    public void AcceptDamage()
    {
        health -= damage;
        if (movementComponent != null)
        {
            movementComponent.PlayerMovementDamageTakenSignal(damage);
        }

        if (uiComponent != null)
        {
            uiComponent.UpdateHealthBar(GetHealthRatio());
        }

        if (health < 0)
        {
            Death();
        }
    }

    public void AcceptDamage(float incomingDamage)
    {
        health -= incomingDamage;
        if(movementComponent!= null)
        {
            movementComponent.PlayerMovementDamageTakenSignal(incomingDamage);
        }

        if(uiComponent != null)
        {
            uiComponent.UpdateHealthBar(GetHealthRatio());
        }

        if (health < 0)
        {
            Death();
        }

        
    }

    public void Death()
    {
        Debug.Log("Health less than 0, Destroying Game Object");
        Destroy(gameObject);
    }

    public float GetHealthRatio()
    {
        return health / maxHealth;
    }
}
