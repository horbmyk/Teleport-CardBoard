using System.Collections;
using UnityEngine;

namespace MiniGame.Teleport
{
    public class CylinderController : MonoBehaviour
    {
        [SerializeField] private RigController _rigController;
        [SerializeField] private MeshRenderer _cylinderMeshRenderer;
        [SerializeField] private Transform _cylinderTransform;

        private const float MIN_DISTANCE_TO_RIG = 3;

        private void OnEnable()
        {
            _rigController.TeleportEvent += Hide;
        }

        private void OnDisable()
        {
            _rigController.TeleportEvent -= Hide;
        }

        private IEnumerator Show()
        {
            yield return new WaitForSeconds(Random.Range(2, 4));
            _cylinderMeshRenderer.enabled = true;
        }

        private void Hide(Transform rig)
        {
            if (Vector3.Distance(_cylinderTransform.position, rig.position) <= MIN_DISTANCE_TO_RIG)
                _cylinderMeshRenderer.enabled = false;

            StartCoroutine(Show());
        }
    }
}
