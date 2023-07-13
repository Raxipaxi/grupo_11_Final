using CustomUpdateManagerNSP;
using UnityEngine;

public abstract class CustomUpdateBehavior : MonoBehaviour
{ 
    // Custom Update Manager checks this bool before calling UpdateMe
    public bool needsUpdate = true;
    public bool NeedsUpdate => needsUpdate;

    protected CustomUpdateManager _manager;
    protected virtual void Start()
    {
        if (needsUpdate)
        {
            SuscribeToManager();
        }
    }

    protected virtual void SuscribeToManager()
    {
    }

    protected virtual void SetManager(CustomUpdateManager NewManager)
    {
        _manager = NewManager;
    }

    public void UpdateMe()
    {
        UpdateItems();

    }

    private void OnDisable()
    {
        if (_manager != null)
        {
            _manager.RemoveScript(this);
        }
    }

    private void OnEnable()
    {
        needsUpdate = true;
    }

    protected virtual void UpdateItems()
    {
        
    } 
}
