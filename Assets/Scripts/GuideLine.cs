using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideLine : MonoBehaviour {

    public float lineNum = 300.0f;

    private LineRenderer lineRender;

	// Use this for initialization
	void Start () {
        lineRender = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        lineRender.SetPosition(0, transform.position);

        lineRender.SetPosition(1, transform.forward * lineNum + transform.position);
	}
}
