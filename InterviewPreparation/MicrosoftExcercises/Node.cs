﻿using System.Collections.Generic;

namespace InterviewPreparation.MicrosoftExcercises
{
    public class Node
    {
        public int val;
        public Node next;
        public Node left;
        public Node right;
        public Node random;
        public IList<Node> children = new List<Node>();
        internal Node parent;

        public Node()
        {
        }

        public Node(int _val, Node _left)
        {
            val = _val;
            left = _left;
        }

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
