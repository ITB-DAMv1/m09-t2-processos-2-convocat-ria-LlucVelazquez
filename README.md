# T2. 2ona Convocatòria: Recull d’activitats

## 1.

   1\. Bases de dades distribuïdes (ex: Apache Cassandra, MongoDB, Couchbase)  
     
   Què fan: Gestionen i emmagatzemen dades repartides entre diversos servidors o ubicacions geogràfiques. Permeten que múltiples usuaris accedeixin, modifiquin i consultin dades de manera simultània i eficient.  
     
   Per què han de ser distribuïdes: Això garanteix alta disponibilitat, tolerància a fallades (si cau un node, els altres segueixen funcionant) i escalabilitat, ja que es poden afegir més servidors fàcilment per gestionar més volum de dades o més usuaris.  
     
   2\. Plataformes de computació en núvol (ex: Amazon Web Services, Microsoft Azure)  
     
   Què fan: Ofereixen serveis informàtics (emmagatzematge, processament, bases de dades, etc.) a través d’Internet, utilitzant una infraestructura global de servidors interconnectats.  
     
   Per què han de ser distribuïdes: Permeten repartir la càrrega de treball, garantir la disponibilitat global, escalar recursos segons la demanda i assegurar la continuïtat del servei davant possibles fallades locals.  
     
   3\. Xarxes Blockchain i criptomonedes (ex: Bitcoin, Ethereum)  
     
   Què fan: Gestionen registres digitals (blockchain) on es registren transaccions de manera segura i immutable, sense necessitat d’una autoritat central.  
     
   Per què han de ser distribuïdes: La descentralització garanteix la seguretat i la resistència a manipulacions, ja que la informació es replica i valida per milers de nodes independents arreu del món.  
     
   4\. Sistemes de compartició d’arxius P2P (ex: BitTorrent)  
     
   Què fan: Permeten compartir i descarregar arxius entre usuaris sense passar per un servidor central. Cada usuari pot ser alhora client i servidor.  
     
   Per què han de ser distribuïdes: Això fa que el sistema sigui molt eficient, escalable i tolerant a fallades, ja que la disponibilitat dels arxius no depèn d’un únic punt i la càrrega es reparteix entre tots els participants.  
     
   5\. Plataformes de processament de grans volums de dades (ex: Apache Hadoop)  
     
   Què fan: Permeten processar i analitzar enormes quantitats de dades (big data) utilitzant centenars o milers de servidors que treballen en paral·lel.  
     
   Per què han de ser distribuïdes: El volum de dades i la necessitat de processament ràpid fan inviable fer-ho en un sol ordinador. La distribució permet dividir la feina i obtenir resultats molt més ràpidament.

## 2.

1\. Multithreading (fils d’execució simultània)  
   Com funciona: Cada nucli pot gestionar múltiples fils d’execució (threads) gràcies a tecnologies com Hyper-Threading (Intel) o Simultaneous Multi-Threading (AMD). Això permet simular múltiples "nuclis virtuals" per nucli físic.  
     
   Avantatges:  
     
   Millora la utilització dels recursos del nucli, reduint temps morts mentre s’espera a dades o operacions d’entrada/sortida.  
     
   Augmenta el rendiment en aplicacions amb paral·lelisme a nivell de fil (p.ex., servidors web).  
     
2\. Processament paral·lel de tasques  
   Com funciona: Les tasques es divideixen en subtasques que s’executen simultàniament en nuclis diferents. S’utilitzen models de programació com OpenMP o MPI per gestionar-ho.  
     
   Avantatges:  
     
   Escalabilitat en càrregues de treball intenses (p.ex., renderització 3D o simulacions científiques).  
     
   Reducció del temps total d’execució en problemes divisiblebles (com processament d’imatges).  
     
3\. Vectorització (SIMD)  
   Com funciona: Instruccions que processen múltiples dades en paral·lel dins d’un mateix nucli (p.ex., extensions AVX en x86).  
     
   Avantatges:  
     
   Acceleració significativa en operacions repetitives amb dades estructurades (p.ex., càlcul matricial o processament de senyals).  
     
   Menys sobrecarga en la gestió de fils comparat amb el multithreading.  
     
4\. Multiprocessament asimètric (heterogeni)  
   Com funciona: Nuclis amb arquitectures diferents dins del mateix xip (p.ex., big.LITTLE d’ARM), on nuclis grans gestionen càrregues pesades i els petits tasques lleugeres.  
     
   Avantatges:  
     
   Optimització energètica: els nuclis petits consumeixen menys energia per tasques de fons.  
     
   Millor equilibri entre rendiment i eficiència en dispositius mòbils.  
     
5\. Passatge de missatges (IPC)  
   Com funciona: Els nuclis es comuniquen mitjançant memòria compartida o sistemes de missatgeria (p.ex., pipes o cues), utilitzat en entorns distribuïts o sistemes operatius.  
     
   Avantatges:  
     
   Aïllament de processos: errors en un nucli no afecten als altres.  
     
   Flexibilitat en sistemes amb múltiples dispositius o nodes.  

## 3.

Programació paral·lela  
Definició: Divideix una tasca gran en parts més petites que s’executen simultàniament en diversos nuclis o processadors.

Objectiu: Augmentar la velocitat d’execució aprofitant la capacitat de processament múltiple.

Exemple: Processar 100 imatges a la vegada, assignant cada imatge a un nucli diferent.

Programació asíncrona  
Definició: Permet executar operacions que poden trigar (com accés a xarxa o disc) sense bloquejar el fil principal, gestionant la resposta quan l’operació acaba.

Objectiu: Mantenir l’aplicació responsiva mentre s’esperen operacions lentes.

Exemple: Carregar dades d’una API sense congelar la interfície d’usuari.

Aspecte	Paral·lela	Asíncrona  
Execució simultània	Sí, en múltiples nuclis	No necessàriament, pot ser un sol fil  
Casos d’ús	Càlculs intensius, processament massiu	I/O, xarxa, UI responsiva  
Bloqueig de fil	Pot bloquejar si no es gestiona bé	Evita bloqueig de fil principal  
Exemples	Renderització, simulacions	Descàrrega fitxers, UI, missatgeria  
Cicle de vida del mètode asíncron (segons el diagrama)  
Crida del mètode asíncron  
El mètode GetUrlContentLengthAsync() és cridat pel codi principal.

Inicialització del client HTTP  
Es crea un objecte HttpClient per fer la petició web.

Inici de l’operació asíncrona  
S’executa client.GetStringAsync(url), que retorna una tasca (Task\<string\>) que representa la descàrrega pendent.

Execució de treball independent  
S’executa DoIndependentWork(), una funció que fa alguna feina mentre la descàrrega segueix en marxa.

Espera asíncrona (await)  
Quan el codi arriba a await getStringTask, si la tasca encara no ha acabat, el mètode es suspèn i retorna el control al cridador.

Reprendre quan acaba la tasca  
Quan la descàrrega acaba, el codi es reprèn automàticament desprès de l’await.

Processament del resultat  
S’obté el contingut descarregat i es calcula la seva longitud.

Retorn del resultat  
Es retorna la longitud com a resultat de la tasca asíncrona.

Resum visual (seguint el diagrama):

L’operació asíncrona permet fer altres tasques mentre s’espera.

El fil principal no queda bloquejat.

Quan la tasca asíncrona acaba, el codi continua automàticament.

Quin tipus de programació utilitzar en cada aplicació?  
1\. Processament de lots d’imatges  
Tipus: Programació paral·lela

Raó: Cada imatge es pot processar independentment. Dividir el lot entre diversos nuclis permet processar més imatges alhora i reduir el temps total.

2\. Aplicació d’escriptori per a usuaris (UI fluida)  
Tipus: Programació asíncrona

Raó: Les operacions lentes (com carregar fitxers o dades de xarxa) han de ser asíncrones per no bloquejar la interfície d’usuari i mantenir-la responsiva.

3\. Aplicació de missatgeria en temps real  
Tipus: Programació asíncrona

Raó: L’aplicació ha d’esperar missatges de la xarxa sense bloquejar-se. L’asíncronia permet rebre i enviar missatges mentre la UI segueix activa.

4\. Renderització de gràfics en 3D  
Tipus: Programació paral·lela

Raó: La imatge es pot dividir en blocs petits que es poden renderitzar simultàniament en diferents nuclis, accelerant molt el procés.

##7.

### **Què pretén fer el codi**

El programa simula la lectura de diversos sensors en paral·lel, cadascun executat en un thread. Cada thread genera 100.000 lectures aleatòries entre -20 i 50, actualitza el valor de la seva posició a l’array `Readings`, i actualitza els valors globals de màxim i mínim (`GlobalMax`, `GlobalMin`). Al final, mostra el màxim, el mínim i el temps total de processament.

---

### **Errors**

1. **Condicions de carrera (Race conditions)**
    - Les variables globals `GlobalMax` i `GlobalMin` són modificades per múltiples threads sense cap protecció. Això pot provocar resultats incorrectes, ja que dos threads poden llegir i escriure simultàniament.
    - L’array `Readings` també es pot veure afectat si s’accedeix simultàniament.
2. **Ús incorrecte de Random**
    - L’objecte `Random rng` es comparteix entre tots els threads. `Random` no és thread-safe, i això pot provocar valors repetits o errors.
3. **Gestió incorrecta del temps**
    - El cronòmetre `StopWatch` (a més, mal escrit com `Stopwacth` i `StarNew()`) es fa servir dins de cada thread, però només s’hauria d’iniciar i aturar al fil principal per mesurar el temps total.
4. **No s’espera la finalització dels threads**
    - El programa mostra els resultats abans que els threads acabin, així que els valors de màxim, mínim i el temps no són vàlids.
5. **Errors de sintaxi i tipografia**
    - `StopWatch` està mal escrit.
    - `StarNew()` i `Restart()` no són mètodes vàlids de `Stopwatch`.
    - Falta `using System.Threading;` i `using System.Diagnostics;`.

---

## Codi reescrit i corregit

```csharp
using System;
using System.Threading;
using System.Diagnostics;

namespace SensorRace
{
    class Program
    {
        public static int[] Readings;
        public static int GlobalMax = int.MinValue;
        public static int GlobalMin = int.MaxValue;
        private static readonly object lockObj = new object();

        static void Main(string[] args)
        {
            Console.Write("Introdueix el nombre de sensors: ");
            int sensors = int.Parse(Console.ReadLine());
            Stopwatch sw = Stopwatch.StartNew();

            Readings = new int[sensors];
            Thread[] threads = new Thread[sensors];

            for (int i = 0; i < sensors; i++)
            {
                int id = i;
                threads[i] = new Thread(() =>
                {
                    // Cada thread té el seu propi Random
                    Random rng = new Random(Guid.NewGuid().GetHashCode());
                    for (int j = 0; j < 100000; j++)
                    {
                        int value = rng.Next(-20, 51);
                        Readings[id] = value;

                        lock (lockObj)
                        {
                            if (value > GlobalMax)
                                GlobalMax = value;
                            if (value < GlobalMin)
                                GlobalMin = value;
                        }
                    }
                });
                threads[i].Start();
            }

            // Espera que tots els threads acabin
            foreach (var thread in threads)
                thread.Join();

            sw.Stop();
            Console.WriteLine($"Final – Max: {GlobalMax}, Min: {GlobalMin}");
            Console.WriteLine($"Total Process time: {sw.Elapsed.TotalMilliseconds} ms");
        }
    }
}
```

[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/_qWLA2_7)
