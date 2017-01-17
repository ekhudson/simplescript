using UnityEngine;
using UnityEngine.Events;
using Klak;
using Klak.Wiring;

namespace SimpleScript
{
    [AddComponentMenu("Klak/Wiring/SimpleScript/SimpleTrigger")]
    public class SimpleTrigger : ScriptingAction
    {
        public enum TriggerType
        {
            OnAwake,
            OnStart,
            OnUpdate,
            OnEnable,
            OnDisable,
            OnDestroy,
            TriggerEnter,
            TriggerExit,
            CollisionEnter,
            CollisionExit,
            ForceTriggerOnly,
        }

        [SerializeField]
        private TriggerType m_TriggerOn = TriggerType.OnStart;

        [SerializeField]
        private bool m_OnlyTriggersOnce = false;

        private bool m_HasBeenTriggered = false;

        [SerializeField, Outlet]
        private UnityEvent m_OnTriggered;

        protected virtual void OnTrigger() { }

        public override string SubTitle()
        {
            return m_TriggerOn.ToString();
        }

        protected override int mNodeColor
        {
            get
            {
                return 5;
            }
        }

        [Inlet]
        public void ForceTrigger()
        {
            if (m_DebugMode)
            {
                Debug.Log(string.Format("Forcing Trigger {0}({1})", gameObject.name, m_DesignLabel), this);
            }

            TriggerHandler();
        }

        public void Trigger()
        {
            if (m_DebugMode)
            {
                Debug.Log(string.Format("Manually Triggering {0}({1})", gameObject.name, m_DesignLabel), this);
            }

            if (m_HasBeenTriggered && !m_OnlyTriggersOnce)
            {
                TriggerHandler();
            }
            else if (!m_HasBeenTriggered)
            {
                TriggerHandler();
            }
        }

        private void TriggerHandler()
        {
            if (m_DebugMode)
            {
                Debug.Log(string.Format("Callback Triggered {0}({1})", gameObject.name, m_DesignLabel), this);
            }

            OnTrigger();
            InvokeOnTrigger();
        }

        private void InvokeOnTrigger()
        {
            if (m_DebugMode)
            {
                for (int i = 0; i < m_OnTriggered.GetPersistentEventCount(); i++)
                {
                    Debug.Log(string.Format("OnTrigger invoked for {0}({1}), calling {2} on object {3}", gameObject.name, m_DesignLabel, m_OnTriggered.GetPersistentMethodName(i), m_OnTriggered.GetPersistentTarget(i)), this);
                }
            }

            m_OnTriggered.Invoke();
        }

        private void Awake()
        {
            if (ShouldTrigger(TriggerType.OnAwake))
            {
                m_HasBeenTriggered = true;
                TriggerHandler();
            }
        }

        private void Start()
        {
            if (ShouldTrigger(TriggerType.OnStart))
            {
                m_HasBeenTriggered = true;
                TriggerHandler();
            }
        }

        private void OnEnable()
        {
            if (ShouldTrigger(TriggerType.OnEnable))
            {
                m_HasBeenTriggered = true;
                TriggerHandler();
            }
        }

        private void OnDisable()
        {
            if (ShouldTrigger(TriggerType.OnDisable))
            {
                m_HasBeenTriggered = true;
                TriggerHandler();
            }
        }

        private void OnDestroy()
        {
            if (ShouldTrigger(TriggerType.OnDestroy))
            {
                m_HasBeenTriggered = true;
                TriggerHandler();
            }
        }

        private void Update()
        {
            if (ShouldTrigger(TriggerType.OnUpdate))
            {
                m_HasBeenTriggered = true;
                TriggerHandler();
            }
        }

        private void OnTriggerEnter()
        {
            if (ShouldTrigger(TriggerType.TriggerEnter))
            {
                m_HasBeenTriggered = true;
                TriggerHandler();
            }
        }

        private void OnTriggerExit()
        {
            if (ShouldTrigger(TriggerType.TriggerExit))
            {
                m_HasBeenTriggered = true;
                TriggerHandler();
            }
        }

        private void OnCollisionEnter()
        {
            if (ShouldTrigger(TriggerType.CollisionEnter))
            {
                m_HasBeenTriggered = true;
                TriggerHandler();
            }
        }

        private void OnCollisionExit()
        {
            if (ShouldTrigger(TriggerType.CollisionExit))
            {
                m_HasBeenTriggered = true;
                TriggerHandler();
            }
        }

        private bool ShouldTrigger(TriggerType typeCheck)
        {
            if (m_HasBeenTriggered && m_OnlyTriggersOnce)
            {
                return false;
            }

            return (m_TriggerOn == typeCheck);
        }

        public void DestroyHelper()
        {
            GameObject.Destroy(gameObject);
        }
    }
}
