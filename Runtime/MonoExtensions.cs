using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MonoExtensions.Runtime
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

        public static void Toggle(this Transform transform, bool isEnabled)
        {
            if (transform == null)
            {
                return;
            }

            Toggle(transform.gameObject, isEnabled);
        }

        public static void Toggle(this GameObject gameObject, bool isEnabled)
        {
            if (gameObject == null)
            {
                return;
            }

            if (!gameObject.activeSelf && isEnabled)
            {
                gameObject.SetActive(true);
            }
            else if (gameObject.activeSelf && !isEnabled)
            {
                gameObject.SetActive(false);
            }
        }

        public static void Bind(this Button button, Action callback)
        {
            if (button == null)
            {
                return;
            }

            if (callback == null)
            {
                return;
            }

            button.onClick.AddListener(callback.Invoke);
        }

        public static void ClearBinds(this Button button)
        {
            if (button == null)
            {
                return;
            }

            button.onClick.RemoveAllListeners();
        }
    }
}