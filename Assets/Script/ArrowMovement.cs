using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowMovement : MonoBehaviour
{
    public float speed = 5f;
    
    public GameObject tailPrefab;//꼬리 prefabs 저장
    private List<GameObject> tail = new List<GameObject>(); // 꼬리를 담아줄 list
    private bool ate = false;
    private Vector2 previousPosition; // 이전 위치
    public float tailDistance = 0.25f; // 꼬리 간격
    Vector2 direction = new Vector2(0,1);
    Vector2 tempDirect;
    void Start(){
        previousPosition = transform.position;
    }

    void Update()
    {
        
        if(ate) {
            AddTail();
            ate = false;
        }


        
       if (tail.Count > 0)
        {
            switch(transform.rotation.eulerAngles.z){
                case 0f:
                    tempDirect = Vector2.up;
                break;
                case 90f:
                    tempDirect = Vector2.left;
                break;
                case 180f:
                    tempDirect = Vector2.down;
                break;
                case 270f:
                    tempDirect = Vector2.right;
                break;
            }

            tail[0].transform.position = previousPosition - tempDirect * tailDistance;
        

            for (int i = 1; i < tail.Count; i++)
            {
                Vector3 tailDistanceVector = (tail[i - 1].transform.position - tail[i].transform.position).normalized * tailDistance;
                tail[i].transform.position = tail[i - 1].transform.position - tailDistanceVector;
            }
        }
        
        previousPosition = transform.position;

        transform.Translate(direction * speed * Time.deltaTime);

        // 이전 위치 업데이트
    }

    public void ChangeRightDirection()
    {
        transform.Rotate(0f, 0f, -90f);
    }
    public void ChangeLeftDirection(){
        transform.Rotate(0f, 0f, 90f);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collider");
        if (other.gameObject.tag == "Food")
        {
            Destroy(other.gameObject);
            ate = true;
        }
    }

    void AddTail()
    {
        GameObject tailObj = Instantiate(tailPrefab, tail.Count > 0 ? tail[tail.Count - 1].transform.position : transform.position, Quaternion.identity);
        tail.Add(tailObj);
    }
}







