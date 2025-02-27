using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GimmickEngine.Lift;

namespace GimmickEngine.Demo
{
    public class PowerAreaScript : MonoBehaviour
    {

        [SerializeField]
        private LiftBase m_lift;
        [SerializeField]
        private Color m_powerOffColor = Color.red;
        [SerializeField]
        private Color m_powerOnColor = Color.blue;
        [SerializeField]
        private bool m_isStayArea = false;
        [SerializeField]
        private string[] m_hitTag = new string[] { "Player" };

        private List<GameObject> m_stayingObjects = new List<GameObject>();

        private Renderer m_areaRenderer;
        private Renderer m_liftRenderer;

        // Use this for initialization
        void Start()
        {
            m_areaRenderer = GetComponent<Renderer>();
            m_liftRenderer = m_lift.GetComponentInChildren<Renderer>();

            SetPower(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            bool hit = false;
            foreach (var tag in m_hitTag)
            {
                if(other.tag == tag)
                {
                    hit = true;
                    break;
                }
            }

            if (hit)
            {
                SetPower(true);

                if (!m_stayingObjects.Contains(other.gameObject))
                {
                    m_stayingObjects.Add(other.gameObject);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (m_isStayArea)
            {
                if (m_stayingObjects.Contains(other.gameObject))
                {
                    m_stayingObjects.Remove(other.gameObject);
                }

                if(m_stayingObjects.Count == 0)
                {
                    SetPower(false);
                }
            }
        }

        private void SetPower(bool power)
        {
            var areaColor = m_powerOffColor;
            var liftColor = m_powerOffColor;

            if (power)
            {
                areaColor = m_powerOnColor;
                liftColor = m_powerOnColor;

                m_lift.Play();
            }
            else
            {
                m_lift.Stop();
            }

            areaColor.a = 0.5f;

            m_areaRenderer.material.color = areaColor;
            m_liftRenderer.material.color = liftColor;

        }
    }
}