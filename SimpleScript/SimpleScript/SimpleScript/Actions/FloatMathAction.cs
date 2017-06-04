using UnityEngine;
using UnityEngine.Events;

namespace SimpleScript
{
    public class FloatMathAction : ActionBase
    {
        [SerializeField]
        private VariableUtility.MathOperation m_Operation;
        [SerializeField]
        private FloatVariable m_VariableA;
        [SerializeField]
        private FloatVariable m_VariableB;
        [SerializeField]
        private OutputProductEvent m_OutputProduct;

        private float mProduct = 0f;

        [System.Serializable]
        public class OutputProductEvent : UnityEvent<float> { }

        protected override void ActionLogic()
        {
            mProduct = VariableUtility.PerformMathOperation(m_Operation, m_VariableA.Value(), m_VariableB.Value());
            m_OutputProduct.Invoke(mProduct);
            base.ActionLogic();   
        }
    }
}
