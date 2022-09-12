using System.Globalization;

namespace BinaryTree {
    internal class BinaryTree<T> where T : IComparable<T> {

        private readonly Node<T>? root;

        /// <summary>
        /// create a new empty binary tree
        /// </summary>
        public BinaryTree() { }

        /// <summary>
        /// create a new binary tree from an array or a variable number of params
        /// </summary>
        /// <param name="values">the array of params to covert to binary tree</param>
        public BinaryTree(params T[] values) {
            foreach (T data in values) {
                root = Add(data, root);
            }
        }
        /// <summary>
        /// Create a new binary tree from any enumerable type
        /// </summary>
        /// <param name="values">the enumerable type to convert to a binary tree</param>
        public BinaryTree(IEnumerable<T> values) {
            foreach (T data in values) {
                root = Add(data, root);
            }
        }
        /// <summary>
        /// Adds a new node to the tree
        /// </summary>
        /// <param name="data">The data to add as a new node to the tree</param>
        /// <param name="root">The root node of the tree</param>
        /// <returns>The new node that is created with the data value</returns>
        public Node<T> Add(T data, Node<T> root) {
            if (root == null) {
                return new Node<T>(data);
            }
            if (data.CompareTo(root.Data) < 0)
                root.Left = Add(data, root.Left);
            else
                root.Right = Add(data, root.Right);
            return root;
        }
        /// <summary>
        /// Prints the current tree in order
        /// </summary>
        /// <param name="root">the root node of the tree</param>
        public void InOrderPrint(Node<T> root) {
            if (root == null)
                return;
            InOrderPrint(root.Left);
            Console.Write(root.Data + " ");
            InOrderPrint(root.Right);
        }
        /// <summary>
        /// Deletes the node with the given data value
        /// </summary>
        /// <param name="root">root node of the tree</param>
        /// <param name="data">the data value to dlete from the tree</param>
        /// <returns>the node that is deleted if its found, otherwise returns null</returns>
        /// <exception cref="ArgumentNullException">If the data value is null throw exception</exception>
        public Node<T> Delete(Node<T> root, T data) {
            if (data == null)
                throw new ArgumentNullException("data");
            if (root == null)
                return null;
            if (data.CompareTo(root.Data) < 0)
                root.Left = Delete(root.Left, data);
            else if (data.CompareTo(root.Data) > 0)
                root.Right = Delete(root.Right, data);
            else {
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                root.Data = InOrderSuccessor(root.Right);
                root.Right = Delete(root.Right, root.Data);
            }
            return root;

        }
        /// <summary>
        /// Gets the data from the next smallest node of the passed in node data value
        /// </summary>
        /// <param name="root">the root node to be compare data too</param>
        /// <returns>the data value of the smallest node (farthest left child of root node)</returns>
        private T InOrderSuccessor(Node<T> root) {
            T small = root.Data;
            while (root.Left != null) {
                root = root.Left;
                small = root.Data;
            }
            return small;
        }
        /// <summary>
        /// changes the binary tree to a list
        /// </summary>
        /// <param name="root">the root node</param>
        /// <param name="list">the list to populate, by reference</param>
        public void ToList(Node<T> root, List<T> list) {
            if (root == null)
                return;
            ToList(root.Left, list);
            list.Add(root.Data);
            ToList(root.Right, list);
        }
        /// <summary>
        /// Create a binary tree from the given piece passed in data
        /// </summary>
        /// <param name="data">the piece of data to use as the new root node for the tree</param>
        /// <returns>A copy of the current binary tree with the param data as the new root node value, returns null
        /// if the data does not exist in the tree</returns>
        public BinaryTree<T> GetSubTreeByValue(T data) {
            List<T> list = new();
            Node<T> node = Search(Root, data);
            if (node == null)
                return null;
            ToList(node, list);
            return new BinaryTree<T>(list);
        }

        /// <summary>
        /// Search the tree for the given data and get the node with that data value
        /// </summary>
        /// <param name="root">the root node of the tree</param>
        /// <param name="data">the data value to find in the tree</param>
        /// <returns>the Node with the given data value or null if it does not exist</returns>
        /// <exception cref="ArgumentNullException">If the data value is null throw exception</exception>
        public Node<T> Search(Node<T> root, T data) {
            if (data == null)
                throw new ArgumentNullException("data");
            if (root == null)
                return null;

            if (root.Data.CompareTo(data) > 0)
                return Search(root.Left, data);
            else if (root.Data.CompareTo(data) < 0)
                return Search(root.Right, data);
            else 
                return root;
        }
        public Node<T> Root { get { return root; } }
    }
}
