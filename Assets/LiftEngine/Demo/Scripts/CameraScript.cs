using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GimmickEngine.Demo
{
    public class CameraScript : MonoBehaviour
    {

        [SerializeField]
        private string m_inputMouseX = "Mouse X";
        [SerializeField]
        private string m_inputMouseY = "Mouse Y";
        [SerializeField]
        private bool m_inverseX;
        [SerializeField]
        private bool m_inverseY;
        [SerializeField]
        private Transform m_target;
        [SerializeField]
        private float m_targetHeight = 2f;
        [SerializeField]
        private float m_distance;

        private Vector2 m_currentAngle = new Vector2(-90, 60);

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

            var axisX = Input.GetAxis(m_inputMouseX);
            var axisY = Input.GetAxis(m_inputMouseY);

            if (m_inverseX) axisX *= -1;
            if (m_inverseY) axisY *= -1;

            m_currentAngle.x += axisX;
            m_currentAngle.y += axisY;

            m_currentAngle.y = Mathf.Clamp(m_currentAngle.y, 0.01f, 179.99f);

            transform.position = GetPosition(m_currentAngle, m_target.position + Vector3.up * m_targetHeight, m_distance);
            transform.rotation = Quaternion.LookRotation((m_target.position + Vector3.up * m_targetHeight) - transform.position);

            //Debug.Log(m_currentAngle);
        }

        Vector3 GetPosition(Vector2 angle, Vector3 lookPosition, float distance)
        {
            var radian = angle * Mathf.Deg2Rad;

            return new Vector3(
                lookPosition.x + distance * Mathf.Sin(radian.y) * Mathf.Cos(radian.x),
                lookPosition.y + distance * Mathf.Cos(radian.y),
                lookPosition.z + distance * Mathf.Sin(radian.y) * Mathf.Sin(radian.x));
        }
    }
}