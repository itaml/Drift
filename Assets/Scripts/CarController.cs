using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public Rigidbody theRB;
    public float forwardAccel = 8f, maxSpeed = 50f, turnStrenght = 180, gravityForce = 10f, dragOnTheGround = 3f, driftForce = 2f;
    private float speedInput, turnInput;

    public Transform leftFrontWheel, rightFrontWheel;
    public float maxWheelTurn = 25f;

    public ParticleSystem[] dustTrail;
    public float maxEmission = 25f;
    private float emissionRate;
 
    public GameObject smoke;
    public Finish finish_class;

    void Start()
    {
        theRB.transform.parent = null;
    }

    void Update()
    {
        if(finish_class.gameOver != true)
        {
            speedInput = forwardAccel * 100f;
            turnInput = Input.GetAxis("Horizontal");
            if (turnInput != 0)
            {
                theRB.AddForce((transform.forward * speedInput) / 100f);
                smoke.SetActive(true);
            }
            else { smoke.SetActive(false); }

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime / 1.3f, 0f));

            leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, leftFrontWheel.localRotation.eulerAngles.z);
            rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn, rightFrontWheel.localRotation.eulerAngles.z);

            transform.position = theRB.transform.position;
        }
        else
        {
            smoke.SetActive(false);
            transform.position = theRB.transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (finish_class.gameOver != true)
        {
            emissionRate = 0f;

            theRB.drag = dragOnTheGround;
            if (Mathf.Abs(speedInput) > 0)
            {
                theRB.AddForce(transform.forward * speedInput);
                emissionRate = maxEmission;
            }
            foreach (ParticleSystem part in dustTrail)
            {
                var emissionModule = part.emission;
                emissionModule.rateOverTime = emissionRate;
            }
        }
    }

}
