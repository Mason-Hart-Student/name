using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GimmickEngine.Demo
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerScript : MonoBehaviour
    {

        [SerializeField]
        private float m_speed = 5f;
        [SerializeField]
        private float m_jumpHeight = 1f;

        private float m_gravity = 9.8f;
        private Vector3 m_velocity = new Vector3();
        private Rigidbody m_rigidbody;


        // Use this for initialization
        void Start()
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (IsGrounded())
            {
                m_velocity.y = 0f;
                //Debug.Log("Is Grounded");
                if (Input.GetButton("Jump"))
                {
                    Jump();
                }
            }
            else
            {
                Fall();
            }

            var axisH = Input.GetAxis("Horizontal");
            var axisV = Input.GetAxis("Vertical");

            if(!Mathf.Approximately(axisH, 0) && !Mathf.Approximately(axisV, 0))
            {
                axisH /= Mathf.Sqrt(2);
                axisV /= Mathf.Sqrt(2);
            }

            var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            var direction = cameraForward * axisV + Camera.main.transform.right * axisH;
            Move(direction);
            Rotate(direction);
            //Debug.Log(direction);
        }

        private void FixedUpdate()
        {
            m_rigidbody.velocity = m_velocity;
        }

        private bool IsGrounded()
        {
            RaycastHit hit;
            var ray = new Ray(transform.position + Vector3.up * 0.08f, Vector3.down);
            var raycast = Physics.Raycast(ray, out hit, 0.2f);

            if (raycast)
            {
                if (hit.collider.isTrigger) return false;
            }

            return raycast;
        }

        private void Move(Vector3 direction)
        {
            m_velocity.x = direction.x * m_speed;
            m_velocity.z = direction.z * m_speed;
        }
        private void Rotate(Vector3 direction)
        {
            if (direction.magnitude > 0.001f) transform.rotation = Quaternion.LookRotation(direction);
        }

        private void Jump()
        {
            var power = Mathf.Sqrt(2 * m_gravity * m_jumpHeight);
            m_velocity.y = power;
        }

        private void Fall()
        {
            m_velocity.y -= m_gravity * Time.deltaTime;
        }
    }
}