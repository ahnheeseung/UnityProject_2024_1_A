using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text TextUI = null;  //�ؽ�ƮUI
    public int Count = 0;  //���콺 Ŭ�� ī����
    public int Power = 100; // ���� �� ��ġ
    public int Point = 0;
    public float checkTime = 0.0f;
    public Rigidbody m_Rigidbody;  //������Ʈ�� ��ü

    // Update is called once per frame
    void Update()
    {
        checkTime += Time.deltaTime;
        if(checkTime >=1.0f )
        {
            Point += 1;
            checkTime = 0.0f;
        }
           if (Input.GetMouseButtonDown(0)) //���콺 ���� �Է��� �Ǿ��� �� ����
        {
            Power = Random.Range(100, 200); //100~200 ������ ���� ���� �ش�.
            m_Rigidbody.AddForce(transform.up * Power); //Y������ ������ ���� �ش�.
         }
        TextUI.text = Point.ToString();
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Pipe")
        {
            Point = 0;
            gameObject.transform.position = Vector3.zero;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "items")
        {
            Point += 10;
            Destroy(other.gameObject);
        }
    }
}