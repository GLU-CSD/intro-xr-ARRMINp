using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform playerTransform;

    // Transform voor de basislocatie
    [SerializeField] private Transform baseLocation;

    // Flag om te bepalen of de vijand naar de speler of naar de basis moet
    private bool moveToBase = false;

    void Start()
    {
        // Vind de NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Zoek de XR Rig met de tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Base");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        // Controleer of de basislocatie is ingesteld
        if (moveToBase && baseLocation != null)
        {
            // Beweeg naar de basislocatie
            agent.SetDestination(baseLocation.position);
        }
        else if (playerTransform != null)
        {
            // Beweeg naar de speler
            agent.SetDestination(playerTransform.position);
        }
    }

    // Schakel tussen speler en basis
    public void ToggleTarget()
    {
        moveToBase = !moveToBase;
    }
}
