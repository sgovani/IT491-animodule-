using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour {

    public int curIndex = 0;
	void Start () {
        gameObject.GetComponent<ScrollRect>().horizontalNormalizedPosition = 0.0f;

    }
	
	
	void Update () {
		
	}
}
