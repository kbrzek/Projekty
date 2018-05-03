using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication10.model;

namespace ConsoleApplication10
{
    class DijkstraAlgorithm
    {
        private List<Vertex> nodes;
        private List<Edge> edges;
        private HashSet<Vertex> settledNodes;
        private HashSet<Vertex> unSettledNodes;
        private Dictionary<Vertex, Vertex> predecessors;
        private Dictionary<Vertex, int> distance;

        public DijkstraAlgorithm(Graph graph)
        {
            
            this.nodes = new List<Vertex>(graph.vertexes);
            this.edges = new List<Edge>(graph.edges);
        }
            
        public void execute(Vertex source)
        {
            settledNodes = new HashSet<Vertex>();
            unSettledNodes = new HashSet<Vertex>();
            distance = new Dictionary<Vertex, int>();
            predecessors = new Dictionary<Vertex, Vertex>();
            distance[source] = 0;
            unSettledNodes.Add(source);
            while (unSettledNodes.Count() > 0)
            {
                Vertex node = getMinimum(unSettledNodes);
                settledNodes.Add(node);
                unSettledNodes.Remove(node);
                findMinimalDistances(node);
                
               
                
            }
        }

        private void findMinimalDistances(Vertex node)
        {
            List<Vertex> adjacentNodes = getNeighbors(node);
            foreach (Vertex target in adjacentNodes)
            {
               
                if (getShortestDistance(target) > getShortestDistance(node)+ getDistance(node, target))
                {
                   
                        distance[target] = getShortestDistance(node) + getDistance(node, target);
                        predecessors[target] = node;
                    
                    
                    unSettledNodes.Add(target);
                }
            }

        }

        private int getDistance(Vertex node, Vertex target)
        {
            foreach (Edge edge in edges)
            {
                if (edge.source.Equals(node)&& edge.destination.Equals(target))
                {
                  
                    return edge.weight;
                }
            }
            throw new Exception("Should not happen");
        }

        private List<Vertex> getNeighbors(Vertex node)
        {
            List<Vertex> neighbors = new List<Vertex>();
            foreach (Edge edge in edges)
            {
                if (edge.source.Equals(node) && !isSettled(edge.destination))
                {
                    neighbors.Add(edge.destination);
                }
            }
            return neighbors;
        }

        private Vertex getMinimum(HashSet<Vertex> vertexes)
        {
            Vertex minimum = null;
            foreach (Vertex vertex in vertexes)
            {
                if (minimum == null)
                {
                    minimum = vertex;
                }
                else
                {
                    if (getShortestDistance(vertex) < getShortestDistance(minimum))
                    {
                        minimum = vertex;
                    }
                }
            }
            return minimum;
        }

        private bool isSettled(Vertex vertex)
        {
            return settledNodes.Contains(vertex);
        }

        private int getShortestDistance(Vertex destination)
        {
       
            if (distance.ContainsKey(destination))
            {
                
                return distance[destination];
            }
            else
            {
                
                return int.MaxValue;
            }

        }

       
        public List<Vertex> getPath(Vertex target)
        {
            List<Vertex> path = new List<Vertex>();
            Vertex step = target;
            // czy sciezka istnieje
            if (predecessors[step] == null)
            {
                return null;
            }
            path.Add(step);
            while (predecessors.ContainsKey(step))
            {
                step = predecessors[step];
                path.Add(step);
            }

            path.Reverse();
           
            return path;
        }
    }
}
