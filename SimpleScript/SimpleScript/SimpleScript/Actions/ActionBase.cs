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
            OnActionComplete();
        }

        public void ActivateAction()
        {
            ActionLogic();
        }

        protected virtual void OnActionComplete()
        {
            m_OnActionComplete.Invoke();
        }
    }
}