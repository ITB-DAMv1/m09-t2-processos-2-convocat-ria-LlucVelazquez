# T2. 2ona Convocat�ria: Recull d�activitats

## 1.

   1\. Bases de dades distribu�des (ex: Apache Cassandra, MongoDB, Couchbase)  
     
   Qu� fan: Gestionen i emmagatzemen dades repartides entre diversos servidors o ubicacions geogr�fiques. Permeten que m�ltiples usuaris accedeixin, modifiquin i consultin dades de manera simult�nia i eficient.  
     
   Per qu� han de ser distribu�des: Aix� garanteix alta disponibilitat, toler�ncia a fallades (si cau un node, els altres segueixen funcionant) i escalabilitat, ja que es poden afegir m�s servidors f�cilment per gestionar m�s volum de dades o m�s usuaris.  
     
   2\. Plataformes de computaci� en n�vol (ex: Amazon Web Services, Microsoft Azure)  
     
   Qu� fan: Ofereixen serveis inform�tics (emmagatzematge, processament, bases de dades, etc.) a trav�s d�Internet, utilitzant una infraestructura global de servidors interconnectats.  
     
   Per qu� han de ser distribu�des: Permeten repartir la c�rrega de treball, garantir la disponibilitat global, escalar recursos segons la demanda i assegurar la continu�tat del servei davant possibles fallades locals.  
     
   3\. Xarxes Blockchain i criptomonedes (ex: Bitcoin, Ethereum)  
     
   Qu� fan: Gestionen registres digitals (blockchain) on es registren transaccions de manera segura i immutable, sense necessitat d�una autoritat central.  
     
   Per qu� han de ser distribu�des: La descentralitzaci� garanteix la seguretat i la resist�ncia a manipulacions, ja que la informaci� es replica i valida per milers de nodes independents arreu del m�n.  
     
   4\. Sistemes de compartici� d�arxius P2P (ex: BitTorrent)  
     
   Qu� fan: Permeten compartir i descarregar arxius entre usuaris sense passar per un servidor central. Cada usuari pot ser alhora client i servidor.  
     
   Per qu� han de ser distribu�des: Aix� fa que el sistema sigui molt eficient, escalable i tolerant a fallades, ja que la disponibilitat dels arxius no dep�n d�un �nic punt i la c�rrega es reparteix entre tots els participants.  
     
   5\. Plataformes de processament de grans volums de dades (ex: Apache Hadoop)  
     
   Qu� fan: Permeten processar i analitzar enormes quantitats de dades (big data) utilitzant centenars o milers de servidors que treballen en paral�lel.  
     
   Per qu� han de ser distribu�des: El volum de dades i la necessitat de processament r�pid fan inviable fer-ho en un sol ordinador. La distribuci� permet dividir la feina i obtenir resultats molt m�s r�pidament.

## 2.

1\. Multithreading (fils d�execuci� simult�nia)  
   Com funciona: Cada nucli pot gestionar m�ltiples fils d�execuci� (threads) gr�cies a tecnologies com Hyper-Threading (Intel) o Simultaneous Multi-Threading (AMD). Aix� permet simular m�ltiples "nuclis virtuals" per nucli f�sic.  
     
   Avantatges:  
     
   Millora la utilitzaci� dels recursos del nucli, reduint temps morts mentre s�espera a dades o operacions d�entrada/sortida.  
     
   Augmenta el rendiment en aplicacions amb paral�lelisme a nivell de fil (p.ex., servidors web).  
     
2\. Processament paral�lel de tasques  
   Com funciona: Les tasques es divideixen en subtasques que s�executen simult�niament en nuclis diferents. S�utilitzen models de programaci� com OpenMP o MPI per gestionar-ho.  
     
   Avantatges:  
     
   Escalabilitat en c�rregues de treball intenses (p.ex., renderitzaci� 3D o simulacions cient�fiques).  
     
   Reducci� del temps total d�execuci� en problemes divisiblebles (com processament d�imatges).  
     
3\. Vectoritzaci� (SIMD)  
   Com funciona: Instruccions que processen m�ltiples dades en paral�lel dins d�un mateix nucli (p.ex., extensions AVX en x86).  
     
   Avantatges:  
     
   Acceleraci� significativa en operacions repetitives amb dades estructurades (p.ex., c�lcul matricial o processament de senyals).  
     
   Menys sobrecarga en la gesti� de fils comparat amb el multithreading.  
     
4\. Multiprocessament asim�tric (heterogeni)  
   Com funciona: Nuclis amb arquitectures diferents dins del mateix xip (p.ex., big.LITTLE d�ARM), on nuclis grans gestionen c�rregues pesades i els petits tasques lleugeres.  
     
   Avantatges:  
     
   Optimitzaci� energ�tica: els nuclis petits consumeixen menys energia per tasques de fons.  
     
   Millor equilibri entre rendiment i efici�ncia en dispositius m�bils.  
     
5\. Passatge de missatges (IPC)  
   Com funciona: Els nuclis es comuniquen mitjan�ant mem�ria compartida o sistemes de missatgeria (p.ex., pipes o cues), utilitzat en entorns distribu�ts o sistemes operatius.  
     
   Avantatges:  
     
   A�llament de processos: errors en un nucli no afecten als altres.  
     
   Flexibilitat en sistemes amb m�ltiples dispositius o nodes.  

## 3.

Programaci� paral�lela  
Definici�: Divideix una tasca gran en parts m�s petites que s�executen simult�niament en diversos nuclis o processadors.

Objectiu: Augmentar la velocitat d�execuci� aprofitant la capacitat de processament m�ltiple.

Exemple: Processar 100 imatges a la vegada, assignant cada imatge a un nucli diferent.

Programaci� as�ncrona  
Definici�: Permet executar operacions que poden trigar (com acc�s a xarxa o disc) sense bloquejar el fil principal, gestionant la resposta quan l�operaci� acaba.

Objectiu: Mantenir l�aplicaci� responsiva mentre s�esperen operacions lentes.

Exemple: Carregar dades d�una API sense congelar la interf�cie d�usuari.

Aspecte	Paral�lela	As�ncrona  
Execuci� simult�nia	S�, en m�ltiples nuclis	No necess�riament, pot ser un sol fil  
Casos d��s	C�lculs intensius, processament massiu	I/O, xarxa, UI responsiva  
Bloqueig de fil	Pot bloquejar si no es gestiona b�	Evita bloqueig de fil principal  
Exemples	Renderitzaci�, simulacions	Desc�rrega fitxers, UI, missatgeria  
Cicle de vida del m�tode as�ncron (segons el diagrama)  
Crida del m�tode as�ncron  
El m�tode GetUrlContentLengthAsync() �s cridat pel codi principal.

Inicialitzaci� del client HTTP  
Es crea un objecte HttpClient per fer la petici� web.

Inici de l�operaci� as�ncrona  
S�executa client.GetStringAsync(url), que retorna una tasca (Task\<string\>) que representa la desc�rrega pendent.

Execuci� de treball independent  
S�executa DoIndependentWork(), una funci� que fa alguna feina mentre la desc�rrega segueix en marxa.

Espera as�ncrona (await)  
Quan el codi arriba a await getStringTask, si la tasca encara no ha acabat, el m�tode es susp�n i retorna el control al cridador.

Reprendre quan acaba la tasca  
Quan la desc�rrega acaba, el codi es repr�n autom�ticament despr�s de l�await.

Processament del resultat  
S�obt� el contingut descarregat i es calcula la seva longitud.

Retorn del resultat  
Es retorna la longitud com a resultat de la tasca as�ncrona.

Resum visual (seguint el diagrama):

L�operaci� as�ncrona permet fer altres tasques mentre s�espera.

El fil principal no queda bloquejat.

Quan la tasca as�ncrona acaba, el codi continua autom�ticament.

Quin tipus de programaci� utilitzar en cada aplicaci�?  
1\. Processament de lots d�imatges  
Tipus: Programaci� paral�lela

Ra�: Cada imatge es pot processar independentment. Dividir el lot entre diversos nuclis permet processar m�s imatges alhora i reduir el temps total.

2\. Aplicaci� d�escriptori per a usuaris (UI fluida)  
Tipus: Programaci� as�ncrona

Ra�: Les operacions lentes (com carregar fitxers o dades de xarxa) han de ser as�ncrones per no bloquejar la interf�cie d�usuari i mantenir-la responsiva.

3\. Aplicaci� de missatgeria en temps real  
Tipus: Programaci� as�ncrona

Ra�: L�aplicaci� ha d�esperar missatges de la xarxa sense bloquejar-se. L�as�ncronia permet rebre i enviar missatges mentre la UI segueix activa.

4\. Renderitzaci� de gr�fics en 3D  
Tipus: Programaci� paral�lela

Ra�: La imatge es pot dividir en blocs petits que es poden renderitzar simult�niament en diferents nuclis, accelerant molt el proc�s.

[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/_qWLA2_7)
