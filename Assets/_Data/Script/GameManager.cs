using UnityEngine;

public class GameManager: MonoBehaviour {
    public static GameManager instance;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMovement playerMovement;


    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

}
