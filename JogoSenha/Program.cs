using System;

namespace JogoSenha
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n================ JOGO DA SENHA ======================\n\n");
            Console.WriteLine("Uma senha aleatória foi gerada.");
            Console.WriteLine("Ela possui 4 dígitos, sendo que nenhum dos dígitos se repete.");
            Console.WriteLine("Por exemplo: 1234, 5298 ou 0961.");
            Console.WriteLine("\nVocê terá 6 tentativas de acertar a senha.");
            Console.WriteLine("B = Número certo no lugar certo.");
            Console.WriteLine("D = Número certo no lugar errado.");
            Console.WriteLine("\nEXEMPLO ");
            Console.WriteLine("Senha: 1234");
            Console.WriteLine("Tentativa: 3284 ");
            Console.WriteLine("B B D");
            Console.WriteLine("=======================================================");


            // GERAR SENHA ALEATÓRIO
            Random numAleatorio = new Random();

            int[] senha = new int[4];

            senha[0] = numAleatorio.Next(0, 9);
            int aux = numAleatorio.Next(0, 9);
            while (senha[0] == aux)
            {
                aux = numAleatorio.Next(0, 9);
            }
            senha[1] = aux;
            aux = numAleatorio.Next(0, 9);
            while (senha[0] == aux || senha[1]==aux)
            {
                aux = numAleatorio.Next(0, 9);
            }
            senha[2] = aux;
            aux = numAleatorio.Next(0, 9);
            while (senha[0] == aux || senha[1] == aux || senha[2]==aux)
            {
                aux = numAleatorio.Next(0, 9);
            }
            senha[3] = aux;

           
            // SEIS TENTATIVAS DE ACERTAR A SENHA CORRETA
            for(int chance =1; chance<7; chance++)
            {
                
                // PEDIR AO USUÁRIO PARA DIGITAR SUA TENTATIVA DE ADIVINHAR A SENHA CORRETA
                Console.Write("\n{0}ª tentativa: ", chance);
                string tentativa = Console.ReadLine();

                int[] verificaSenha = new int[4];
                aux = 0;
                foreach (char c in tentativa)
                {
                    verificaSenha[aux] = Int32.Parse(c.ToString());
                    aux += 1;
                }


                // VERIFICA SE O USUÁRIO ACERTOU A SENHA CORRETA
                if(senha[0]==verificaSenha[0] && senha[1] == verificaSenha[1]
                    && senha[2] == verificaSenha[2] && senha[3] == verificaSenha[3])
                {
                    Console.WriteLine("\n------------------------");
                    Console.WriteLine("PARABÉNS! VOCÊ ACERTOU!!");
                    Console.WriteLine("------------------------");
                    break;
                }

                // VERIFICA SE TEM NÚMERO CORRETO NA POSIÇÃO CORRETA
                for (int i = 0; i < 4; i++)
                {
                    if (senha[i] == verificaSenha[i])
                    {
                        Console.Write("B ");
                    }
                }

                // VERIFICA DE TEM NÚMERO CORRETO, PORÉM NA POSIÇÃO ERRADA
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i != j)
                        {
                            if (senha[i] == verificaSenha[j])
                            {
                                Console.Write("D ");
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\n\nA senha era: {0}{1}{2}{3}", senha[0], senha[1], senha[2], senha[3]);

        }
    }
}
