using UnityEngine;
using UnityEngine.Events;

namespace SimpleScript
{
    public class CompareIntValueAction : SimpleScriptBase
    {
        [SerializeField]
        private int m_ValueA = 0;
        [SerializeField]
        private int m_ValueB = 0;
        [SerializeField]
        private CompareEnums m_CompareType = CompareEnums.EqualTo;

        [SerializeField]
        private OnCompareEvent m_OnTrue;
        [SerializeField]
        private OnCompareEvent m_OnFalse;

        [System.Serializable]
        public class OnCompareEvent : UnityEvent { }

        public int ValueA { set { m_ValueA = value; } }
        public int ValueB { set { m_ValueB = value; } }

        private enum CompareEnums
        {
            LessThan,
            LessThanOrEqualTo,
            GreaterThan,
            GreaterThanOrEqualTo,
            NotEqualTo,
            EqualTo,
        }

        public void Compare()
        {
            bool isTrue = false;

            switch (m_CompareType)
            {
                case CompareEnums.EqualTo:

                    isTrue = m_ValueA == m_ValueB;

                    break;
                case CompareEnums.GreaterThan:

                    isTrue = m_ValueA > m_ValueB;

                    break;
                case CompareEnums.GreaterThanOrEqualTo:

                    isTrue = m_ValueA >= m_ValueB;

                    break;
                case CompareEnums.LessThan:

                    isTrue = m_ValueA < m_ValueB;

                    break;
                case CompareEnums.LessThanOrEqualTo:

                    isTrue = m_ValueA <= m_ValueB;

                    break;
                case CompareEnums.NotEqualTo:

                    isTrue = m_ValueA != m_ValueB;

                    break;
            }

            if (m_DebugMode)
            {
                Debug.Log(string.Format("{0} {1} {2} = {3}", m_ValueA, m_CompareType.ToString(), m_ValueB, isTrue.ToString()));
            }

            if (isTrue)
            {
                m_OnTrue.Invoke();
            }
            else
            {
                m_OnFalse.Invoke();
            }
        }
    }
}