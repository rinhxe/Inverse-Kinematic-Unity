using Cinemachine;
using UnityEngine;

public class CamCtrl: MonoBehaviour {
    public static CamCtrl instance;

    [SerializeField] CinemachineVirtualCamera camera_1;
    [SerializeField] CinemachineVirtualCamera camera_2;


    private void Awake() {
        if(instance == null) {
            instance = this;

        }

    }

    public void TurnOffCam1() {
        camera_1.Priority = -10;
    }
    public void TurnOffCam2() {
        camera_2.Priority = -10;
    }

    public void TurnOnCam1() {
        camera_1.Priority = 10;
    }
    public void TurnOnCam2() {
        camera_2.Priority = 10;
    }
}
