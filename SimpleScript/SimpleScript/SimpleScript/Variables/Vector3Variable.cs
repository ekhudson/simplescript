using UnityEngine;
using Klak.Wiring;

namespace SimpleScript
{
    [AddComponentMenu("Klak/Wiring/SimpleScript/Variables/Vector3 Variable")]
    public class Vector3Variable : VariableBase<Vector3>
    {
        [Inlet] public float X { get { return m_Value.x; } set { m_Value.x = m_X = value; } }
        [Inlet] public float Y { get { return m_Value.y; } set { m_Value.y = m_Y = value; } }
        [Inlet] public float Z { get { return m_Value.z; } set { m_Value.z = m_Z = value; } }

        [SerializeField, Outlet] private float m_X = 0f;
        [SerializeField, Outlet] private float m_Y = 0f;
        [SerializeField, Outlet] private float m_Z = 0f;
    }
}


