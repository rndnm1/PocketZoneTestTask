using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(HealthComponent))]
public class MovementComponent : MonoBehaviour, IMovement
{
    private Animator animator;
    private HealthComponent healthComponent;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthComponent = GetComponent<HealthComponent>();
    }

    public void MovementIteration(Vector3 direction)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return; //object can't move during attack animation

        SetMovingAnimation(direction);
        SetAvatarRotation(direction);

        transform.Translate((Vector3.up * direction.y + Vector3.right * direction.x) * healthComponent.MovementSpeed * Time.deltaTime, Space.Self);
    }





    private void SetMovingAnimation(Vector3 direction)
    {
        if (direction == Vector3.zero)
        {
            animator.SetBool("IsMoving", false);
            return;
        }
        else animator.SetBool("IsMoving", true);
    }

    private void SetAvatarRotation(Vector3 direction)
    {
        if (direction.x > 0) transform.Find("Avatar").localEulerAngles = new Vector3(0, 0, 0);
        if (direction.x < 0) transform.Find("Avatar").localEulerAngles = new Vector3(0, 180, 0);
    }
}
