using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    private bool moving_up = true;

    // Start is called before the first frame update
    void Start()
    {
        // Start the elevator movement
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        // Optional: Add any additional logic here if needed
    }

    // Determine whether the platform should move up or down
    private Vector3 GetDirection()
    {
        return moving_up ? end.position : start.position;
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, GetDirection(), Time.deltaTime * speed);

            if (transform.position == start.position)
            {
                moving_up = true;
                yield return new WaitForSeconds(1.0f); // Pause before changing direction
            }

            if (transform.position == end.position)
            {
                moving_up = false;
                yield return new WaitForSeconds(1.0f); // Pause before changing direction
            }

            yield return null;
        }
    }
}
