using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Aufgabe2
{
    internal class Program
    {
        private const int Vertexcount = 5000000;
        private static VertexS[] _verticesS;
        private static VertexC[] _verticesC;
        private static VertexS[] _verticesSp;
        private static VertexC[] _verticesCp;
        private static readonly Random Rnd = new Random();

        private static double _test1Time;
        private static double _test2Time;
        private static double _test3Time;
        private static double _test4Time;

        private static void Main(string[] args)
        {
            _verticesS = new VertexS[Vertexcount];
            _verticesC = new VertexC[Vertexcount];

            _verticesSp = new VertexS[Vertexcount];
            _verticesCp = new VertexC[Vertexcount];

            var watch = new Stopwatch();
            watch.Start();
            InitStructs();
            watch.Stop();
            _test1Time = watch.ElapsedMilliseconds;
            watch.Reset();

            watch.Start();
            InitClasses();
            watch.Stop();
            _test2Time = watch.ElapsedMilliseconds;
            watch.Reset();

            watch.Start();
            InitStructsParallel();
            watch.Stop();
            _test3Time = watch.ElapsedMilliseconds;
            watch.Reset();

            watch.Start();
            InitClassesParallel();
            watch.Stop();
            _test4Time = watch.ElapsedMilliseconds;
            watch.Reset();


            Console.WriteLine("Building " + Vertexcount + " struct based vertices took " + _test1Time + " milliseconds.");
            Console.WriteLine("Building " + Vertexcount + " class based vertices took " + _test2Time + " milliseconds.");

            Console.WriteLine("Structs were " + _test2Time / _test1Time + " times faster.");

            Console.WriteLine("");

            Console.WriteLine("Building " + Vertexcount + " struct based vertices took " + _test3Time + " milliseconds. (Parallel)");
            Console.WriteLine("Building " + Vertexcount + " class based vertices took " + _test4Time + " milliseconds. (Parallel)");

            Console.WriteLine("Structs were " + _test4Time / _test3Time + " times faster.");

            Console.ReadKey();
        }

        private static void InitStructs()
        {
            for (var i = 0; i < Vertexcount; i++)
            {
                _verticesS[i].Normal.X = (float)Rnd.NextDouble();
                _verticesS[i].Normal.Y = (float)Rnd.NextDouble();
                _verticesS[i].Normal.Z = (float)Rnd.NextDouble();

                _verticesS[i].Position.X = (float)Rnd.NextDouble();
                _verticesS[i].Position.Y = (float)Rnd.NextDouble();
                _verticesS[i].Position.Z = (float)Rnd.NextDouble();

                _verticesS[i].Texcoord.U = (float)Rnd.NextDouble();
                _verticesS[i].Texcoord.V = (float)Rnd.NextDouble();
            }
        }
        private static void InitStructsParallel()
        {
            Parallel.For(0, Vertexcount, i =>
            {
                _verticesSp[i].Normal.X = (float)Rnd.NextDouble();
                _verticesSp[i].Normal.Y = (float)Rnd.NextDouble();
                _verticesSp[i].Normal.Z = (float)Rnd.NextDouble();

                _verticesSp[i].Position.X = (float)Rnd.NextDouble();
                _verticesSp[i].Position.Y = (float)Rnd.NextDouble();
                _verticesSp[i].Position.Z = (float)Rnd.NextDouble();

                _verticesSp[i].Texcoord.U = (float)Rnd.NextDouble();
                _verticesSp[i].Texcoord.V = (float)Rnd.NextDouble();
            });
        }

        private static void InitClasses()
        {
            for (var i = 0; i < Vertexcount; i++)
            {
                _verticesC[i] = new VertexC
                {
                    Normal = new Vector3C
                    {
                        X = (float) Rnd.NextDouble(),
                        Y = (float) Rnd.NextDouble(),
                        Z = (float) Rnd.NextDouble()
                    },
                    Position = new Vector3C
                    {
                        X = (float) Rnd.NextDouble(),
                        Y = (float) Rnd.NextDouble(),
                        Z = (float) Rnd.NextDouble()
                    },
                    Texcoord = new Uv2C
                    {
                        U = (float) Rnd.NextDouble(),
                        V = (float) Rnd.NextDouble()
                    }
                };



            }
        }
        private static void InitClassesParallel()
        {
            Parallel.For(0, Vertexcount, i =>
            {
                _verticesCp[i] = new VertexC
                {
                    Normal = new Vector3C
                    {
                        X = (float) Rnd.NextDouble(),
                        Y = (float) Rnd.NextDouble(),
                        Z = (float) Rnd.NextDouble()
                    },
                    Position = new Vector3C
                    {
                        X = (float) Rnd.NextDouble(),
                        Y = (float) Rnd.NextDouble(),
                        Z = (float) Rnd.NextDouble()
                    },
                    Texcoord = new Uv2C
                    {
                        U = (float) Rnd.NextDouble(),
                        V = (float) Rnd.NextDouble()
                    }
                };



            });
        }

        public static float ReadClasses(VertexC[] vc)
        {
            float calc = 0;

            foreach (VertexC t in vc)
            {
                var cal = (t.Position.X + t.Position.X + t.Position.X) / 3;
                calc = (cal + calc) / 2;
            }

            return calc;
        }
        public static float ReadStructs(VertexS[] vs)
        {
            float calc = 0;

            for (int i = 0; i < vs.Length; i++)
            {
                var cal = (vs[i].Position.X + vs[i].Position.X + vs[i].Position.X) / 3;
                calc = (cal + calc) / 2;
            }

            return calc;
        }

        public struct Uv2S
        {
            public float U;
            public float V;
        }

        public struct Vector3S
        {
            public float X;
            public float Y;
            public float Z;
        }

        public struct VertexS
        {
            public Vector3S Position;
            public Vector3S Normal;
            public Uv2S Texcoord;
        }

        public class Uv2C
        {
            public float U;
            public float V;
        }

        public class Vector3C
        {
            public float X;
            public float Y;
            public float Z;
        }

        public class VertexC
        {
            public Vector3C Position;
            public Vector3C Normal;
            public Uv2C Texcoord;
        }
    }
}