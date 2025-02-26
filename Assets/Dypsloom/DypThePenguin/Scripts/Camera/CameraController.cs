/// ---------------------------------------------
/// Dyp The Penguin Character | Dypsloom
/// Copyright (c) Dyplsoom. All Rights Reserved.
/// https://www.dypsloom.com
/// ---------------------------------------------

namespace Dypsloom.DypThePenguin.Scripts.Camera
{
    using UnityEngine;

    /// <summary>
    /// A camera controller that follows the transform referenced.
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        [Tooltip("The transform that the camera will follow.")]
        [SerializeField] protected Transform m_Follow;

        private float turnSpeed = 5f;
        [SerializeField] private float yOffset = 10.0f;
        [SerializeField] private float zOffset = 10.0f;

        protected Vector3 m_StartOffset;
    
        /// <summary>
        /// Follow the transform.
        /// </summary>
        void Start()
        {
            if (m_Follow == null) {
                m_Follow = GameObject.FindWithTag("Player").transform;
            }
        
            m_StartOffset = new Vector3(m_Follow.position.x, m_Follow.position.y + yOffset, m_Follow.position.z + zOffset);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    
        /// <summary>
        /// Late Update to remove hiccups.
        /// </summary>
        void LateUpdate () 
        {
            transform.rotation = Quaternion.Euler(17, 0, 0);
            m_StartOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * m_StartOffset;
            transform.position = m_Follow.position + m_StartOffset;
            transform.LookAt(m_Follow);
        }
    }
}
