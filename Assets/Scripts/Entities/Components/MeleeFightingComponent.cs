using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InventoryModule;

[RequireComponent(typeof(Animator), typeof(HealthComponent))]
public class MeleeFightingComponent : MonoBehaviour, IAttackingTool
{
    private Animator animator;
    private HealthComponent healthComponent;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthComponent = GetComponent<HealthComponent>();
    }

    public bool Attack(GameObject target)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return false;  //wait for the end of the animation

        animator.SetBool("IsAttacking", true);
        try
        {
            target.GetComponent<IHittable>().RecieveDamage(healthComponent.Damage);
        }
        catch { Debug.Log("Attacking invalid target"); }

        return true;
    }

    public void AttackUsingConsumables(GameObject target, Inventory inventoryWithConsumables)
    {
        foreach (var item in inventoryWithConsumables.Items)
        {
            if (item.IsConsumable)
            {
                if (Attack(target)) inventoryWithConsumables.RemoveItem(item);
                return;
            }
        }
    }
}
