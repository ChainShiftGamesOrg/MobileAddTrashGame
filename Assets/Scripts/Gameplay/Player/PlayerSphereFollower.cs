using UnityEngine;
using UnityEngine.AI;

public class PlayerSphereFollower : MonoBehaviour
{
    public GameObject PlayerSphere;
    private PlayerSphereMovement _playerSphereMovement;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerSphereMovement = PlayerSphere.GetComponent<PlayerSphereMovement>();
    }

    private void Update()
    {
        if (PlayerSphere != null)
        {
            _agent.SetDestination(PlayerSphere.transform.position);
            RotateModel();
        }
        else
        {
            Debug.LogWarning("Target to follow is null");
        }
    }

    private void RotateModel()
    {
        if (_playerSphereMovement.MovementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_playerSphereMovement.MovementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _playerSphereMovement.RotationSpeed * Time.deltaTime);
        }
    }
}
