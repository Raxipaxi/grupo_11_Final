using UnityEngine;

namespace Utilities
{
    [CreateAssetMenu(fileName = "New Brick", menuName = "Bricks", order = 0)]
    public class BricksSO : ScriptableObject
    {
        #region SerializeFields
        
        [field:SerializeField] public Color Color { get; private set;}  
        [field:SerializeField] public int Hits { get; private set;} 
        #endregion

    }
}