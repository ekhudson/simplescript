using UnityEngine;
using Klak.Wiring;

namespace SimpleScript
{
    [AddComponentMenu("Klak/Wiring/SimpleScript/Variables/Vector3 Variable")]
    public class Vector3Variable : VariableBase<Vector3>
    {
        [Inlet, Outlet] public float X { get { return m_Value.x; } set { m_Value.x = value; } }
        [Inlet, Outlet] public float Y { get { return m_Value.y; } set { m_Value.y = value; } }
        [Inlet, Outlet] public float Z { get { return m_Value.z; } set { m_Value.z = value; } }
    }
}


