using UnityEngine;

namespace Utilities
{
    public static class GameUtilities
    {
        public static bool IsGoInLayerMask(GameObject go, LayerMask layerMask)
        {
            return layerMask == (layerMask | (1 << go.layer));
        }
        public static Vector3 LookTowardsMousePos(Camera currCam,Vector3 selfPos,Vector3 lookDir)
        {
            Vector3 worldScreenPosition = currCam.ScreenToWorldPoint(lookDir);
            Vector3 diff = worldScreenPosition - selfPos;
            var dist = Vector2.Distance(diff, selfPos);
            if (dist >= 1f)
            {
                return diff.normalized;
            }
            else
            {
                return Vector3.zero;
            }
        }
        // public static Vector3 GetMouseWorldPosition(Camera currCam, LayerMask layersCanLook)
        // {
        //     var ray = currCam.ScreenPointToRay(Mouse.current.position.ReadValue());
        //     return Physics.Raycast(ray, out var raycastHit, 100f, layersCanLook) ? raycastHit.point : Vector3.zero;
        // }
        public static void OnDrawGizmosSelected(float range, Vector3 position)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(position, range * 2);
        }

        #region Isometric Conversion

        private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        
        //Invoke this and replace every movement vector 
        public static Vector3 ToIso(Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
        

        #endregion
    }
}