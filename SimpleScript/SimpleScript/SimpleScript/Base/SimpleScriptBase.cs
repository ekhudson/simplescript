using UnityEngine;

namespace SimpleScript
{
    public class SimpleScriptBase : MonoBehaviour
    {
        [SerializeField]
        protected DesignLabel m_DesignLabel;

        [SerializeField]
        protected bool m_DebugMode;

        protected void DebugMessage(string message, Object sender)
        {
            if (m_DebugMode)
            {
                Debug.Log(message, sender);
            }
        }
    }
}
