using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InventoryModule;

[RequireComponent(typeof(Animator), typeof(HealthComponent), typeof(Inventory))]
public class ShootingComponent : MonoBehaviour, IAttackingTool
{
    private Animator animator;
    private HealthComponent healthComponent;
    private Inventory inventory;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthComponent = GetComponent<HealthComponent>();
        inventory = GetComponent<Inventory>();
    }

    public bool Attack(GameObject target)
    { //attack -> shoot
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return false; //wait for the end of the attack animation to attack again

        if (UseConsumables() == false) return false; //no more bullets to shoot
 
        animator.SetBool("IsAttacking", true);

        Bullet newBullet = GameObject.Instantiate(PrefabManager.BulletPrefabs[0]).GetComponent<Bullet>();
        newBullet.Damage = healthComponent.Damage;

        Vector3 shootingDelta = transform.position - target.transform.position;
        newBullet.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(shootingDelta.y, shootingDelta.x) * Mathf.Rad2Deg + 90); //bullet will be guided by facing angle
        newBullet.transform.position = transform.position + newBullet.transform.up; //initial offset

        if (shootingDelta.x < 0) transform.Find("Avatar").localEulerAngles = new Vector3(0, 0, 0);
        if (shootingDelta.x > 0) transform.Find("Avatar").localEulerAngles = new Vector3(0, 180, 0);

        return true;
    }

    public bool UseConsumables()
    {
        foreach (var item in inventory.Items)
        {
            if (item.IsConsumable)
            {
                inventory.RemoveItem(item);
                return true;
            }
        }

        Debug.Log("No more bullets to shoot");
        return false;
    }
}
