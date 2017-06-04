using UnityEngine;
using UnityEngine.Events;

namespace SimpleScript
{
    public abstract class ActionBase : SimpleScriptBase
    {
        [SerializeField]
        private UnityEvent m_OnActionComplete;

        protected virtual void ActionLogic()
        {
            //override and implement logic for the action
        }

        public void ActivateAction()
        {
            ActionLogic();
            OnActionComplete();
        }

        protected virtual void OnActionComplete()
        {
            m_OnActionComplete.Invoke();
        }
    }
}