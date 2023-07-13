using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public bool IsOpen { get; private set; }

    public virtual void Initialize()
    {

    }

    public virtual void Dispose()
    {

    }

    public virtual void Open()
    {
        IsOpen = true;
        gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        IsOpen = false;
        gameObject.SetActive(false);
    }
}
