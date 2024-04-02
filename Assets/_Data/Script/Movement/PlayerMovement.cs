using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement: MonoBehaviour {
    [Description("File For Character Movement")]

    public static PlayerMovement instance;
    public Joytick Joystick;
    public Animator playerAnimator;
    NavMeshAgent agent;

    [SerializeField] private bool isAutoMove;
    [SerializeField, Range(0, 1)] private float movementVectoX = 0;
    [SerializeField, Range(0, 1)] private float movementVectoZ = 0;
    [SerializeField, Range(-1, 1)] private float AnimationSpeed = 0;
    Vector2 currentMovement ;
    public float Animationspeed {
        get => AnimationSpeed;
        set => AnimationSpeed = value;
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    void Start() {
        playerAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        currentMovement = new Vector2(movementVectoX,movementVectoZ);
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
            playerAnimator.speed = Animationspeed;
        }
        //AutoMove
        #endregion
    }
    public void StopPlayer() {
        movementVectoX = 0;
        movementVectoZ = 0;
    }
    public void ResumePlayer() {
        movementVectoX = currentMovement.x;
        movementVectoZ = currentMovement.y;
    }
}
