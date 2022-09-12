using BinaryTree;

BinaryTree<int> binaryTree = new(1, 5, 2, 6, 12, 4, 8, 20, 30, 40);

binaryTree.InOrderPrint(binaryTree.Root);
//binaryTree.Delete(binaryTree.Root, 5);
Console.WriteLine();
List<int> treeList = new();
binaryTree.ToList(binaryTree.Root, treeList);
treeList.ForEach(x => Console.Write(x + " "));
Console.WriteLine();
BinaryTree<int> subTree = binaryTree.GetSubTreeByValue(5);
subTree.InOrderPrint(subTree.Root);

