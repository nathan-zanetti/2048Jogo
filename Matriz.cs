using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Jogo
{
    /*Classe matriz*/
    class Matriz 
    {
        public int[,] matriz = new int[4, 4]; // Matriz onde serão inseridos os números
        public int score;
        public bool perdeu;
        public Matriz()
        {
            score = 0;
            GerarMatriz();

        }
        
        public void setScore(int soma)
        {
            score += soma;
        }
          public int[,] GetMatriz() 
        {
            return matriz;
        }

        public void SetMatriz(int [] posição, int numero)
        {
            int linha = posição[0];
            int coluna = posição[1];
            matriz[linha,coluna] = numero; // Insere o número na matriz
        }

        public void SetMatrizToda(int[,] jogo)
        {
            matriz = jogo;
        }
        /*Gera a matriz inicial, onde todas as casas são 0*/
        private void GerarMatriz()
        {
            for (int ilinha = 0; ilinha < 4; ilinha++)
            {
                for (int icoluna = 0; icoluna < 4; icoluna++)
                {
                    matriz[ilinha, icoluna] = 0;
                }
                
            }

        }

        public void ImprimeMatriz()
        {
            Console.WriteLine("Score:  " + score);
            Console.Clear();
            Console.WriteLine("Score:  " + score);
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    {
                        Console.Write(string.Format("{0,6}", matriz[i, j]));
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        /*Define de forma aleatória em qual posição será inserido o novo número
        Entradas:
        Saídas: vetor "posição" do tipo int
                    [0] - linha
                    [1] - coluna
        */
        private int[] DefinirPosição()
        {
            int[] posição = new int[2]; // Vetor para guardar a posição
            Random linha = new Random(); 
            Random coluna = new Random(); 
            int rlinha = linha.Next(4); // Geração de linha aleatória
            int rcoluna = coluna.Next(4); // Gração de coluna aleatória
            posição[0] = rlinha; // Insere a linha no vetor posição
            posição[1] = rcoluna; // Insere a coluna no vetor 

            while (!VerificarPosição(posição)) // Enquanto não encontrar uma posição disponível
            {
                 rlinha = linha.Next(4); // Gera outra linha
                 rcoluna = coluna.Next(4); // Gera outra coluna
                posição[0] = rlinha;
                posição[1] = rcoluna;
                
            } // Assim que encontrar uma posição válida
            posição[0] = rlinha; // Guarda
            posição[1] = rcoluna; // Guarda
           return posição; // Retorna posição em que será inserido o novo número
        }

        /*Verifica se essa posição específica da matriz está disponível para inserção de novos números
        Entradas: vetor "posição" do tipo int
                        [0] - linha
                        [1] - coluna 
        Saída: true: posição disponível para inserção
               false: posição já ocupada por outro número
        */
        private bool VerificarPosição(int [] posição)
        {
            if(matriz[posição[0],posição[1]] == 0)
            {
                return true;
            }
            return false;
        }


        /* Verifica se há posições disponíveis para inserção de novos números
        Entradas:
        Saída: "disponível" do tipo boolean
                true: existem posições disponíveis
                false: não há nenhuma posição disponível
        */
        private bool PosiçãoDisponivel()
        {
            bool disponivel=false;
            for (int ilinha = 0; ilinha < 4; ilinha++) // Percorre a matriz
            {
                for (int icoluna = 0; icoluna < 4; icoluna++)
                {
                    if(matriz[ilinha,icoluna] ==0) // Se em alguma posição existir um 0
                    {
                        disponivel = true; // Há posições disponíveis
                    }    
                }
            }
            if (disponivel == false)
            {
                perdeu = true;
            }
            return disponivel;
        }

        /*Método para inserir no tabuleiro os novos números
        Entradas: vetor "posição" do tipo int
                        [0] - linha
                        [1] - coluna
        */
        private void DropaNumero(int[] posição)
        {
            SetMatriz(posição, 2); // Insere na matriz, de acordo com a posição, o número 2
        }

        public void UpdateMatriz()
        {
            if (!PosiçãoDisponivel())
            {
                Console.WriteLine("Perdeu");
                return;
            }
            DropaNumero(DefinirPosição());
        }
    }
}
