using System.Diagnostics;

namespace Ex6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simulació SEQÜENCIAL:");
            double tempsSeq = SimulacioSequencial();
            Console.WriteLine($"\nTemps total seqüencial: {tempsSeq} s\n");

            Console.WriteLine("Simulació PARAL·LELA:");
            double tempsPar = SimulacioParalela();
            Console.WriteLine($"\nTemps total paral·lela: {tempsPar} s\n");

            Console.WriteLine($"\nDiferència de temps: {tempsSeq - tempsPar} s");
        }
        static double SimulacioSequencial()
        {
            Stopwatch sw = Stopwatch.StartNew();

            BatreMassa();
            PreescalfarForn();
            Enfornar();
            PrepararCobertura();
            RefredarBase();
            Glassejar();
            Decorar();

            sw.Stop();
            return sw.Elapsed.TotalSeconds;
        }
        static double SimulacioParalela()
        {
            Stopwatch sw = Stopwatch.StartNew();

            var batreMassaTask = Task.Run(BatreMassa);
            var preescalfarFornTask = Task.Run(PreescalfarForn);

            Task.WaitAll(batreMassaTask, preescalfarFornTask);
            var enfornarTask = Task.Run(Enfornar);
            var prepararCoberturaTask = Task.Run(PrepararCobertura);

            enfornarTask.Wait();
            var refredarBaseTask = Task.Run(RefredarBase);

            prepararCoberturaTask.Wait();
            refredarBaseTask.Wait();

            var glassejarTask = Task.Run(Glassejar);
            glassejarTask.Wait();

            var decorarTask = Task.Run(Decorar);
            decorarTask.Wait();

            sw.Stop();
            return sw.Elapsed.TotalSeconds;
        }
        static void BatreMassa() { SimulaTasca("Batre la massa", 8); }
        static void PreescalfarForn() { SimulaTasca("Pre-escalfar forn", 10); }
        static void Enfornar() { SimulaTasca("Enfornar", 15); }
        static void PrepararCobertura() { SimulaTasca("Preparar cobertura", 5); }
        static void RefredarBase() { SimulaTasca("Refredar base", 4); }
        static void Glassejar() { SimulaTasca("Glassejar", 3); }
        static void Decorar() { SimulaTasca("Decorar", 2); }

        static void SimulaTasca(string nom, int segons)
        {
            Console.WriteLine($"{nom}... ({segons}s)");
            Task.Delay(segons * 1000).Wait();
        }
    }
}