using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Jogo
{
    class Program
    {
        static void Main(string[] args)
        {
            Matriz jogo = new Matriz();
            
            while (jogo.perdeu==false)
            {
                Update(jogo);
            }

            if (jogo.perdeu == true)

            {
                Console.WriteLine("Você perdeu!");
            }
            
            

        }

        public static void Update(Matriz jogo)
        {
            jogo.UpdateMatriz();
            jogo.ImprimeMatriz();
            Move movimentação = new Move();
            Matriz nova = movimentação.Movimento(jogo);
            int[,] novaMatriz = nova.matriz;
            jogo.SetMatrizToda(novaMatriz);
            jogo.ImprimeMatriz();
          
        }
    }
    

}

