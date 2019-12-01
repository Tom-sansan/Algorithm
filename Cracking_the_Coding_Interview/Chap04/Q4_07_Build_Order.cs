using System;
using System.Collections.Generic;
using Ctci.Library;

namespace ExChapter04
{
    public class Q4_07_Build_Order
    {

#region Q4_07_EdgeRemoval
        public class Q4_07_EdgeRemoval
        {

            #region Project

            public class Project
            {
                private List<Project> children = new List<Project>();
                private Dictionary<String, Project> dic = new Dictionary<string, Project>();
                private String name;
                private int dependencies = 0;

                public Project(String n)
                {
                    this.name = n;
                }

                public String GetName()
                {
                    return this.name;
                }

                public void AddNeighbor(Project node)
                {
                    if (!dic.ContainsKey(node.GetName()))
                    {
                        this.children.Add(node);
                        this.dic.Add(node.GetName(), node);
                        node.IncrementDependencies();
                    }
                }

                public void IncrementDependencies()
                {
                    this.dependencies++;
                }

                public List<Project> GetChildren()
                {
                    return this.children;
                }

                public void DecrementDependencies()
                {
                    this.dependencies--;
                }

                public int GetNumberDependencies()
                {
                    return this.dependencies;
                }
            }

            #endregion Project

            #region Graph

            public class Graph
            {
                private List<Project> nodes = new List<Project>();
                private Dictionary<String, Project> dic = new Dictionary<string, Project>();

                public Project GetOrCreateNode(String name)
                {
                    if (!this.dic.ContainsKey(name))
                    {
                        Project node = new Project(name);
                        this.nodes.Add(node);
                        this.dic.Add(name, node);
                    }
                    return this.dic.GetValueOrDefault(name);
                }

                public void AddEdge(String startName, String endName)
                {
                    Project start = GetOrCreateNode(startName);
                    Project end = GetOrCreateNode(endName);
                    start.AddNeighbor(end);
                }

                public List<Project> GetNodes()
                {
                    return this.nodes;
                }
            }

            #endregion Graph

            /* Build the graph, adding the edge (a, b) if b is dependent on a. 
            * Assumes a pair is listed in “build order”. The pair (a, b) in 
            * dependencies indicates that b depends on a and a must be built
            * before b. */
            public static Graph BuildGraph(String[] projects, String[][] dependencies)
            {
                Graph graph = new Graph();
                foreach (var project in projects) graph.GetOrCreateNode(project);
                foreach (var dependency in dependencies)
                {
                    String first = dependency[0];
                    String second = dependency[1];
                    graph.AddEdge(first, second);
                }
                return graph;
            }

            /* A helper function to insert projects with zero dependencies 
             * into the order array, starting at index offset. */
             public static int AddNonDependent(Project[] order, List<Project> projects, int offset)
             {
                 foreach (var project in projects)
                 {
                     if (project.GetNumberDependencies() == 0)
                     {
                         order[offset] = project;
                         offset++;
                     }
                 }
                 return offset;
             }

            public static Project[] OrderProjects(List<Project> projects)
            {
                Project[] order = new Project[projects.Count];
                /* Add “roots” to the build order first.*/
                int endOfList = AddNonDependent(order, projects, 0);
                
                int toBeProcessed = 0;
                while (toBeProcessed < order.Length)
                {
                    Project current = order[toBeProcessed];

                    /* We have a circular dependency since there are no remaining
                     * projects with zero dependencies. */
                     if (current == null) return null;

                     /* Remove myself as a dependency. */
                     List<Project> children = current.GetChildren();
                     foreach (var child in children) child.DecrementDependencies();

                     /* Add children that have no one depending on them. */
                     endOfList = AddNonDependent(order, children, endOfList);
                     toBeProcessed++;
                }
                return order;
            }

            public static String[] ConvertToStringList(Project[] projects)
            {
                String[] buildOrder = new String[projects.Length];
                for (int i = 0; i < projects.Length; i++) buildOrder[i] = projects[i].GetName();
                return buildOrder;
            }

            public static Project[] FindBuildOrder(String[] projects, String[][] dependencies)
            {
                Graph graph = BuildGraph(projects, dependencies);
                return OrderProjects(graph.GetNodes());
            }

            public static String[] BuildOrderWrapper(String[] projects, String[][] dependencies)
            {
                Project[] buildOrder = FindBuildOrder(projects, dependencies);
                if (buildOrder == null) return null;
                String[] buildOrderString = ConvertToStringList(buildOrder);
                return buildOrderString;
            }
            public static void Q04_07_Run_J(String[] projects, String[][] dependencies)
            {
                String[] buildOrder = BuildOrderWrapper(projects, dependencies);
                if (buildOrder == null) Console.WriteLine("Circular Dependency.");
                else foreach (String s in buildOrder) Console.WriteLine(s);
            }
        }

#endregion Q4_07_EdgeRemoval

#region Q4_07_DFS

        public class Q4_07_DFS
        {

            #region Project

            public class Project
            {
                public enum State { COMPLETE, PARTIAL, BLANK }
                private List<Project> children = new List<Project>();
                private Dictionary<String, Project> dic = new Dictionary<string, Project>();
                private String name;
                private State state = State.BLANK;

                public Project(String n)
                {
                    this.name = n;
                }

                public String GetName()
                {
                    return this.name;
                }

                public void AddNeighbor(Project node)
                {
                    if(!this.dic.ContainsKey(node.GetName()))
                    {
                        this.children.Add(node);
                        this.dic.Add(node.GetName(), node);
                    }
                }

                public State GetState()
                {
                    return this.state;
                }

                public void SetState(State st)
                {
                    this.state = st;
                }

                public List<Project> GetChildren()
                {
                    return this.children;
                }
            }

            #endregion Project

            #region Graph

            public class Graph
            {
                private List<Project> nodes = new List<Project>();
                private Dictionary<String, Project> dic = new Dictionary<string, Project>();

                public Project GetOrCreateNode(String name)
                {
                    if (!this.dic.ContainsKey(name))
                    {
                        Project node = new Project(name);
                        this.nodes.Add(node);
                        this.dic.Add(name, node);
                    }
                    return this.dic.GetValueOrDefault(name);
                }

                public void AddEdge(String startName, String endName)
                {
                    Project start = GetOrCreateNode(startName);
                    Project end = GetOrCreateNode(endName);
                    start.AddNeighbor(end);
                }

                public List<Project> GetNodes()
                {
                    return this.nodes;
                }
            }

            #endregion Graph

            /* Build the graph, adding the edge (a, b) if b is dependent on a. 
            * Assumes a pair is listed in “build order” (which is the reverse 
            * of dependency order). The pair (a, b) in dependencies indicates
            * that b depends on a and a must be built before a. */
            public static Graph BuildGraph(String[] projects, String[][] dependencies)
            {
                Graph graph = new Graph();

                foreach (var dependency in dependencies)
                {
                    String first = dependency[0];
                    String second = dependency[1];
                    graph.AddEdge(first, second);
                }
                return graph;
            }

            public static bool DoDFS(Project project, Stack<Project> stack)
            {
                if (project.GetState() == Project.State.PARTIAL) return false;  // Cycle
                if (project.GetState() == Project.State.BLANK)
                {
                    project.SetState(Project.State.PARTIAL);
                    List<Project> children = project.GetChildren();
                    foreach (var child in children) if (!DoDFS(child, stack)) return false;
                    project.SetState(Project.State.COMPLETE);
                    stack.Push(project);
                }
                return true;
            }

            public static Stack<Project> OrderProjects(List<Project> projects)
            {
                Stack<Project> stack = new Stack<Project>();
                foreach (var project in projects)
                {
                    if (project.GetState() == Project.State.BLANK)
                    {
                        if (!DoDFS(project, stack)) return null;
                    }
                }
                return stack;
            }

            public static String[] ConvertToStringList(Stack<Project> projects)
            {
                String[] buildOrder = new String[projects.Count];
                for (int i = 0; i < buildOrder.Length; i++) buildOrder[i] = projects.Pop().GetName();
                return buildOrder;
            }

            public static Stack<Project> FindBuildOrder(String[] projects, String[][] dependencies)
            {
                Graph graph = BuildGraph(projects, dependencies);
                return OrderProjects(graph.GetNodes());
            }

            public static String[] BuildOrderWrapper(String[] projects, String[][] dependencies)
            {
                Stack<Project> buildOrder = FindBuildOrder(projects, dependencies);
                if (buildOrder == null) return null;
                String[] buildOrderString = ConvertToStringList(buildOrder);
                return buildOrderString;
            }

            public static void Q04_07_Run_J(String[] projects, String[][] dependencies)
            {
                String[] buildOrder = BuildOrderWrapper(projects, dependencies);
                if (buildOrder == null) Console.WriteLine("Circular Dependency.");
                else foreach (String s in buildOrder) Console.WriteLine(s);
            }
        }
        
#endregion Q4_07_DFS

        public static void Q04_07_Run_J()
        {
            String[] projects = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j"};
            String[][] dependencies = new String[][] 
            {
                new String[] {"a", "b"},
                new String[] {"b", "c"},
                new String[] {"a", "c"},
                new String[] {"a", "c"},
                new String[] {"d", "e"},
                new String[] {"b", "d"},
                new String[] {"e", "f"},
                new String[] {"a", "f"},
                new String[] {"h", "i"},
                new String[] {"h", "j"},
                new String[] {"i", "j"},
                new String[] {"g", "j"}
            };
            
            /*
            String[] projects = {"a", "b", "c", "d", "e", "f"};
            String[][] dependencies = new String[][] 
            {
                new String[] {"d", "a"},
                new String[] {"b", "f"},
                new String[] {"d", "b"},
                new String[] {"a", "f"},
                new String[] {"c", "d"}
            };
            */
            //Q4_07_EdgeRemoval.Q04_07_Run_J(projects, dependencies);
            Q4_07_DFS.Q04_07_Run_J(projects, dependencies);

            /* For Debug parameters
            nodes
            node.name
            children
            dic
            project.name
            project.dependencies
            child.name
            child.dependencies
            */
        }
    }
}