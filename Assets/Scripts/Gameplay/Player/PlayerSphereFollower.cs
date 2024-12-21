using UnityEngine;
using UnityEngine.AI;

public class PlayerSphereFollower : MonoBehaviour
{
    private GameObject _playerSphere;
    private PlayerSphereMovement _playerSphereMovement;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerSphere = GameObject.FindGameObjectWithTag("Player");
        _playerSphereMovement = _playerSphere.GetComponent<PlayerSphereMovement>();
    }

    private void Update()
    {
        if (_playerSphere != null)
        {
            Debug.Log(_agent.obstacleAvoidanceType);
            _agent.SetDestination(_playerSphere.transform.position);
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
