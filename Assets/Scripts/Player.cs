using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(Direction.Left);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            Move(Direction.Right);
        }


        else if (Input.GetKey(KeyCode.S))
        {
            Move(Direction.Down);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            Move(Direction.Up);
        }
    }

    private void Move(Direction dir)
    {
        if(dir == Direction.Left)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        else if(dir == Direction.Right)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }

        else if(dir == Direction.Up)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }

        else if(dir == Direction.Down)
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }
}
