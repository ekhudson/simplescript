using UnityEngine;
using Klak.Wiring;

namespace SimpleScript
{
    public class ScriptingAction : NodeBase
    {
        [SerializeField]
        protected DesignLabel m_DesignLabel;

        [SerializeField]
        protected bool m_DebugMode;

        public override int NodeColor()
        {
            if (m_DesignLabel.DesignColor != Color.clear)
            {
                return 1;//m_DesignLabel.DesignColor;
            }
            else
            {
                return mNodeColor;
            }
        }
    }
}
