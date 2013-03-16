namespace PathFinder
{
	using System;
	using System.Collections.Generic;

	class Dijkstra
	{
		internal double[] Distances { get; private set; }
		internal int[] Parents { get; private set; }

		private List<int> queue = new List<int>();

		private void InitializeSingleSource(int s, int len)
		{
			Distances = new double[len];
			Parents = new int[len];

			for (int i = 0; i < len; i++)
			{
				Distances[i] = Double.PositiveInfinity;
				Parents[i] = 0;

				queue.Add(i);
			}

			Distances[s] = 0;
			Parents[s] = -1;
		}

		private int ExtractMin()
		{
			double min = Double.PositiveInfinity;
			int Vertex = -1;

			foreach (int j in queue)
			{
				if (Distances[j] <= min)
				{
					min = Distances[j];
					Vertex = j;
				}
			}

			queue.Remove(Vertex);

			return Vertex;

		}

		/// <summary>
		/// Takes a graph as input an adjacency matrix (see top for details) and a starting node
		/// </summary>
		/// <param name="G"></param>
		/// <param name="s"></param>
		internal Dijkstra(double[,] G, int s)
		{
			/* Check graph format and that the graph actually contains something */
			if (G.GetLength(0) < 1 || G.GetLength(0) != G.GetLength(1))
			{
				throw new ArgumentException("Graph error, wrong format or no nodes to compute");
			}

			int len = G.GetLength(0);

			InitializeSingleSource(s, len);

			while (queue.Count > 0)
			{
				int u = ExtractMin();

				/* Find the nodes that u connects to and perform relax */
				for (int v = 0; v < len; v++)
				{
					/* Checks for edges with negative weight */
					if (G[u, v] < 0)
					{
						throw new ArgumentException("Graph contains negative edge(s)");
					}

					/* Check for an edge between u and v */
					if (G[u, v] > 0)
					{
						Relax(u,v, G);
					}
				}
			}
		}

		void Relax(int u, int v, double[,] G)
		{
			/* Edge exists, relax the edge */
			if (Distances[v] > Distances[u] + G[u, v])
			{
				Distances[v] = Distances[u] + G[u, v];
				Parents[v] = u;
			}
		}
	}
}
