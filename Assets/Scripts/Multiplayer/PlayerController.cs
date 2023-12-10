using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //GameObject cameraHolder;

    //[SerializeField]
    //float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;

    //float verticalLockRotation;
    //bool grounded;
    //Vector3 smoothMoveVelocity;
    //Vector3 moveAmount;


    //Rigidbody rb;
    
    
    PhotonView PV;
    Unit g;

    private void Awake()
    {

        PV = GetComponent<PhotonView>();

    }
    public void TriggerSkill(Unit caller, int index, GameObject target = null)
    {
        //Debug.Log(caller);
        //caller.PV.RPC("RPCTriggerSkill", RpcTarget.All, index, target);
        PV.RPC("teste", RpcTarget.All);
    }
    [PunRPC]
    public void teste()
    {
        Debug.Log("teste");
    }
    private void Start()
    {
        // rb = GetComponent<Rigidbody>();
       
        if (!PV.IsMine && gameObject.tag == "MainCamera")
        {
            Destroy(GetComponent<Camera>().gameObject);
            //Destroy(rb);
            return;
        }
       

    }

    private void Update()
    {
        if(!PV.IsMine) return;
        //Look();
        //Move();
        //Jump();
      
    }

    //void Look()
    //{
    //    transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

    //    verticalLockRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
    //    verticalLockRotation = Mathf.Clamp(verticalLockRotation, -90f, 90f);

    //    cameraHolder.transform.localEulerAngles = Vector3.left * verticalLockRotation;
    //}

    //void Move()
    //{
    //    Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

    //    moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    //}

    //void Jump()
    //{
    //    if (Input.GetKey(KeyCode.Space) && grounded)
    //    {
    //        rb.AddForce(transform.up * jumpForce);
    //    }
    //}

    //public void SetGroundedState(bool _grounded)
    //{
    //    grounded = _grounded;
    //}

    private void FixedUpdate()
    {
        if (!PV.IsMine) return;
        //rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
