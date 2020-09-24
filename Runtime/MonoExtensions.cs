using System.Linq;
using UnityEngine;

namespace EcsExtensions.Runtime
{
    public static class MonoExtensions
    {
        public static void ValidateChild<TK, TV>(this TK mono, ref TV behaviour, bool includeSelf = true,
            bool includeInactive = true)
            where TK : MonoBehaviour
            where TV : Component
        {
            if (mono == null)
            {
                return;
            }

            if (behaviour != null)
            {
                return;
            }

            var c = mono.GetComponentsInChildren<TV>();
            if (!includeSelf)
            {
                var f = c.FirstOrDefault(t => t.transform.Equals(mono.transform));
                behaviour = f;
            }
            else
            {
                behaviour = c.FirstOrDefault();
            }
        }
    }
}