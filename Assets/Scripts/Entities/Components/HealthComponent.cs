using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
[System.Serializable]
public class HealthComponent : MonoBehaviour, IHittable
{
    [Header("Stats")]
    public float MaxHP = 100;
    public float Damage = 20;
    public float AttackSpeed = 1.0f;
    public float AttackRange = 1.4f;
    public float MovementSpeed = 3f;
    public float DistanceOfSight = 15;

    public float CurrentHP { get; set; }

    public Action OnDeath;
    public Action OnDamageRecieved;

    private void Awake()
    {
        CurrentHP = MaxHP;
    }

    public IHittable.HealthStatus RecieveDamage(float damage)
    {
        CurrentHP -= damage;

        OnDamageRecieved?.Invoke();

        if (CurrentHP > 0) return IHittable.HealthStatus.Alive;
        else
        {
            Death();
            return IHittable.HealthStatus.Dead;
        }
    }

    private void Death()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
