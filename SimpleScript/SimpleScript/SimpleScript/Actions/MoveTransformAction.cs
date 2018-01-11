using UnityEngine;
using System.Collections;

namespace SimpleScript
{
    public class MoveTransformAction : ActionBase
    {
        private enum MoveTypes
        {
            Teleport,
            Lerp,
            Slerp,
            AnimCurve,
        }

        [Header("Action Settings")]
        [SerializeField]
        private Transform m_ObjectToMove = null;
        [SerializeField]
        private MoveTypes m_MoveType = MoveTypes.Teleport;
        [SerializeField]
        private Transform m_TargetPosition = null;
        [SerializeField]
        private float m_MoveTime = 1f;
        [SerializeField]
        private bool m_IsAffectedByTimescale = true;
        [SerializeField]
        private AnimationCurve m_AnimCurve;

        private Vector3 mStartPosition = Vector3.zero;
        private bool mIsMoving = false;
        private float mCurrentMoveTime = 0f;
        private float mCurrentNormalizedTime = 0f;

        protected override void ActionLogic()
        {
            if (!mIsMoving)
            {
                if (m_MoveType == MoveTypes.Teleport)
                {
                    m_ObjectToMove.position = m_TargetPosition.position;
                    OnActionComplete();
                }
                else
                {
                    StartCoroutine(DoMove());
                }
            }
        }

        private IEnumerator DoMove()
        {
            mIsMoving = true;
            mCurrentMoveTime = 0f;
            mStartPosition = m_ObjectToMove.transform.position;
            mCurrentNormalizedTime = 0f;

            while (mCurrentMoveTime < m_MoveTime)
            {
                mCurrentNormalizedTime = Mathf.InverseLerp(0f, m_MoveTime, mCurrentMoveTime);

                if (m_MoveType == MoveTypes.Lerp)
                {
                    m_ObjectToMove.transform.position = Vector3.Lerp(mStartPosition, m_TargetPosition.position, mCurrentNormalizedTime);
                }
                else if (m_MoveType == MoveTypes.Slerp)
                {
                    m_ObjectToMove.transform.position = Vector3.Slerp(mStartPosition, m_TargetPosition.position, mCurrentNormalizedTime);
                }
                else if (m_MoveType == MoveTypes.AnimCurve)
                {
                    float animatedTime = m_AnimCurve.Evaluate(mCurrentNormalizedTime);
                    m_ObjectToMove.transform.position = Vector3.Lerp(mStartPosition, m_TargetPosition.position, animatedTime);
                }

                float deltaTime = m_IsAffectedByTimescale ? Time.deltaTime : Time.unscaledDeltaTime;

                mCurrentMoveTime = Mathf.Clamp(mCurrentMoveTime + deltaTime, 0f, m_MoveTime);

                yield return new WaitForSeconds(deltaTime);
            }

            mIsMoving = false;
            OnActionComplete();
        }
    }
}
