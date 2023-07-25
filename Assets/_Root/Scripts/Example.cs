using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using _Root.Scripts;
using UnityEngine;

public class Example : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        int[] nums = { 1, -2, 3, 0, -4, 5 };
        var posNums = from n in nums where n > 0 where n <= 3 select n;
        foreach (var item in posNums)
        {
            Debug.Log(item);
        }
    }
}


