using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemPostar
{
    internal class ShortestRoute
    {
        private Dictionary<string, Dictionary<string, int>> _graph;

        public ShortestRoute(Dictionary<string, Dictionary<string, int>> graph)
        {
            _graph = graph;
        }

        public List<string> FindShortestRoute(string start, string end)
        {
            if (!_graph.ContainsKey(start))
            {
                throw new ArgumentException("Start city not found in the graph.");
            }

            var distances = new Dictionary<string, int>();
            var visited = new Dictionary<string, bool>();
            foreach (var city in _graph.Keys)
            {
                distances[city] = int.MaxValue;
                visited[city] = false;
            }

            distances[start] = 0;

            while (true)
            {
                var currentCity = GetNextCity(distances, visited);
                if (currentCity == null) break;

                visited[currentCity] = true;

                foreach (var neighbor in _graph[currentCity])
                {
                    var neighborCity = neighbor.Key;
                    var neighborDistance = neighbor.Value;

                    if (!visited[neighborCity] && distances[currentCity] != int.MaxValue &&
                        distances[currentCity] + neighborDistance < distances[neighborCity])
                    {
                        distances[neighborCity] = distances[currentCity] + neighborDistance;
                    }
                }
            }

            var shortestPath = new List<string>();
            var current = end;
            while (current != start)
            {
                shortestPath.Add(current);
                var minNeighbor = _graph[current].FirstOrDefault(x => distances[x.Key] == distances[current] - _graph[x.Key][current]);
                current = minNeighbor.Key;
            }
            shortestPath.Add(start);
            shortestPath.Reverse();

            return shortestPath;
        }

        private string GetNextCity(Dictionary<string, int> distances, Dictionary<string, bool> visited)
        {
            var minDistance = int.MaxValue;
            string minCity = null;

            foreach (var kvp in distances)
            {
                if (!visited[kvp.Key] && kvp.Value < minDistance)
                {
                    minDistance = kvp.Value;
                    minCity = kvp.Key;
                }
            }

            return minCity;
        }
    }
}
