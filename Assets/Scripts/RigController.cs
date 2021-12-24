using UnityEngine;
using UnityEngine.UI;

namespace MiniGame.Teleport
{
    public class RigController : MonoBehaviour
    {
        [Range(5, 100)] public int DistanceOfRay = 60;
        [SerializeField] private GameObject _rig;
        [SerializeField] private Image _aIM;
        private RaycastHit _hit;
        private Ray _ray;
        private float _gvrTimer;
        private bool _gvrStatus;
        private string _tagTeleport = "Teleport";
        private const float TELEPORTATION_LOAD_TIME = 2;
        public delegate void TeleportHandler(Transform rig);
        public event TeleportHandler TeleportEvent;
             
        private void Update()
        {
            if (_gvrStatus)
            {
                _gvrTimer += Time.deltaTime;
                _aIM.fillAmount = _gvrTimer / TELEPORTATION_LOAD_TIME;
            }

            _ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(_ray, out _hit, DistanceOfRay))
            {
                if (_aIM.fillAmount == 1 && _hit.transform.CompareTag(_tagTeleport))
                {
                    TeleportEvent?.Invoke(_rig.transform);
                    _hit.transform.gameObject.GetComponent<TeleportController>().TeleportRig(_rig);
                }
            }
        }

        public void GVROn()
        {
            _gvrStatus = true;
        }

        public void GVROff()
        {
            _gvrStatus = false;
            _gvrTimer = 0;
            _aIM.fillAmount = 0;
        }
    }
}
