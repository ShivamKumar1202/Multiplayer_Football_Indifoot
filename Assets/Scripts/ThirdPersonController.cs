using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject followCam;
    public bool rotate;
    public bool isStanding = true;


    public float speed = 15f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Animator playerAnimController;
    PhotonView pView;
    Vector3 direction;

    private void Start()
    {
        playerAnimController = GetComponentInChildren<Animator>();
        pView = GetComponent<PhotonView>();
        if (pView.IsMine)
        {
            followCam.SetActive(true);
            cam.SetActive(true);
        }
        else
        {
            followCam.SetActive(false);
            cam.SetActive(false);
        }

    }

    void Update()
    {

        if (pView.IsMine)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude > 0f && isStanding)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
                controller.Move(moveDir * speed * Time.deltaTime);
                playerAnimController.SetBool("IsWalking", true);
            }

            else
                playerAnimController.SetBool("IsWalking", false);

            if (Input.GetKeyDown(KeyCode.U))
            {
                
                playerAnimController.SetBool("isSitting", false);
                isStanding = true;
            }

            
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Chair")
        {
            
            isStanding = false;
            transform.forward = other.transform.forward;
            
            playerAnimController.SetBool("isSitting", true);
            Debug.Log("Chair");

        }

        if (other.gameObject.tag == "Player")
            Debug.Log("Player Touch");
    }
    
}
