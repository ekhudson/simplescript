using UnityEngine;
using UnityEngine.Events;
using Klak.Wiring;

namespace SimpleScript
{
    [AddComponentMenu("Klak/Wiring/SimpleScript/Generator/Time Since Startup")]
    public class TimeSinceStartup : ScriptingAction
    {
        public class TimeSinceStartupEvent : UnityEvent<float>{}

        [SerializeField, Outlet]
        private TimeSinceStartupEvent m_TimeSinceStartup = new TimeSinceStartupEvent();

        public void Update()
        { 
            m_TimeSinceStartup.Invoke(Time.time);
        }
    }
}

