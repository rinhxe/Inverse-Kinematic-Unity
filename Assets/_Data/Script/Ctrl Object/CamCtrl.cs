using Cinemachine;
using System.ComponentModel;
using UnityEngine;

public class CamCtrl: MonoBehaviour {
    public static CamCtrl instance;
   
    [Description("Assign camera: " +
        "Camera 1: Far side camera" +
        "Camera 2: Near side camera" +
        "Camera 3: FP camera")]
    [SerializeField] CinemachineVirtualCamera[] cameraList;



    private void Awake() {
        if(instance == null) {
            instance = this;

        }

    }

    public void SwitchToCamera(int index) {
        TurnOffAllCamera();
        cameraList[index].Priority = 10;
    }
    public void TurnOffAllCamera() {
        foreach(var cam in cameraList) {
            cam.Priority = -10;
        }
    }
}
