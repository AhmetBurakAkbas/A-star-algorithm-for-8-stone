using System;
using System.Collections.Generic;
using System.Linq;

namespace _8Tas_AStarAlgorithm_223311062
{
    public class AStarSolver
    {
        private class Node
        {
            public int[,] State { get; }
            public Node Parent { get; }
            public int G { get; } 
            public int H { get; } 
            public int F => G + H; 

            public Node(int[,] state, Node parent, int g, int h)
            {
                State = state;
                Parent = parent;
                G = g;
                H = h;
            }
        }

        public static List<int[,]> Solve(int[,] baslangic, int[,] hedef)
        {
      
            var openSet = new List<Node>();
            var visited = new HashSet<string>();

            Node startNode = new Node(baslangic, null, 0, Heuristic(baslangic, hedef));
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
  
                openSet = openSet.OrderBy(n => n.F).ToList();
                Node current = openSet.First();
                openSet.RemoveAt(0);

                Console.WriteLine($"İşlenen Düğüm - F: {current.F}, G: {current.G}, H: {current.H}");
                PrintMatrix(current.State);

                if (IsSameState(current.State, hedef))
                {
                    Console.WriteLine("Çözüm Bulundu!");
                    return GetSolutionPath(current);
                }

                visited.Add(MatrixToString(current.State));

                foreach (var neighbor in GetNeighbors(current, hedef))
                {
                    string stateStr = MatrixToString(neighbor.State);
                    if (!visited.Contains(stateStr))
                    {
                        openSet.Add(neighbor);
                        Console.WriteLine("Yeni komşu eklendi:");
                        PrintMatrix(neighbor.State);
                    }
                }
            }

            Console.WriteLine("Çözüm bulunamadı!");
            return null;
        }

        private static List<int[,]> GetSolutionPath(Node node)
        {
            List<int[,]> path = new List<int[,]>();
            while (node != null)
            {
                path.Insert(0, node.State);
                node = node.Parent;
            }
            return path;
        }

        private static int Heuristic(int[,] current, int[,] hedef)
        {
            int h = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int value = current[i, j];
                    if (value != 0)
                    {
                        (int goalX, int goalY) = FindPosition(hedef, value);
                        h += Math.Abs(i - goalX) + Math.Abs(j - goalY);
                    }
                }
            }
            return h;
        }

        private static List<Node> GetNeighbors(Node node, int[,] hedef)
        {
            List<Node> neighbors = new List<Node>();
            (int x, int y) = FindPosition(node.State, 0);
            int[,] moves = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            for (int i = 0; i < moves.GetLength(0); i++)
            {
                int newX = x + moves[i, 0], newY = y + moves[i, 1];
                if (newX >= 0 && newX < 3 && newY >= 0 && newY < 3)
                {
                    int[,] newState = CopyMatrix(node.State);
                    (newState[x, y], newState[newX, newY]) = (newState[newX, newY], newState[x, y]);
                    Node newNode = new Node(newState, node, node.G + 1, Heuristic(newState, hedef));
                    neighbors.Add(newNode);
                }
            }
            return neighbors;
        }

        private static (int, int) FindPosition(int[,] matrix, int value)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (matrix[i, j] == value) return (i, j);
            return (-1, -1);
        }

        private static bool IsSameState(int[,] a, int[,] b)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (a[i, j] != b[i, j]) return false;
            return true;
        }

        private static int[,] CopyMatrix(int[,] matrix)
        {
            int[,] newMatrix = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    newMatrix[i, j] = matrix[i, j];
            return newMatrix;
        }

        private static string MatrixToString(int[,] matrix)
        {
            return string.Join(",", matrix.Cast<int>());
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
