using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

/// <summary>
/// Allows IBehaviors to control this unit
/// </summary>
[RequireComponent(typeof(HealthComponent), typeof(MovementComponent), typeof(IAttackingTool))]
public class AIController : MonoBehaviour, IUnitController
{
    public Vector3 MovementDirectionInput { get; set; }

    private MovementComponent movementComponent;
    private HealthComponent healthComponent;
    private IAttackingTool attackingComponent;

    private TargetAcquirerComponent targetAcquirer;

    [Inject]
    private void InstallExternalDependencies(DataBase databBase)
    {
        targetAcquirer = new TargetAcquirerComponent(databBase);
    }

    private void Start()
    {
        movementComponent = GetComponent<MovementComponent>();
        healthComponent = GetComponent<HealthComponent>();
        attackingComponent = GetComponent<IAttackingTool>();
    }
    void Update()
    {
        movementComponent.MovementIteration(MovementDirectionInput);
    }

    /// <summary>
    /// If target is null TargetAcquirerComponent will be used
    /// </summary>
    public void Attack(GameObject attackTarget)
    {
        if (attackTarget == null) attackTarget = targetAcquirer.GetNearestEnemyFromPosition(transform.position, healthComponent.DistanceOfSight);

        if (attackTarget != null) attackingComponent.Attack(attackTarget);
    }
}
