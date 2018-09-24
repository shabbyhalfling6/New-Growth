using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour {

    public Vector2 startingDirection;
    public int branchLength = 10;

    public GameObject[] branchNodes;

    public GameObject nodeObject;
    public GameObject startingNode;

    public float baseDeviation = 0.5f;

    private LineRenderer treeRenderer;

	// Use this for initialization
	void Start ()
    {
        treeRenderer = this.GetComponent<LineRenderer>();

        //declaring the length of this branch, change to have a random length later based on what type of branch it is
        branchNodes = new GameObject[branchLength];
        //temporary setting a branch grow direction, this will depend on what the parent branch was and what angle it was at
        startingDirection = new Vector2(0, 0.5f);
        branchNodes[0] = startingNode;

        treeRenderer.positionCount = branchLength;
        treeRenderer.SetPosition(0, branchNodes[0].transform.position);

        for (int i = 1; i < branchLength; i++)
        {
            //the last node in the branches node array to act as a parent to the new node
            Transform parentTransform = branchNodes[i - 1].transform;

            //the location to be calculated at which the new node will be spawned, currently uses the parents position and adds the startingdirection vector2 to it
            Vector2 spawnPos = new Vector2(parentTransform.position.x + startingDirection.x, parentTransform.position.y + startingDirection.y);

            spawnPos.x = spawnPos.x + (Random.Range(-baseDeviation,baseDeviation));

            //Set the random angle calculated above to the angle of the to the new node
            Quaternion spawnRot = Quaternion.Euler(0, 0, 0);
            //instantiates the new node using the information that we got above
            GameObject newNode = Instantiate(nodeObject, spawnPos, spawnRot);
            branchNodes[i] = newNode;

            treeRenderer.SetPosition(i, branchNodes[i].transform.position);
        }

    }
}
