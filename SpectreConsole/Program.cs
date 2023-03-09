using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectreConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExemplosSimples();
            PulaDuasLinhas();

            ExemplosPaineis();
            PulaDuasLinhas();

            ////descomentar
            //ExemplosConfirmacao();
            //PulaDuasLinhas();

            ////descomentar
            //ExemploEscolhaUmItemDaLista();
            //PulaDuasLinhas();

            ExemploEscolhaVariosItemDaLista();
            PulaDuasLinhas();

            Console.ReadKey();
        }

        private static void PulaDuasLinhas()
        {
            AnsiConsole.Markup("\n\n");
        }

        private static void PulaLinha()
        {
            AnsiConsole.Markup("\n");
        }

        private static void ExemplosSimples()
        {

            AnsiConsole.Markup("Marcação com " +
                "[bold yellow]Spectre.Console[/]!\n");

            AnsiConsole.Markup("Usando estilos, como " +
                "[underline]underline[/] e [bold]bold[/] é muito facil!\n");

            AnsiConsole.Markup("Claro que você pode " +
                "[underline red]combinando estilos e cores[/] tambem!\n");

            AnsiConsole.Markup("Voce tambe pode usra links, por exemplo, " +
                "clique aqui [link blue] https://www.linkedin.com/in/carlos-alberto-martins-4638128[/]\n");

        }

        private static void ExemplosPaineis()
        {
            var painel = new Panel($"Aqui você pode escrever alguma instruções para o app\n Que vão dentro do Painel\n Com algumas configurações");

            painel.Header("Instruções", Justify.Center); //centralizado
            painel.Padding = new Padding(2, 2, 2, 2);
            painel.Expand = true;
            painel.Border = BoxBorder.Double;
            painel.BorderColor(Color.Blue);
            AnsiConsole.Write(painel);
        }

        private static void ExemplosConfirmacao()
        {
            if (AnsiConsole.Confirm("Tem certeza que quer prosseguir?"))
            {
                AnsiConsole.MarkupLine("\n[green] Muito bem então, " +
                    "vamos prosseguir[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("\n[red] Saindo ...[/]");
            }

            PulaLinha();

            var nome = AnsiConsole.Ask<string>("Qual seu [green]nome[/]");

            AnsiConsole.MarkupLine($"Seu nome é [blue]{nome}[/]");
        }

        private static void ExemploEscolhaUmItemDaLista()
        {
            var frutas = new[] { "Maça", "Banana", "Cereja", "Melancia", "Tomate", "Ameixa", "Limão" };
            var favorita = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Escolha sua [green]fruta[/] favorita:")
                .MoreChoicesText("[grey](Mova para cima ou parta baixo para revelar mais opções de frutas, selecione com a tecla TAB)[/]")
                .AddChoices(frutas)
                );

            AnsiConsole.MarkupLine($"Sua escolha foi: [yellow]{0}[/]", favorita);

            Console.WriteLine(favorita);
        }

        private static void ExemploEscolhaVariosItemDaLista()
        {
            var frutas = new[] { "Maça", "Ameixa", "Limão" };
            var tipoBananas = new[] { "Banana - Nanica",
                                        "Banana - Prata",
                                        "Banana - da - Terra",
                                        "Banana - Maçã",
                                        "Banana - Ouro" };


            var favoritas = AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                .PageSize(10)
                .Title("Quais suas [green]frutas[/] favoritas:")
                .MoreChoicesText("[grey](Mova para cima ou parta baixo para revelar mais opções de frutas, selecione com a tecla TAB)[/]")
                .InstructionsText("[grey](Pressione TAB[blue][/] para ligar/desligar a seleção[green][/] para aceitar)[/]")
                .AddChoiceGroup("Bananas", tipoBananas)
                .AddChoices(frutas)
                );

            //ordena
            favoritas.Sort();

            AnsiConsole.MarkupLine($"Sua(s) escolha(s):");
            foreach (var escolha in favoritas)
                AnsiConsole.MarkupLine($"[yellow]{escolha}[/]");
            
        }
    }
}
