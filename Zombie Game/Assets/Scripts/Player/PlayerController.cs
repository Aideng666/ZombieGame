using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;

    Rigidbody body;
    Transform trans;

    float horizontalInput;
    float verticalInput;

    float timeToNextShot = 0;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && CanShoot())
        {
            Shoot();
        }

        Walk();
        FaceMouse();
    }

    void FaceMouse()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);

        float distance;

        if (ground.Raycast(mouseRay, out distance))
        {
            Vector3 target = mouseRay.GetPoint(distance);

            Vector3 direction = target - trans.position;

            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }

    void Walk()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            trans.position += new Vector3(1, 0, 1) * speed * Time.deltaTime;
            //trans.rotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            trans.position += new Vector3(-1, 0, 1) * speed * Time.deltaTime;
            //trans.rotation = Quaternion.Euler(new Vector3(0, 315, 0));
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            trans.position += new Vector3(-1, 0, -1) * speed * Time.deltaTime;
            //trans.rotation = Quaternion.Euler(new Vector3(0, 225, 0));
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            trans.position += new Vector3(1, 0, -1) * speed * Time.deltaTime;
            //trans.rotation = Quaternion.Euler(new Vector3(0, 135, 0));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            trans.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
            //trans.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            trans.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
            //trans.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            trans.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            //trans.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            trans.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            //trans.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(90, trans.rotation.eulerAngles.y, 0));

        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

        Destroy(bullet, 5);
    }

    bool CanShoot()
    {
        if (timeToNextShot < Time.realtimeSinceStartup)
        {
            timeToNextShot = Time.realtimeSinceStartup + 0.2f;
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
