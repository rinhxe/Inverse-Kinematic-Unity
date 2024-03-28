using UnityEngine;

public class BoneIKController: MonoBehaviour {
    bool process = false;
    [SerializeField] private PlayerController playerController;
    public bool Process {
        get => process;
        set => process = value;
    }

    public void DoneEvent() {
        playerController.CheckEndAnimation();
        gameObject.SetActive(false);
    }
}
