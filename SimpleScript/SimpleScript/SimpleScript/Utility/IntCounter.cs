using UnityEngine;
using UnityEngine.Events;

namespace SimpleScript
{
    public class IntCounter : SimpleScriptBase
    {
        private enum Conditions
        {
            GREATER_THAN_OR_EQUAL_TO,
            GREATER_THAN,
            EQUAL_TO,
            NOT_EQUAL_TO,
            LESS_THAN,
            LESS_THAN_OR_EQUAL_TO,
        }

        [SerializeField]
        private int m_RequiredAmount;
        [SerializeField]
        private int m_StartingAmount;
        [SerializeField]
        private Conditions m_Condition = Conditions.GREATER_THAN_OR_EQUAL_TO;
        [SerializeField]
        private bool m_DeactivateOnConditionComplete = false;
        [SerializeField]
        private UnityEvent m_OnConditionMet;

        [ReadOnly]
        private int mCurrentAmount = 0;
        [ReadOnly]
        private bool mIsActive = true;

        public void ModifyCounter(int modifyAmount)
        {
            if (!mIsActive)
            {
                return;
            }

            mCurrentAmount += modifyAmount;

            CheckCondition();
        }

        private void ConditionMet()
        {
            if (m_OnConditionMet != null)
            {
                m_OnConditionMet.Invoke();
            }

            if (m_DeactivateOnConditionComplete)
            {
                mIsActive = false;
            }
        }

        public void Reset()
        {
            mCurrentAmount = 0;
            mIsActive = true;
        }

        private void CheckCondition()
        {
            switch(m_Condition)
            {
                case Conditions.GREATER_THAN_OR_EQUAL_TO:

                    if (mCurrentAmount >= m_RequiredAmount)
                    {
                        ConditionMet();
                    }

                break;

                case Conditions.GREATER_THAN:

                    if (mCurrentAmount > m_RequiredAmount)
                    {
                        ConditionMet();
                    }

                break;

                case Conditions.EQUAL_TO:

                    if (mCurrentAmount == m_RequiredAmount)
                    {
                        ConditionMet();
                    }

                break;

                case Conditions.NOT_EQUAL_TO:

                    if (mCurrentAmount != m_RequiredAmount)
                    {
                        ConditionMet();
                    }

                break;

                case Conditions.LESS_THAN:

                    if (mCurrentAmount < m_RequiredAmount)
                    {
                        ConditionMet();
                    }

                break;

                case Conditions.LESS_THAN_OR_EQUAL_TO:

                    if (mCurrentAmount <= m_RequiredAmount)
                    {
                        ConditionMet();
                    }

                break;
            }
        }
    }
}
