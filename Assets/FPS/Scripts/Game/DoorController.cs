using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Unity.FPS.Game
{
    [RequireComponent(typeof(XRGrabInteractable), typeof(HingeJoint))]
    public class DoorController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private XRGrabInteractable _grabInteractable;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _grabInteractable = GetComponent<XRGrabInteractable>();
            setDooLockStatus(true);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Key")) {
                Destroy(other.gameObject);
                setDooLockStatus(false);
            }
        }
        private void setDooLockStatus(bool lockStatus)
        {
            _rigidbody.isKinematic = lockStatus;
            _grabInteractable.enabled = !lockStatus;
        }
    }
}