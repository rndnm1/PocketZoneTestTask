using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace PlayerControls
{
    /// <summary>
    /// Allows the player to directly control an object
    /// </summary>
    [RequireComponent(typeof(HealthComponent), typeof(MovementComponent), typeof(IAttackingTool))]
    public class PlayerController : MonoBehaviour, IUnitController
    {
        public Vector3 MovementDirectionInput {
            get { return movementControlsInputSource.InputtedDirection; } 
            set { Debug.Log("Not implemented!"); } 
        }

        private MovementComponent movementComponent;
        private HealthComponent healthComponent;
        private IAttackingTool attackingComponent;

        private TargetAcquirerComponent targetAcquirer;
        private IMovementControlsInputSource movementControlsInputSource;

        [Inject]
        private void InstallExternalDependencies(IMovementControlsInputSource controlsInput, DataBase dataBase)
        {
            this.movementControlsInputSource = controlsInput;
            targetAcquirer = new TargetAcquirerComponent(dataBase);
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
}
