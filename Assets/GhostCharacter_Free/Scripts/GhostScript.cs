using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Sample
{
    public class GhostScript : MonoBehaviour
    {
        private Animator Anim;
        private NavMeshAgent Agent;
        private Transform Player;

        // Cache hash values
        private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
        private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
        private static readonly int AttackState = Animator.StringToHash("Base Layer.attack_shift");

        // Patrolling
        [SerializeField] private Transform[] PatrolPoints;
        private int CurrentPatrolIndex = 0;

        // Detection
        [SerializeField] private float DetectionRange = 10f;
        [SerializeField] private float AttackRange = 2f;
        [SerializeField] private float ChaseStopRange = 15f; // Distance beyond which the enemy stops chasing the player
        [SerializeField] private float PatrolWaitTime = 2f;  // Time to wait at each patrol point
        [SerializeField] private float seconds = 5f; //Cooldown after attacking player
        private bool IsChasingPlayer = false;
        private bool IsWaiting = false;
        private bool canAttack = true;

        void Start()
        {
            Anim = GetComponent<Animator>();
            Agent = GetComponent<NavMeshAgent>();

            // Find the player
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                Player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Player GameObject not found! Ensure the player has the 'Player' tag.");
            }

            // Start patrolling
            if (PatrolPoints.Length > 0)
            {
                Agent.SetDestination(PatrolPoints[CurrentPatrolIndex].position);
            }
        }

        void Update()
        {
            if (Player == null || Agent == null) return;

            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

            if (distanceToPlayer <= DetectionRange && distanceToPlayer > AttackRange)
            {
                StartChasingPlayer();
            }
            else if (distanceToPlayer <= AttackRange && canAttack)
            {
                AttackPlayer();
            }
            else if (distanceToPlayer > ChaseStopRange && IsChasingPlayer)
            {
                StopChasingPlayer();
            }
            else if (!IsChasingPlayer)
            {
                Patrol();
            }
        }

        //---------------------------------------------------------------------
        // Chasing Player
        //---------------------------------------------------------------------
        private void StartChasingPlayer()
        {
            IsChasingPlayer = true;
            Anim.CrossFade(MoveState, 0.1f);
            Agent.SetDestination(Player.position);
        }

        private void StopChasingPlayer()
        {
            IsChasingPlayer = false;
            Anim.CrossFade(IdleState, 0.1f);

            // Resume patrolling
            if (PatrolPoints.Length > 0)
            {
                Agent.SetDestination(PatrolPoints[CurrentPatrolIndex].position);
            }
        }

        //---------------------------------------------------------------------
        // Patrolling Behavior
        //---------------------------------------------------------------------
        private void Patrol()
        {
            if (PatrolPoints.Length == 0 || IsWaiting) return;

            if (!Agent.pathPending && Agent.remainingDistance < 0.5f)
            {
                StartCoroutine(WaitAtPatrolPoint());
            }
        }

        private IEnumerator WaitAtPatrolPoint()
        {
            IsWaiting = true;
            Anim.CrossFade(IdleState, 0.1f);

            yield return new WaitForSeconds(PatrolWaitTime);

            // Move to the next patrol point
            CurrentPatrolIndex = (CurrentPatrolIndex + 1) % PatrolPoints.Length;
            Agent.SetDestination(PatrolPoints[CurrentPatrolIndex].position);
            IsWaiting = false;
        }

        //---------------------------------------------------------------------
        // Attack Player
        //---------------------------------------------------------------------
        private void AttackPlayer()
        {
            Agent.ResetPath(); // Stop moving
            Anim.CrossFade(AttackState, 0.1f);
            PlayerHealth.hearts--;
            StartCoroutine(WaitCooldown(seconds));
        }
        private IEnumerator WaitCooldown(float time)
        {
            canAttack = false;
            yield return new WaitForSeconds(time);
            canAttack = true;
        }
    }
}
