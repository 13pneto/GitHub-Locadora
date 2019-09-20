using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasConsole.Utils
{
    class Mensagens
    {
        public void MensagemSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----> " + mensagem + " <-----");
            Console.ResetColor();
        }

        public void MensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("-----> " + mensagem + " <-----");
            Console.ResetColor();
        }

        public void MensagemAtencao(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----> " + mensagem + " <-----");
            Console.ResetColor();
        }

        public void MensagemTitulo(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----->" + mensagem + "----->");
            Console.ResetColor();
        }



    }
}
