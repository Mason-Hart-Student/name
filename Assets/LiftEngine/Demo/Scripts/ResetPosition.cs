using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GimmickEngine.Demo
{
    public class ResetPosition : MonoBehaviour
    {
        [SerializeField]
        private float m_resetHeight = 5f;

        private Vector3 m_defaultPosition;
        private Rigidbody m_rigidbody;

        // Use this for initialization
        void Start()
        {
            m_defaultPosition = transform.position;
            m_rigidbody = GetComponent<Rigidbody>();
            //gameObject.tag = "FieldObject";
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < m_resetHeight)
            {
                transform.position = m_defaultPosition;
                m_rigidbody.velocity = Vector3.zero;
            }
        }
    }
}