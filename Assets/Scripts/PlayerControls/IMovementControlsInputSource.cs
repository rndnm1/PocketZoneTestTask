using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementControlsInputSource
{
    Vector3 InputtedDirection { get; }
}
