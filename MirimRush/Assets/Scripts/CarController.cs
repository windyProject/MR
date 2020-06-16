using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeft;
    public WheelCollider frontRight;
    public float torque = 1.0f;

    //public GameObject WheelMeshes[];
    public WheelCollider[] m_WheelCollider = new WheelCollider[4];
    public GameObject[] m_WheelMeshes = new GameObject[4];

    public float MaxSteeringAngle = 30;
    private new Rigidbody rigidbody = null;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            for (int i = 0; i < 4; ++i)
            {
                m_WheelCollider[i].brakeTorque = 0;
            }

            frontLeft.motorTorque = torque;
            frontRight.motorTorque = torque;
        }
        else
        {
            frontLeft.motorTorque = 0;
            frontRight.motorTorque = 0;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            frontLeft.brakeTorque = torque * 2;
            frontRight.brakeTorque = torque * 2;
        }

        if (Mathf.Abs(frontLeft.steerAngle) > MaxSteeringAngle)
        {
            frontLeft.steerAngle = Mathf.Sign(frontLeft.steerAngle) * MaxSteeringAngle;
            frontRight.steerAngle = Mathf.Sign(frontRight.steerAngle) * MaxSteeringAngle;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                frontLeft.steerAngle -= 1.0f;
                frontRight.steerAngle -= 1.0f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                frontLeft.steerAngle += 1.0f;
                frontRight.steerAngle += 1.0f;
            }
            else
            {
                if (Mathf.Abs(frontLeft.steerAngle) > 0.1f)
                {
                    // 이미 꺽여 있다면 제 자리로.
                    if (frontLeft.steerAngle > 0)
                    {
                        frontLeft.steerAngle -= 1.0f;
                        frontRight.steerAngle -= 1.0f;
                    }
                    else
                    {
                        frontLeft.steerAngle += 1.0f;
                        frontRight.steerAngle += 1.0f;
                    }
                }
            }
        }

        // wheel collider로 부터 위치와 회전을 얻고 메시에 설정한다.
        for (int i = 0; i < 4; i++)
        {
            Quaternion quat;
            Vector3 position;
            m_WheelCollider[i].GetWorldPose(out position, out quat);
            m_WheelMeshes[i].transform.position = position;
            m_WheelMeshes[i].transform.rotation = quat;
        }

        AddDownForce();
    }

    private void AddDownForce()
    {
        // 차량 전체에 아래쪽으로 힘을 준다.
        rigidbody.AddForce(-transform.up * 100 * rigidbody.velocity.magnitude);
    }
}
