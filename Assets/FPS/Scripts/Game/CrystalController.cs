using UnityEngine;

namespace Unity.FPS.Game
{
    public class CrystalController : MonoBehaviour
    {
        GameFlowManager m_gameFlowManager;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            m_gameFlowManager = FindAnyObjectByType<GameFlowManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CrystallCollectEvent evt = Events.CrystallCollectEvent;
                EventManager.Broadcast(evt);
                Destroy(gameObject);
            }
        }
    }
}
