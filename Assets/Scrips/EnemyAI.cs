using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class EnemyAI : MonoBehaviour
{
    public Transform player;          // Referencia al jugador
    public float detectionRadius = 10f; // Radio de detecci�n del jugador
    public float attackRadius = 1.5f;   // Radio de ataque
    public float moveSpeed = 3.5f;      // Velocidad de movimiento del enemigo
    public float attackCooldown = 2f;   // Tiempo entre ataques

    private bool isPlayerInRange;
    private bool isAttacking;
    private float lastAttackTime;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        lastAttackTime = -attackCooldown;  // Para poder atacar al inicio
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // Verifica si el jugador est� dentro del rango de detecci�n
        if (distanceToPlayer <= detectionRadius)
        {
            // Actualiza la posici�n del jugador como el destino del agente
            agent.SetDestination(player.position);

            // Verifica si el enemigo est� lo suficientemente cerca para atacar
            if (distanceToPlayer <= attackRadius && !isAttacking && Time.time >= lastAttackTime + attackCooldown)
            {
                StartCoroutine(AttackPlayer());
            }
        }
        else
        {
            // Si el jugador est� fuera del rango de detecci�n, el enemigo se detiene
            agent.ResetPath();
        }
    }

    private IEnumerator AttackPlayer()
    {
        isAttacking = true;
        agent.isStopped = true; // Detiene el movimiento mientras ataca

        // Ejecuta el ataque aqu� (puedes a�adir animaci�n o da�o al jugador)
        Debug.Log("Atacando al jugador");

        lastAttackTime = Time.time;
        yield return new WaitForSeconds(attackCooldown);

        agent.isStopped = false; // Reactiva el movimiento
        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja el rango de detecci�n y el rango de ataque en el editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
