using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

using Zenject;

namespace AI
{
    /// <summary>
    /// Chases and attacks player when it comes in sight
    /// </summary>
    [RequireComponent(typeof(AIController), typeof(HealthComponent))]
    public class PlayerChaserBehavior : MonoBehaviour, IBehavior
    {
        private GameObject objectToChase;

        private AIController unitController;
        private HealthComponent healthComponent;
        private bool IsDestroyed = false;

        const int DELAY_BETWEEN_EXECUTIONS = 100;

        [Inject]
        private void InstallExternalDependencies(GameObject playerObject)
        {
            this.objectToChase = playerObject;
        }

        private void Awake()
        {
            unitController = GetComponent<AIController>();
            healthComponent = GetComponent<HealthComponent>();
        }

        private void Start() => ControlObject();

        /// <summary>
        /// Acquires a new target to chase it and attack
        /// </summary>
        public async void ControlObject()
        {
            while (IsDestroyed == false)
            {
                if (objectToChase == null) return;

                float distanceToTarget = Vector3.Distance(transform.position, objectToChase.transform.position);
                
                if (distanceToTarget < healthComponent.AttackRange)
                {  //close enough to attack
                    unitController.Attack(objectToChase);
                }
                else if (distanceToTarget < healthComponent.DistanceOfSight)
                { //not close enough to attack but still in sight for a chase
                    unitController.MovementDirectionInput = (objectToChase.transform.position - transform.position).normalized;
                }
                await Task.Delay(DELAY_BETWEEN_EXECUTIONS);
            }
        }

        private void OnDestroy()
        {
            IsDestroyed = true;
        }
    }
}
