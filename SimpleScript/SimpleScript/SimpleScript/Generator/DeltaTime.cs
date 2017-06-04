using UnityEngine;
using UnityEngine.Events;
using Klak.Wiring;

namespace SimpleScript
{
    [AddComponentMenu("Klak/Wiring/SimpleScript/Generator/Delta Time")]
    public class DeltaTime : SimpleScriptBase
    {
        public class DeltaTimeEvent : UnityEvent<float> { }

        [SerializeField, Outlet]
        private UnityEvent<float> m_DeltaTime = new DeltaTimeEvent();

        public void Update()
        {
            m_DeltaTime.Invoke(Time.deltaTime);
        }
    }
}

