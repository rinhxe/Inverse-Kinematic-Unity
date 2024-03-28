using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement: MonoBehaviour {

    public Joytick Joystick;

    public Animator playerAnimator;
    NavMeshAgent agent;



    void Start() {
        playerAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }



    void Update() {
#region Move
        Vector3 scaledMovement = agent.speed * Time.deltaTime * new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);
        agent.Move(scaledMovement);
        agent.transform.LookAt(agent.transform.position + scaledMovement, Vector3.up);
#endregion
#region Animation
        playerAnimator.SetFloat("moveX", Joystick.Horizontal);
        playerAnimator.SetFloat("moveZ", Joystick.Vertical);
#endregion
    }
}
