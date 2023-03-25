namespace CountUnreachablePairsNodesUndirectedGraph
{
    internal class Program
    {
        public class CountUnreachablePairsNodesUndirectedGraph
        {

            private int DFS(Dictionary<int, List<int>> graph, bool[] visited, int node)
            {
                int count = 1;
                visited[node] = true;
                if (!graph.ContainsKey(node))
                {
                    return count;
                }
                foreach (int child in graph[node])
                {
                    if (!visited[child])
                    {
                        count += DFS(graph, visited, child);
                    }
                }
                return count;
            }

            public long CountPairs(int n, int[][] edges)
            {
                Dictionary<int, List<int>> graph = new();
                bool[] visited = new bool[n];
                foreach (int[] edge in edges)
                {
                    int parent = edge[0];
                    int child = edge[1];

                    if (!graph.ContainsKey(parent))
                    {
                        graph[parent] = new List<int>();
                    }
                    graph[parent].Add(child);
                    if (!graph.ContainsKey(child))
                    {
                        graph[child] = new List<int>();
                    }
                    graph[child].Add(parent);
                }

                long remainingNodes = n;
                long sizeOfComponents = 0;
                long numberPairNodes = 0;
                for (int i = 0; i < n; ++i)
                {
                    if (!visited[i])
                    {
                        sizeOfComponents = DFS(graph, visited, i);
                        numberPairNodes += sizeOfComponents * (remainingNodes - sizeOfComponents);
                        remainingNodes -= sizeOfComponents;
                    }
                }
                return numberPairNodes;
            }
        }

        static void Main(string[] args)
        {
            CountUnreachablePairsNodesUndirectedGraph countUnreachablePairsNodesUndirectedGraph = new();
            Console.WriteLine(countUnreachablePairsNodesUndirectedGraph.CountPairs(3, new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 1, 2 }
            }));
            Console.WriteLine(countUnreachablePairsNodesUndirectedGraph.CountPairs(7, new int[][]
            {
                new int[] { 0, 2 },
                new int[] { 0, 5 },
                new int[] { 2, 4 },
                new int[] { 1, 6 },
                new int[] { 5, 4 }
            }));
        }
    }
}