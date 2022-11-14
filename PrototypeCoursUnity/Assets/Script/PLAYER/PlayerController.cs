using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float axisH, axisV;
    public  bool isFPC = true;
    public bool wantToShoot = false;
    bool crouch = false;
    [SerializeField]
    bool jump = false;
    [SerializeField]
    GameObject cameraFPC,cameraTPC, mainCamera;

    Animator animator;
    Rigidbody rb;

    [SerializeField]
    float walkSpeed = 2f, runSpeed = 8f, crouchSpeed = 2f , sensitivity = 3f;

    //Rotation de la caméra
    float rotationX = 0;
    public float rotationSpeed = 2.0f;
    public float rotationXLimit = 45.0f;

    private void Awake()
    {
        changeCamera();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Cursor.visible = false;  //curseur invisible
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        axisH = Input.GetAxis("Horizontal");
        axisV = Input.GetAxis("Vertical");

        if (axisV >= 0)
        {
            if (Input.GetButton("Run"))
            {

                animator.SetInteger("moving", 2);
                transform.Translate(Vector3.forward * runSpeed * axisV * Time.deltaTime);
                GetComponent<NoiseStatus>().NoiseLevel = 2;
            }
            else if(!crouch)
            {
                animator.SetInteger("moving", 1);
                transform.Translate(Vector3.forward * walkSpeed * axisV * Time.deltaTime);
                GetComponent<NoiseStatus>().NoiseLevel = 1;
            }
            else
            {
                animator.SetInteger("moving", 1);
                transform.Translate(Vector3.forward * crouchSpeed * axisV * Time.deltaTime);
                GetComponent<NoiseStatus>().NoiseLevel = 0;
            }
        }
        else if(axisV <= 0 && !crouch)
        {
            animator.SetInteger("moving", -1);
            transform.Translate(Vector3.forward * walkSpeed * axisV * Time.deltaTime);
            GetComponent<NoiseStatus>().NoiseLevel = 0;
        }
        if(axisV == 0)
        {
            animator.SetInteger("moving", 0);
           

        }
        if (axisH != 0 && !crouch)
        {
            animator.SetInteger("moving", 1);
            transform.Translate(Vector3.right * walkSpeed * axisH * Time.deltaTime);
        }
        else if(axisH == 0 && axisV==0)
        {
            animator.SetInteger("moving", 0);
        }

        //Rotation de la caméra

        rotationX += -Input.GetAxis("Mouse Y") * rotationSpeed;

        //On limite rotationX, entre -rotationXLimit et rotationXLimit (-45 et 45)
        rotationX = Mathf.Clamp(rotationX, -rotationXLimit, rotationXLimit);
        //Applique la rotation haut/bas sur la caméra
        mainCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //Applique la rotation gauche/droite sur le Player
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);

        if (Input.GetButtonDown("ChangeCam"))
        {
            isFPC = !isFPC;
            changeCamera();
        }

        if (Input.GetButtonDown("Jump") && jump==false)
        {
            rb.AddForce(transform.up *200);
            animator.SetBool("jump", true);
            jump = true;
            StartCoroutine(Jump());
        }

        if (Input.GetButtonDown("Fire1"))
        {
            wantToShoot = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            wantToShoot = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch = !crouch;
            if (crouch)
            {
                mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y - 0.5f, mainCamera.transform.localPosition.z);
                animator.SetBool("crouch", true);
                GetComponent<NoiseStatus>().NoiseLevel = 0;

            }
            else
            {
                mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y + 0.5f, mainCamera.transform.localPosition.z);
                animator.SetBool("crouch", false);
            }
        }
        
    }

    void changeCamera()
    {

        if (isFPC)
        {
            cameraFPC.SetActive(true);
            mainCamera = cameraFPC;
            cameraTPC.SetActive(false);
        }
        else
        {
            cameraTPC.SetActive(true);
            mainCamera = cameraTPC;
            cameraFPC.SetActive(false);
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.8f);
        jump = false;
        animator.SetBool("jump", false);

    }

}
