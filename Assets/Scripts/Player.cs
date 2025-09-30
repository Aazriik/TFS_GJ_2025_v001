using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {

        float xMov = Input.GetAxisRaw("Horizontal");

        float yMov = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(xMov, yMov, 0);

        if(direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * -90f);
        }

        else if(direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 90f);
        }

        if(direction.y > 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 0f);
        }

        else if(direction.y < 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 180f);
        }

        if(direction.x > 0 && direction.y > 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * -45f);
        }

        if(direction.x > 0 && direction.y < 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * -135f);
        }

        if(direction.x < 0 && direction.y < 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * -225f);
        }

        if(direction.x < 0 && direction.y > 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * -315);
        }

        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
