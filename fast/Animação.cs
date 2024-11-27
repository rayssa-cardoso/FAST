using FFImageLoading.Maui;

namespace fast;

public  class Animacao
{
    protected List<string> Animacao1 = new List<string>();
    protected List<string> Animacao2 = new List<string>();
    protected bool Loop = true;
    protected int AnimacaoAtiva = 1;
    bool Parado = true;
    int FrameAtual = 1;
    protected CachedImageView ImageView;

    public Animacao(CachedImageView pp)
    {
        ImageView = pp;
    }

    public void Stop()
    {
        Parado = true;
    }

    public void Play()
    {
        Parado = false;
    }

    public void SetAnimacaoAtiva(int pp)
    {
        AnimacaoAtiva = pp;
    }

    public void Desenha()
    {
        if (Parado)
        {
            return;
        }
        string NomeArquivo = "";
        int TamanhoAnimacao = 0;

        if (AnimacaoAtiva == 1)
        {
            NomeArquivo = Animacao1[FrameAtual];
            TamanhoAnimacao = Animacao1.Count;
        }
        else if (AnimacaoAtiva == 2)
        {
            NomeArquivo = Animacao2[FrameAtual];
            TamanhoAnimacao = Animacao2.Count;
        }
        
        ImageView.Source = ImageSource.FromFile(NomeArquivo);
        FrameAtual++;

        if (FrameAtual >= TamanhoAnimacao)
        {
            if (Loop)
            {
                FrameAtual = 0;
            }
            else
            {
                Parado = true;
                QuandoParar();
            }
        }
    }

    public virtual void QuandoParar()
    {
    }
}