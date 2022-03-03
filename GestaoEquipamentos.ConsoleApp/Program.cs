using System;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static int indiceChamados = 0;
        static string[] somenteNomesEquipamentos = new string[200];
        static string[] somenteNomesChamados = new string[200];
        static void Main(string[] args)
        {
            int i = 0;
            string[] equipamentos = new string[1000];
            string[] chamados = new string[1000];
            chamarInterface(out char opcao, ref equipamentos, ref chamados, ref i);
        }

        static void cadastrarEquipamento(ref string[] equipamento, ref int i)
        {

            while (true)
            {
                Console.WriteLine("Insira o nome do equipamento: ");
                string nome = Console.ReadLine();
                if (nome.Length >= 6)
                {
                    equipamento[i] = nome;
                    somenteNomesEquipamentos[i] = nome;
                    i++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insira um nome com mais do que 5 caracteres!");
                    Console.ResetColor();
                    continue;
                }
                break;
            }


            Console.WriteLine("Insira o preço do equipamento: ");
            equipamento[i] = Console.ReadLine();

            i++;

            Console.WriteLine("Insira o numero de serie do equipamento: ");
            equipamento[i] = Console.ReadLine();

            i++;

            Console.WriteLine("Insira a data de fabricação do equipamento: ");
            equipamento[i] = Console.ReadLine();

            i++;

            Console.WriteLine("Insira o nome do fabricante do equipamento: ");
            equipamento[i] = Console.ReadLine();

            i++;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cadastrado com sucesso!");
            Console.ResetColor();
        }

        static void mostrarEquipamento(string[] equipamento)
        {

            Console.WriteLine("Insira o nome do item que voce deseja visualizar: ");
            string nome = Console.ReadLine();
            int indice = -1;

            for (int i = 0; i < somenteNomesEquipamentos.Length; i++)
            {

                if (somenteNomesEquipamentos[i] == nome)
                {

                    indice = i;

                }
            }

            if (indice == -1)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Equipamento não existe! Tente novamente");
                Console.ResetColor ();

            }
            else
            {

                Console.WriteLine("Nome: " + equipamento[indice]);
                Console.WriteLine("Preço: " + equipamento[indice + 1]);
                Console.WriteLine("Número de série: " + equipamento[indice + 2]);
                Console.WriteLine("Data de fabricação: " + equipamento[indice + 3]);
                Console.WriteLine("Fabricante: " + equipamento[indice + 4]);

            }

        }

        static void editarEquipamento(ref string[] equipamento)
        {
            Console.WriteLine("Insira o nome do equipamento que voce deseja editar: ");
            string equipamento_a_editar = Console.ReadLine();
            int posicao_a_editar = -1;

            for (int i = 0; i < somenteNomesEquipamentos.Length; i++)
            {

                if (somenteNomesEquipamentos[i] == equipamento_a_editar)
                {

                    posicao_a_editar = i;
                    break;

                }
            }

            if (posicao_a_editar == -1)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Equipamento não existe! ");
                Console.ResetColor();

            }
            else
            {

                Console.WriteLine("O que deseja editar(nome/preco/numero de serie/data de fabricacao/fabricante)? ");
                string editarEquipamento = Console.ReadLine();

                switch (editarEquipamento)
                {

                    case "nome":
                        Console.WriteLine("Insira o novo nome para o equipamento: ");
                        string novoNome = Console.ReadLine();
                        equipamento[posicao_a_editar] = novoNome;
                        somenteNomesEquipamentos[posicao_a_editar] = novoNome;
                        break;

                    case "preco":
                        Console.WriteLine("Insira o novo preço para o equipamento: ");
                        equipamento[posicao_a_editar + 1] = Console.ReadLine();
                        break;

                    case "numero de serie":
                        Console.WriteLine("Insira um novo número de série para o equipamento: ");
                        equipamento[posicao_a_editar + 2] = Console.ReadLine();
                        break;

                    case "data de fabricacao":
                        Console.WriteLine("Insira uma nova data de fabricacao para o equipamento: ");
                        equipamento[posicao_a_editar + 3] = Console.ReadLine();
                        break;

                    case "fabricante":
                        Console.WriteLine("Insira um novo fabricante para o equipamento: ");
                        equipamento[posicao_a_editar + 4] = Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;

                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Editado com sucesso!");
                Console.ResetColor();
            }
        }

        static void excluirEquipamento(ref string[] equipamentos, ref string[] chamados)
        {

            Console.WriteLine("Insira o nome do equipamento que voce deseja excluir: ");
            string equipamento_a_excluir = Console.ReadLine();
            int posicao;
            posicao = Array.IndexOf(chamados, equipamento_a_excluir);

            if (posicao != -1)
            {

                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Não é possível excluir, pois está cadastrado em um chamado");
                Console.ResetColor();

            }
            else
            {

                int posicao_a_excluir = -1, j = 0;
                for (int i = 0; i < somenteNomesEquipamentos.Length; i++)
                {

                    if (somenteNomesEquipamentos[i] == equipamento_a_excluir)
                    {

                        posicao_a_excluir = i;
                        break;

                    }
                }

                if (posicao_a_excluir == -1)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Equipamento não encontrado! Tente novamente");
                    Console.ResetColor();

                }
                else
                {

                    string[] equipamentosNaoExclusos = new string[equipamentos.Length - 5];

                    for (int i = 0; i < equipamentos.Length; i++)
                    {

                        if (i != posicao_a_excluir && i != posicao_a_excluir + 1
                            && i != posicao_a_excluir + 2 && i != posicao_a_excluir + 3 && i != posicao_a_excluir + 4)
                        {

                            equipamentosNaoExclusos[j] = equipamentos[i];
                            j++;

                        }

                    }

                    equipamentos = equipamentosNaoExclusos;
                    somenteNomesEquipamentos[posicao_a_excluir] = null;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Equipamento foi excluido");
                    Console.ResetColor();

                }
            }
        }

        static void chamarInterface(out char opcao, ref string[] equipamentos, ref string[] chamados, ref int i)
        {

            do
            {

                Console.WriteLine("->Insira 1 para cadastrar um equipamento\n" +
                "->Insira 2 para visualizar um equipamento\n" +
                "->Insira 3 para editar um equipamento\n" +
                "->Insira 4 para excluir um equipamento\n" +
                "->Insira 5 para ir para chamados\n" +
                "->Insira 6 para sair");
                opcao = Convert.ToChar(Console.ReadLine());

                switch (opcao)
                {

                    case '1':
                        cadastrarEquipamento(ref equipamentos, ref i);
                        break;

                    case '2':
                        mostrarEquipamento(equipamentos);
                        break;

                    case '3':
                        editarEquipamento(ref equipamentos);
                        break;

                    case '4':
                        excluirEquipamento(ref equipamentos, ref chamados);
                        break;

                    case '5':
                        Chamados(ref chamados, ref equipamentos);
                        break;

                    case '6':
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente");
                        break;

                }

                Console.ReadKey();
                Console.Clear();

            } while (opcao == '1' || opcao == '2' || opcao == '3' || opcao == '4' || opcao == '5' || opcao != '6');

        }

        static void Chamados(ref string[] chamados, ref string[] equipamentos)
        {

            while (true)
            {

                char opcao;
                Console.Clear();
                Console.WriteLine("->Insira 1 para criar um chamado\n" +
                    "->Insira 2 para editar um chamado\n" +
                    "->Insira 3 para visualizar um chamado\n" +
                    "->Insira 4 para remover um chamado\n" +
                    "->Insira 5 para voltar ao menu principal");
                opcao = Convert.ToChar(Console.ReadLine());

                if (opcao == '1')
                    criarChamado(ref chamados, ref equipamentos);
                else if (opcao == '2')
                    editarChamado(ref chamados, ref equipamentos);
                else if (opcao == '3')
                    visualizarChamado(ref chamados);
                else if (opcao == '4')
                    excluirChamado(ref chamados, ref equipamentos);
                else if (opcao == '5')
                    break;
                else
                    Console.WriteLine("Opção inválida! Tente novamente");

                Console.ReadKey();
                Console.Clear();
            }

        }

        static void criarChamado(ref string[] chamados, ref string[] equipamentos)
        {

            Console.WriteLine("Insira o titulo do chamado: ");
            string nomeChamado = Console.ReadLine();
            chamados[indiceChamados] = nomeChamado;
            somenteNomesChamados[indiceChamados] = nomeChamado;
            indiceChamados++;

            Console.WriteLine("Insira o descrição do chamado: ");
            chamados[indiceChamados] = Console.ReadLine();
            indiceChamados++;

            while (true)
            {
                Console.WriteLine("Insira o nome do equipamento: ");
                string nomeEquipamento = Console.ReadLine();
                int indice = -1;

                for (int i = 0; i < somenteNomesEquipamentos.Length; i++)
                {

                    if (somenteNomesEquipamentos[i] == nomeEquipamento)
                    {

                        indice = i;

                    }
                }

                if (indice == -1)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Equipamento não existe! Tente novamente");
                    Console.ResetColor();
                    continue;

                }
                else
                {

                    chamados[indiceChamados] = nomeEquipamento;
                    indiceChamados++;
                }
                break;
            }

            Console.WriteLine("Insira a data(insira no formato ano/mes/dia): ");
            chamados[indiceChamados] = Console.ReadLine();
            indiceChamados++;
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Chamado cadastrado com sucesso!");
            Console.ResetColor();
        }

        static void editarChamado(ref string[] chamados, ref string[] equipamentos)
        {

            Console.WriteLine("Insira o titulo do chamado que deseja editar: ");
            string chamado_a_editar = Console.ReadLine();
            int posicao_a_editar = -1;

            for (int i = 0; i < somenteNomesChamados.Length; i++)
            {

                if (somenteNomesChamados[i] == chamado_a_editar)
                {

                    posicao_a_editar = i;

                }
            }

            if (posicao_a_editar == -1)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Chamado não existe!");
                Console.ResetColor();

            }
            else
            {

                Console.WriteLine("O que deseja editar(titulo/descricao/equipamento/data(ano/mes/dia)): ");
                string aEditar = Console.ReadLine();

                switch (aEditar)
                {

                    case "titulo":
                        Console.WriteLine("Insira um novo titulo: ");
                        string nomeChamado = Console.ReadLine();
                        chamados[posicao_a_editar] = nomeChamado;
                        somenteNomesChamados[posicao_a_editar] = nomeChamado;
                        break;

                    case "descricao":
                        Console.WriteLine("Insira uma nova descrição: ");
                        chamados[posicao_a_editar + 1] = Console.ReadLine();
                        break;

                    case "equipamento":
                        while (true)
                        {
                            Console.WriteLine("Insira o novo nome do equipamento: ");
                            string nomeEquipamento = Console.ReadLine();
                            int indice = -1;

                            for (int j = 0; j < somenteNomesEquipamentos.Length; j++)
                            {

                                if (somenteNomesEquipamentos[j] == nomeEquipamento)
                                {

                                    indice = j;

                                }
                            }

                            if (indice == -1)
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Equipamento não existe! Tente novamente");
                                Console.ResetColor();

                            }
                            else
                            {

                                chamados[indiceChamados] = nomeEquipamento;
                                break;
                            }
                        }
                        break;

                    case "data":
                        Console.WriteLine("Insira uma nova data: ");
                        chamados[posicao_a_editar + 3] = Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;

                }
            }
        }

        static void visualizarChamado(ref string[] chamados)
        {

            Console.WriteLine("Insira o titulo do chamado que voce deseja visualizar: ");
            string nome = Console.ReadLine();
            int indice = -1;

            for (int i = 0; i < somenteNomesChamados.Length; i++)
            {

                if (somenteNomesChamados[i] == nome)
                {

                    indice = i;

                }
            }

            if (indice == -1)
            {

                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Chamado não existe! Tente novamente");
                Console.ResetColor();

            }
            else
            {

                Console.WriteLine("Titulo: " + chamados[indice]);
                Console.WriteLine("Descrição: " + chamados[indice + 1]);
                Console.WriteLine("Equipamento: " + chamados[indice + 2]);
                string data_a_converter = chamados[indice + 3];
                DateTime data = Convert.ToDateTime(data_a_converter);
                TimeSpan difference = DateTime.Now - data;
                Console.WriteLine("Tempo: " + difference.Days + " dias");

            }


        }

        static void excluirChamado(ref string[] chamados, ref string[] equipamentos)
        {

            Console.WriteLine("Insira o titulo do chamado que voce deseja excluir: ");
            string chamado_a_excluir = Console.ReadLine();
            int posicao_a_excluir = -1, j = 0;
            string[] chamadosNaoExclusos = new string[chamados.Length];
            for (int i = 0; i < somenteNomesChamados.Length; i++)
            {

                if (somenteNomesChamados[i] == chamado_a_excluir)
                {

                    posicao_a_excluir = i;
                    break;

                }
            }

            if (posicao_a_excluir == -1)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Chamado não existe!");
                Console.ResetColor();

            }
            else
            {

                for (int i = 0; i < chamados.Length; i++)
                {

                    if (i != posicao_a_excluir && i != posicao_a_excluir + 1
                        && i != posicao_a_excluir + 2 && i != posicao_a_excluir + 3)
                    {

                        chamadosNaoExclusos[j] = chamados[i];
                        j++;

                    }
                }

                chamados = chamadosNaoExclusos;
                somenteNomesChamados[posicao_a_excluir] = null;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Excluido com sucesso!");
                Console.ResetColor ();

            }
        }
    }
}
