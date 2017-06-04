using UnityEngine;
using UnityEngine.Events;

namespace SimpleScript
{
    public class IntMathAction : ActionBase
    {
        [SerializeField]
        private VariableUtility.MathOperation m_Operation;
        [SerializeField]
        private IntVariable m_VariableA;
        [SerializeField]
        private IntVariable m_VariableB;
        [SerializeField]
        private OutputProductEvent m_OutputProduct;

        private int mProduct = 0;

        [System.Serializable]
        public class OutputProductEvent : UnityEvent<int> { }

        protected override void ActionLogic()
        {
            mProduct = VariableUtility.PerformMathOperation(m_Operation, m_VariableA.Value(), m_VariableB.Value());
            m_OutputProduct.Invoke(mProduct);
            base.ActionLogic();
        }
    }
}
