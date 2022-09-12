using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree {
    internal class Node<T> where T : IComparable<T> {

        private T data;
        private Node<T>? left, right;
        public T Data { get { return data; } set { data = value;  } }
        public Node<T> Left { get { return left; } set { left = value; } }
        public Node<T> Right { get { return right; } set { right = value; } }   
        public Node(T data) { this.data = data; }

        public override string ToString() {
            if (data == null)
                return "";
            return data.ToString();
        }

    }
}
