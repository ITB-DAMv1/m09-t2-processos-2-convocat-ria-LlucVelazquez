using System.Diagnostics;

namespace Ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string outputFile = "../../../processos_i_fils.txt";
            int totalProcessos = 0;
            int totalFils = 0;

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (Process proc in Process.GetProcesses())
                {
                    try
                    {
                        writer.WriteLine($"Procés PID: {proc.Id}, Nom: {proc.ProcessName}");
                        writer.WriteLine("  Fils:");

                        foreach (ProcessThread thread in proc.Threads)
                        {
                            writer.WriteLine($"    ID: {thread.Id}, Estat: {thread.ThreadState}");
                            totalFils++;
                        }

                        writer.WriteLine();
                        totalProcessos++;
                    }
                    catch (Exception ex)
                    {
                        // Alguns processos poden no ser accessibles (accés denegat)
                        writer.WriteLine($"Procés PID: {proc.Id}, Nom: {proc.ProcessName} - No accessible ({ex.Message})");
                        writer.WriteLine();
                        totalProcessos++;
                    }
                }

                writer.WriteLine($"Total processos: {totalProcessos}");
                writer.WriteLine($"Total fils: {totalFils}");
            }

            Console.WriteLine($"Arxiu generat: {outputFile}");
            Console.WriteLine($"Processos: {totalProcessos}, Fils: {totalFils}");
        }
    }
}
