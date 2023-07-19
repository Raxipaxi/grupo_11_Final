using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdate
{
    public GameObject gameObject { get; }
    void DoUpdate();
}
