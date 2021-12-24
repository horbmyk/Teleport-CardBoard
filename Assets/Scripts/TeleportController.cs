using UnityEngine;

namespace MiniGame.Teleport
{
    public class TeleportController : MonoBehaviour
    {
        [SerializeField] private Transform _teleportTransform;

        public void TeleportRig(GameObject rig)
        {
            rig.transform.position = _teleportTransform.position + new Vector3(0, 1.5f, 0);
        }
    }
}
