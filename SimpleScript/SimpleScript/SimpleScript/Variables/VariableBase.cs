using UnityEngine;
using Klak.Wiring;

namespace SimpleScript
{   public class VariableBase<T> : SimpleScriptBase
    {        
        [SerializeField, Outlet]
        protected T m_Value;

        public T Value()
        {
            return m_Value;
        }

        [Inlet]
        public void Set(T newValue)
        {
            m_Value = newValue;
        }

        public override string SubTitle()
        {
            return "Value: " + m_Value.ToString();
        }

        protected override int mNodeColor
        {
            get
            {
                return 2;
            }
        }
    }
}
