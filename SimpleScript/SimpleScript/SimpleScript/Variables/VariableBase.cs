using UnityEngine;

namespace SimpleScript
{   public class VariableBase<T> : SimpleScriptBase
    {        
        [SerializeField]
        protected T m_Value;

        public T Value()
        {
            return m_Value;
        }

        public void Set(T newValue)
        {
            m_Value = newValue;
        }
    }
}
