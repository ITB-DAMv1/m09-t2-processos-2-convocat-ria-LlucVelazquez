using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Ex5
{
    public class Dispositiu
    {
        public string Nom { get; }
        public int Capacitat { get; }
        public int ConsumPerSegon { get; }
        public int CarreguesRealitzades { get; private set; } = 0;
        private readonly BateriaAuxiliar bateria;
        private readonly object lockObject;
        private bool potCarregar = true;

        public Dispositiu(string nom, int capacitat, int consumPerSegon, BateriaAuxiliar bateria, object lockObject)
        {
            Nom = nom;
            Capacitat = capacitat;
            ConsumPerSegon = consumPerSegon;
            this.bateria = bateria;
            this.lockObject = lockObject;
        }

        public void IniciaCarrega()
        {
            while (potCarregar)
            {
                lock (lockObject)
                {
                    if (!bateria.PotCarregar(Capacitat))
                    {
                        potCarregar = false;
                        break;
                    }
                    bateria.Carrega(Capacitat);
                    CarreguesRealitzades++;
                }
                int segons = Capacitat / ConsumPerSegon;
                Thread.Sleep(segons * 1000);
            }
        }
    }
    public class BateriaAuxiliar
    {
        public int CapacitatInicial { get; }
        public int CapacitatRestant { get; private set; }

        public BateriaAuxiliar(int capacitat)
        {
            CapacitatInicial = capacitat;
            CapacitatRestant = capacitat;
        }

        public bool PotCarregar(int quantitat)
        {
            return CapacitatRestant >= quantitat;
        }

        public void Carrega(int quantitat)
        {
            CapacitatRestant -= quantitat;
        }
    }
    public class Simulador
    {
        private readonly List<Dispositiu> dispositius;
        private readonly BateriaAuxiliar bateria;
        private readonly object lockObject = new object();

        public Simulador(BateriaAuxiliar bateria, List<(string nom, int capacitat, int consumPerSegon)> dispositiusInfo)
        {
            this.bateria = bateria;
            dispositius = new List<Dispositiu>();
            foreach (var info in dispositiusInfo)
                dispositius.Add(new Dispositiu(info.nom, info.capacitat, info.consumPerSegon, bateria, lockObject));
        }

        public void ExecutaSimulacio()
        {
            var threads = new List<Thread>();
            Stopwatch sw = Stopwatch.StartNew();

            foreach (var dispositiu in dispositius)
            {
                var thread = new Thread(dispositiu.IniciaCarrega);
                threads.Add(thread);
                thread.Start();
            }

            foreach (var thread in threads)
                thread.Join();

            sw.Stop();

            Console.WriteLine($"Temps total fins a esgotar la bateria: {sw.Elapsed.TotalSeconds} segons");
            foreach (var dispositiu in dispositius)
                Console.WriteLine($"Dispositiu {dispositiu.Nom}: {dispositiu.CarreguesRealitzades} càrregues realitzades");
            Console.WriteLine($"Energia restant a la bateria: {bateria.CapacitatRestant} mAh");
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Escenari 1:");
            var bateria1 = new BateriaAuxiliar(100_000);
            var dispositius1 = new List<(string, int, int)>
            {
                ("1", 30000, 10000),
                ("2", 20000, 12000),
                ("3", 5000, 1000)
            };
            var simulador1 = new Simulador(bateria1, dispositius1);
            simulador1.ExecutaSimulacio();

            Console.WriteLine("\nEscenari 2:");
            var bateria2 = new BateriaAuxiliar(100_000);
            var dispositius2 = new List<(string, int, int)>
            {
                ("1", 25000, 23000),
                ("2", 20000, 12000),
                ("3", 8000, 1000),
                ("4", 10000, 1000)
            };
            var simulador2 = new Simulador(bateria2, dispositius2);
            simulador2.ExecutaSimulacio();
        }
    }
}
