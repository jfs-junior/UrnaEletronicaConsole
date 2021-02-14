using System;

namespace urnaeletronica
{
    class urnaeletronica
    {
        private const int totalPrefeitos = 6;
        private const int totalVereadores = 11;

        private static int[]       votoPrefeito =   new int[totalPrefeitos];
        private static int[]       votoVereador =   new int[totalVereadores];

        private static string[]    nomePrefeito =   new string[totalPrefeitos];
        private static string[]    nomeVereador =   new string[totalVereadores];
        static void Main(string[] args)
        {
            //LISTA DE NOMES DE PREFEITOS
            nomePrefeito[0] = "NULO              ";
            nomePrefeito[1] = "Alberto de Nobrega";
            nomePrefeito[2] = "Elis Fernandes    ";
            nomePrefeito[3] = "Manuele Lacerda   ";
            nomePrefeito[4] = "Manuel Pestana    ";
            nomePrefeito[5] = "Hannes Stofell    ";

            //LISTA DE NOME DE VERIADORES
            nomeVereador[0]  = "NULO              ";
            nomeVereador[1]  = "Rui Pimentel 01   ";
            nomeVereador[2]  = "Rui Pimentel 02   ";
            nomeVereador[3]  = "Rui Pimentel 03   ";
            nomeVereador[4]  = "Rui Pimentel 04   ";
            nomeVereador[5]  = "Rui Pimentel 05   ";
            nomeVereador[6]  = "Rui Pimentel 06   ";
            nomeVereador[7]  = "Rui Pimentel 07   ";
            nomeVereador[8]  = "Rui Pimentel 08   ";
            nomeVereador[9]  =  "Rui Pimentel 09   ";
            nomeVereador[10] = "Rui Pimentel 10   ";


            void telaEntrada(){
                Console.Clear();
                Console.WriteLine("***************************************");
                Console.WriteLine("*** APLICATIVO URNA ENETRÔNICA V0.1 ***");
                Console.WriteLine("***************************************");

            }

            void menu() {
                Console.WriteLine("ESCOLHA UMA DAS SEGUINTES OPÇÇÕES ABAIXO: ");
                Console.WriteLine("1- Iniciar Votação / 2- Ver Resultado / 3- Sair");
            }

            int lerInformacoes() {
                int opcao = 0;
                try {
                    Console.Write("Digite uma opção: ");
                    opcao = int.Parse(Console.ReadLine());
                    if(opcao <=0 || opcao > 3) {
                        Console.WriteLine();
                        Console.WriteLine("Opção Inválida, por favor, tente novamente.");
                    }
                } catch (FormatException) {
                    Console.WriteLine();
                    Console.WriteLine("Opção Inválida, por favor, tente novamente.");
                } 
                return opcao;
            }

            void mostrarResultados() {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("QUANTIDADE DE VOTOS PARA PREFEITO:");
                Console.WriteLine();
                for(int i=0; i<votoPrefeito.Length; i++){
                    Console.WriteLine("Nome: " + nomePrefeito[i] + "\t" + "Votos " + votoPrefeito[i]);
                }

                Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("QUANTIDADE DE VOTOS PARA VEREADORES:");
                Console.WriteLine();
                for(int i=0; i<votoVereador.Length; i++){
                    Console.WriteLine("Nome: " + nomeVereador[i] + "\t" + "Votos " + votoVereador[i]);
                }
            }

            void votar() {
                int votoPref = 0;
                int votoVer  = 0;
                telaEntrada();
                Console.WriteLine();
                
                //VOTO PARA PREFEITO
                bool voto1 = true;
                do {
                    
                    bool votoPrefeitoOk = true;
                    do {
                        try{
                            votoPrefeitoOk = true;
                            Console.Write("VOTO PARA PREFEITO: ");
                            votoPref = int.Parse(Console.ReadLine());
                        } catch (FormatException) {
                            Console.WriteLine("Digite um número!");
                            votoPrefeitoOk = false;
                        } 
                    } while(!votoPrefeitoOk);

                    // TRANSFORMA NÚMERO FORA DA RANGE EM VOTO NULO.
                    if(votoPref <= 0 || votoPref >=votoPrefeito.Length) {
                        votoPref = 0;
                    }
                    
                    Console.WriteLine("Você está votando em: " + nomePrefeito[votoPref] );
                    bool confirmPrefeitoOk = true;
                    do { 
                        Console.Write("Está correto? (S/N)");
                        string confirm = Console.ReadLine();
                        if(confirm.ToLower() == "s") {
                            confirmPrefeitoOk = true;
                            voto1 = true;
                            votoPrefeito[votoPref]++;
                        } else if (confirm.ToLower() == "n") {
                            voto1 = false;
                            Console.WriteLine();
                        } else {
                            confirmPrefeitoOk = false;
                        }
                    } while (!confirmPrefeitoOk);
                
                } while (!voto1);

                //VOTO PARA VEREADOR
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------");

                bool voto2 = true;
                do {
                    
                    bool votoVereadorOk = true;
                    do {
                        try{
                            votoVereadorOk = true;
                            Console.Write("VOTO PARA VEREADOR: ");
                            votoVer = int.Parse(Console.ReadLine());
                        } catch (FormatException) {
                            Console.WriteLine("Digite um número!");
                            votoVereadorOk = false;
                        } 
                    } while(!votoVereadorOk);

                    if(votoVer <= 0 || votoVer >=votoVereador.Length) {
                        votoVer = 0;
                    }
                    
                    Console.WriteLine("Você está votando em: " + nomeVereador[votoVer]);
                    bool confirmVereadorOk = true;
                    do { 
                        Console.Write("Está correto? (S/N)");
                        string confirm = Console.ReadLine();
                        if(confirm.ToLower() == "s") {
                            confirmVereadorOk = true;
                            voto2 = true;
                            votoVereador[votoVer]++;
                        } else if (confirm.ToLower() == "n") {
                            voto2 = false;
                            Console.WriteLine();
                        } else {
                            confirmVereadorOk = false;
                        }
                    } while (!confirmVereadorOk);

                } while (!voto2);
                
                Console.WriteLine();
                Console.WriteLine("VOTO COMPUTADO COM SUCESSO, FIM!");
            }

            void executarAcao(int opcao) {
                switch (opcao) {
                    case 1: 
                        votar();
                        break;
                    case 2:
                        mostrarResultados();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Saindo do programa, obrigado!");
                        break;
                }
            }

            //LISTA DE EXECUÇÕES
            int opcao;
            do {
                opcao = 0; 

                telaEntrada();
                Console.WriteLine();
                menu();
                opcao = lerInformacoes();
                
                executarAcao(opcao);
                Console.ReadKey();

            } while(opcao != 3);
        }
    }
}
