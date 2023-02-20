using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction = new Vector2(0, 1);

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        

    }

    public void ChangeRightDirection()
    {
        transform.Rotate(0f, 0f, -90f);
    }
    public void ChangeLeftDirection(){
        transform.Rotate(0f, 0f, 90f);
    }

    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }

}
