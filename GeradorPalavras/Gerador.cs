using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GeradorPalavras
{
    class Gerador
    {
        public ObservableCollection<string> Palavras = new ObservableCollection<string>();
        public Definicao Definicao { get; set; }

        public void Executar(Definicao definicao, int maxSize=6)
        {
            //inicializa a palavra inicial com o não terminal inicial
            var palavra = new List<string> { definicao.Inicio };
            Definicao = definicao;
            Gerar(palavra,maxSize);
        }
        public void Gerar(List<string> palavra, int maxSize)
        {
            
            var palavras_geradas = new List<string>();
            
            string naoTerminal = "";
            //Define se a derivação vai ser realizada do lado esquerdo ou direito
            bool direcaoDireita=false;
            
            //O primeiro item da palavra é um não terminal?
            if (Definicao.NaoTerminais.Any(x => x == palavra.First()))
            {
                //pega o não terminal (primeiro item)
                naoTerminal = palavra.First();
               //remove o não terminal da palavra
                palavra.RemoveAt(0);
                //define que a direção da derivação é pela esquerda
                direcaoDireita = false;
                
            }
            //O último item da palavra é um não terminal?
            else if (Definicao.NaoTerminais.Any(x => x == palavra.Last()))
            {
                //pega o não terminal (último item)
                naoTerminal = palavra.Last();
                //remove o não terminal da palavra
                palavra.RemoveAt(palavra.Count - 1);
                //define que a direção da derivação é pela direita
                direcaoDireita = true;
            }
            //não tem mais não terminais (terminou a derivação)
            else
            {
                //transforma palavra como texto
                string strPalavra = string.Join("", palavra);
                //Coloca na lista de palavras
                Palavras.Add(strPalavra);
                //escreve no console
                System.Diagnostics.Debug.WriteLine(strPalavra);
                return;
            }

            //pega todas as regras que partem do não terminal selecionado
            foreach (var regra in Definicao.Regras.Where(x => x.De == naoTerminal))
            {
                //instancia nova palavra
                List<string> p= new List<string>();
                if(direcaoDireita)
                {
                    //copia a palavra anterior para a nova
                    palavra.ForEach(x => p.Add(x));
                    //troca o não terminal (DE) selecionado pelo resultado selecionado (PARA)
                    regra.Para.ForEach(x => p.Add(x));
                    
                }
                else
                {
                    //troca o não terminal (DE) selecionado pelo resultado selecionado (PARA)
                    regra.Para.ForEach(x => p.Add(x));
                    //copia a palavra anterior para a nova
                    palavra.ForEach(x => p.Add(x));
                    
                }
                //se a palavra nova tiver no máximo o tamanho definido
                if (p.Count(x => Definicao.Terminais.Any(y => y == x)) <= maxSize)
                {
                    //Faz a derivação a partir da nova palavra
                    Gerar(p,maxSize);
                }
                
            }
        }
    }
}
