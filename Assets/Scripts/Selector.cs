using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    List<Node> children = new List<Node>();

    public override NodeState Evaluate()
    {
        foreach (Node node in children)
        {
            switch (node.Evaluate())
            {
                case NodeState.FAILURE:
                    continue;
                case NodeState.SUCCESS:
                    state = NodeState.SUCCESS;
                    return state;
                case NodeState.RUNNING:
                    state = NodeState.RUNNING;
                    return state;
                default:
                    continue;
            }
        }

        state = NodeState.FAILURE;
        return state;
    }
}
