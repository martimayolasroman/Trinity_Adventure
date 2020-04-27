using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arco : MonoBehaviour
{
    private List<GameObject> letters = new List<GameObject>();
    public GameObject letterPrefab;
    public float letterVelocity;
    Vector3 direction;

    void Update()
    {
        direction = Input.mousePosition;
        direction.z = 0.0f;
        direction = Camera.main.ScreenToWorldPoint(direction);
        direction = direction - transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject letter = (GameObject)Instantiate(letterPrefab, transform.position, Quaternion.identity);
            letters.Add(letter);
        }
        for (int i = 0; i < letters.Count; i++)
        {
            GameObject goLetter = letters[i];
            if (goLetter != null)
            {
                goLetter.transform.Translate(direction * Time.deltaTime * letterVelocity);
                Vector3 letterScreenPosition = Camera.main.WorldToScreenPoint(goLetter.transform.position);
                if (letterScreenPosition.y >= Screen.height || letterScreenPosition.y <= 0 || letterScreenPosition.x >= Screen.width - 20 || letterScreenPosition.x <= -20)
                {
                    DestroyObject(goLetter);
                    letters.Remove(goLetter);
                }
            }
        }
    }


}



    

