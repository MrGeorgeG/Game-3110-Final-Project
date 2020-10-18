using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Handling
    public float rotationSpeed = 450;
    public float walkSpeed = 5;
    public float runSpeed = 8;
    public float number = 1;

    private Quaternion targetRotation;

    public Weapon weapon;
    private CharacterController controller;
    private Camera cam;
    Vector3 lookPos;
    GameObject aim;

    // Start is called before the first frame update
    void Start()
    {
        aim = new GameObject();
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ControlMouse();
        //ControlWASD();

        if (Input.GetButtonDown("Shoot"))
        {
            weapon.Shoot();
        }
    }

    void ControlMouse()
    {
        //Vector3 mousePos = Input.mousePosition;
        //mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
        //targetRotation = Quaternion.LookRotation(mousePos);
        //transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
     
        if (Physics.Raycast(ray, out hit,100 ))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;
        transform.LookAt(transform.position + lookDir, Vector3.up);
        //aim.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
   

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 motion = input;
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f : 1;
        motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;
        motion += Vector3.up * -8;

        controller.Move(motion * Time.deltaTime);
    }

    void ControlWASD()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

        }

        Vector3 motion = input;
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f : 1;
        motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;
        motion += Vector3.up * -8;

        controller.Move(motion * Time.deltaTime);
    }
}
