using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Jogo
{
    class Move
    {
        ConsoleKeyInfo cki; // Variável para receber a tecla selecionada pelo usuário

        public Move()
        {
        }

        public Matriz Movimento(Matriz tabuleiro)
        {
            Matriz clone = tabuleiro; // Cria um clone para não alterar diretamente a matriz principal
            Console.WriteLine("w = cima    s = baixo    a = esquerda d = direita"); // Pede ao usuário que insira um movimento
            cki = Console.ReadKey(); // Lê a escolha do usuário
            string direção = cki.Key.ToString(); // Converte escolha em string para facilitar o uso
            switch (direção) 
            {
                case "W":
                    tabuleiro = Cima(clone);
                    break;
                case "S":
                    tabuleiro = Baixo(clone);
                    break;
                case "A":
                    tabuleiro = Esquerda(clone);
                    break;
                case "D":
                   tabuleiro = Direita(clone);
                    break;
            }
            return tabuleiro;
        }

        /*Responsável por modificar o tabuleiro movimentando as peças para a direita
        Entradas: "clone" do tipo Matriz
        Saídas:
        */
        public Matriz Direita(Matriz clone)
        {
            int atual;
            int proximo;
            int depois;
            int somatorio;
            for(int lin=0; lin<4;lin++) // Percorre linha a linha da matriz, começando da 0
            {
                //Console.WriteLine("linha: " + lin);
                for(int col = 0; col < 4; col++) // Percorre todas as colunas da matriz, começando da 0
                {
                    //Console.WriteLine("coluna: " + col);
                    atual = clone.matriz[lin,col];
                    if (col < 3) // Se não for o último item
                    {
                        proximo = clone.matriz[lin, col + 1]; // proximo recebe o valor armazenado na proxima posição
                        if (atual == proximo) // Se atual e proximo forem iguais
                        {
                            if (col < 2)
                            {
                                depois = clone.matriz[lin, col + 2];
                                if (depois == 0) // Se item depois do proximo for zero
                                {
                                    clone.matriz[lin, col + 2] = proximo + atual; // posição do depois recebe proximo+atual
                                    somatorio = clone.matriz[lin, col + 2];
                                    clone.setScore(somatorio);
                                    clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                                    clone.matriz[lin, col + 1] = 0; // posição do proximo recebe 0
                                    col+=2;
                                }
                                else if (depois != 0 && proximo == atual)
                                {
                                    clone.matriz[lin, col + 1] = proximo + atual; // posição do proximo recebe proximo+atual
                                    somatorio = clone.matriz[lin, col + 1];
                                    clone.setScore(somatorio);
                                    clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                                    col++;
                                }
                            }
                            else if (col >= 2)
                            {
                                clone.matriz[lin, col + 1] = proximo + atual; // posição do proximo recebe proximo+atual
                                somatorio = clone.matriz[lin, col + 1];
                                clone.setScore(somatorio);
                                clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                            }
                        }
                        else if (proximo == 0)
                        {
                            clone.matriz[lin, col + 1] = atual;
                            clone.matriz[lin, col] = 0;
                        }
                     
                    }
                }
            }
            return clone;
        }

        public Matriz Esquerda(Matriz clone)
        {
            int atual;
            int proximo;
            int depois;
            int somatorio;
            for (int lin = 0; lin < 4; lin++) // Percorre linha a linha da matriz, começando da 0
            {
                //Console.WriteLine("linha: " + lin);
                for (int col = 3; col >=0; col--) // Percorre todas as colunas da matriz, começando da 3
                {
                    //Console.WriteLine("coluna: " + col);
                    atual = clone.matriz[lin, col];
                    if (col > 0) // Se não for o último item
                    {
                        proximo = clone.matriz[lin, col - 1]; // proximo recebe o valor armazenado na proxima posição
                        if (atual == proximo) // Se atual e proximo forem iguais
                        {
                            if (col > 1)
                            {
                                depois = clone.matriz[lin, col - 2];
                                if (depois == 0) // Se item depois do proximo for zero
                                {
                                    clone.matriz[lin, col - 2] = proximo + atual; // posição do depois recebe proximo+atual
                                    somatorio = clone.matriz[lin, col - 2];
                                    clone.setScore(somatorio);
                                    clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                                    clone.matriz[lin, col - 1] = 0; // posição do proximo recebe 0
                                    col -= 2;
                                }
                                else if (depois != 0 && proximo == atual)
                                {
                                    clone.matriz[lin, col - 1] = proximo + atual; // posição do proximo recebe proximo+atual
                                    somatorio = clone.matriz[lin, col - 1];
                                    clone.setScore(somatorio);
                                    clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                                    col--;
                                }
                            }
                            else if (col <= 1)
                            {
                                clone.matriz[lin, col - 1] = proximo + atual; // posição do proximo recebe proximo+atual
                                somatorio = clone.matriz[lin, col - 1];
                                clone.setScore(somatorio);
                                clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                            }
                        }
                        else if (proximo == 0)
                        {
                            clone.matriz[lin, col - 1] = atual;
                            clone.matriz[lin, col] = 0;
                        }

                    }
                }
            }
            return clone;
        }

        public Matriz Cima(Matriz clone)
        {
            int atual;
            int proximo;
            int depois;
            int somatorio;
            for (int col = 0; col <= 3; col++) // Percorre todas as colunas da matriz, começando da 0
            {
                //Console.WriteLine("linha: " + lin);
                for (int lin = 3; lin >=0; lin--) // Percorre todas as colunas da matriz, começando da 0
                {
                    //Console.WriteLine("coluna: " + col);
                    atual = clone.matriz[lin, col];
                    if (lin > 0) // Se não for o último item
                    {
                        proximo = clone.matriz[lin -1 , col]; // proximo recebe o valor armazenado na proxima posição
                        if (atual == proximo) // Se atual e proximo forem iguais
                        {
                            if (lin > 1)
                            {
                                depois = clone.matriz[lin - 2, col];
                                if (depois == 0) // Se item depois do proximo for zero
                                {
                                    clone.matriz[lin - 2, col ] = proximo + atual; // posição do depois recebe proximo+atual
                                    somatorio = clone.matriz[lin - 2, col];
                                    clone.setScore(somatorio);
                                    clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                                    clone.matriz[lin-1, col] = 0; // posição do proximo recebe 0
                                    lin -= 2;
                                }
                                else if (depois != 0 && proximo == atual)
                                {
                                    clone.matriz[lin-1, col ] = proximo + atual; // posição do proximo recebe proximo+atual
                                    somatorio = clone.matriz[lin-1, col ];
                                    clone.setScore(somatorio);
                                    clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                                    lin--;
                                }
                            }
                            else if (lin <= 1)
                            {
                                clone.matriz[lin-1, col ] = proximo + atual; // posição do proximo recebe proximo+atual
                                somatorio = clone.matriz[lin-1, col];
                                clone.setScore(somatorio);
                                clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                            }
                        }
                        else if (proximo == 0)
                        {
                            clone.matriz[lin-1, col] = atual;
                            clone.matriz[lin, col] = 0;
                        }

                    }
                }
            }
            return clone;
        }

        public Matriz Baixo(Matriz clone)
        {
            int atual;
            int proximo;
            int depois;
            int somatorio;
            for (int col = 0; col <4; col++) // Percorre todas as colunas da matriz, começando da 0
            {
                //Console.WriteLine("linha: " + lin);
                for (int lin = 0; lin <4; lin++) // Percorre todas as colunas da matriz, começando da 0
                {
                    //Console.WriteLine("coluna: " + col);
                    atual = clone.matriz[lin, col];
                    if (lin <3) // Se não for o último item
                    {
                        proximo = clone.matriz[lin + 1, col]; // proximo recebe o valor armazenado na proxima posição
                        if (atual == proximo) // Se atual e proximo forem iguais
                        {
                            if (lin < 2)
                            {
                                depois = clone.matriz[lin + 2, col];
                                if (depois == 0) // Se item depois do proximo for zero
                                {
                                    clone.matriz[lin + 2, col] = proximo + atual; // posição do depois recebe proximo+atual
                                    somatorio = clone.matriz[lin + 2, col];
                                    clone.setScore(somatorio);
                                    clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                                    clone.matriz[lin + 1, col] = 0; // posição do proximo recebe 0
                                    lin += 2;
                                }
                                else if (depois != 0 && proximo == atual)
                                {
                                    clone.matriz[lin + 1, col] = proximo + atual; // posição do proximo recebe proximo+atual
                                    somatorio = clone.matriz[lin + 1, col];
                                    clone.setScore(somatorio);
                                    clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                                    lin++;
                                }
                            }
                            else if (lin >=2)
                            {
                                clone.matriz[lin + 1, col] = proximo + atual; // posição do proximo recebe proximo+atual
                                somatorio = clone.matriz[lin + 1, col];
                                clone.setScore(somatorio);
                                clone.matriz[lin, col] = 0; // posição do atual recebe 0 
                            }
                        }
                        else if (proximo == 0)
                        {
                            clone.matriz[lin + 1, col] = atual;
                            clone.matriz[lin, col] = 0;
                        }

                    }
                }
            }
            return clone;
        }
    }
}
