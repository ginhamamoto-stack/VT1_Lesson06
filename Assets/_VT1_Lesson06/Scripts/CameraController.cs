using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform Target;       //カメラの注視点となるオブジェクトの参照
    public Transform CameraJoint;　//距離をとるためのオブジェクトの参照
    public Camera Camera;          //カメラの参照

    public PlayerInput PlayerInput;//PlayerInputの参照
    public Vector3 Position;       //カメラの位置
    public Vector3 Angles;         //カメラの角度
    public Vector3 Distance;       //原点（親オブジェクト）からの距離
    public float TiltMin;
    public float TiltMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputAction();
    }
    // Update is called once per frame
    void Update()
    {
        Position = Target.position;

        //カメラのチルト(x軸回転)に制限を設ける
        Angles.x = Mathf.Clamp(Angles.x, TiltMin, TiltMax);
    }
    void LateUpdate()
    {
        transform.position = Position;
        transform.eulerAngles = Angles;
        // rotation(Quaternion型)に直接代入したい時↓
        // transform.rotation = Auaternion.Euler(Angles);

        //注視点からの距離を更新する
        CameraJoint.localPosition = Distance;
    }


    private void InputAction()
    {
        if(PlayerInput == null)
        {
            Debug.Log("PlayerInputが見つかりません.。");
            return;
        }
        PlayerInput.actions["Look"].performed += context =>
        {
            var value = context.ReadValue<Vector2>();
            Angles.x -= value.y;
            Angles.y += value.x;
        };
        PlayerInput.actions["Look"].Enable();
    }
}
