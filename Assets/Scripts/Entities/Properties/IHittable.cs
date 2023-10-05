using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    HealthStatus RecieveDamage(float damage);

    public enum HealthStatus
    {
        Alive = 0,
        Dead = 1
    }
}
