using System;
using UnityEngine;

namespace fidt17.UnityExtensionsModule.Runtime
{
    public static class LayerExtensions
    {
        /// <summary>
        /// Checks if LayerMask contains Layer 
        /// </summary>
        public static bool Contains(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }

        /// <summary>
        /// Sets Layer of all GameObjects down the hierarchy (includes root) to provided Layer.
        /// </summary>
        public static void SetLayerRecursive(this GameObject gObj, int layer)
        {
            if (gObj == null) throw new ArgumentNullException();
            
            gObj.layer = layer;
            foreach (Transform child in gObj.transform)
            {
                child.gameObject.SetLayerRecursive(layer);
            }
        }
    }
}
