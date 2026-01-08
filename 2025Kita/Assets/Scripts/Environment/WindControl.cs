using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindControl : MonoBehaviour
{
    [SerializeField] private GameObject wind_RtL;
    [SerializeField] private GameObject wind_LtR;
    [SerializeField] private float interval = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wind());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Wind()
    {
        bool toggle = true;

        while (true)
        {
            wind_LtR.SetActive(toggle);
            wind_RtL.SetActive(!toggle);

            toggle = !toggle; // true/falseÇîΩì]
            yield return new WaitForSeconds(interval); // éwíËïbêîë“ã@
        }
    }
}
