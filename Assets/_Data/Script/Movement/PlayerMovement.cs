using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement: MonoBehaviour {

    public Joytick Joystick;

    public Animator playerAnimator;
    NavMeshAgent agent;

    [SerializeField] private bool isAutoMove;
    [SerializeField, Range(-1, 1)] private float movementVectoX = 0;
    [SerializeField, Range(-1, 1)] private float movementVectoZ = 0;
    [SerializeField, Range(0, 1)] private float AnimationSpeed = 0;

    void Start() {
    
        playerAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }



    void Update() {
        #region Move
        //Move by Joytick
        if(!isAutoMove) {
            Vector3 scaledMovement = agent.speed * Time.deltaTime * new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);
            agent.Move(scaledMovement);
            agent.transform.LookAt(agent.transform.position + scaledMovement, Vector3.up);
            playerAnimator.SetFloat("moveX", Joystick.Horizontal);
            playerAnimator.SetFloat("moveZ", Joystick.Vertical);
        }
        if(isAutoMove) {
            Vector3 scaledMovement = agent.speed * Time.deltaTime * new Vector3(movementVectoX, 0, movementVectoZ);
            agent.Move(scaledMovement);
            agent.transform.LookAt(agent.transform.position + scaledMovement, Vector3.up);
            playerAnimator.SetFloat("moveX", movementVectoX);
            playerAnimator.SetFloat("moveZ", movementVectoZ);
            UICtrl.instance.SetJoystickStatus(false);
            playerAnimator.speed = AnimationSpeed;
        }

        //AutoMove

        #endregion
      
    }

    public void StopPlayer() {
        movementVectoX = 0;
        movementVectoZ = 0;
    }
}
