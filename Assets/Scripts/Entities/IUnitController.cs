using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allowes to control unit's actions
/// </summary>
public interface IUnitController
{
    void Attack(GameObject attackTarget);
    Vector3 MovementDirectionInput { get; set; }
}
