using FFImageLoading.Maui;

namespace fast;
public delegate void Callback();
public class Player : Animacao
{
    public Player(CachedImageView uga) : base(uga)
    {
        for (int i = 1; i <= 8; i++)
            Animacao1.Add($"veado{i.ToString("D2")}.png");
        for (int i = 1; i <= 7; i++)
            Animacao2.Add($"explosao{i.ToString("D2")}.png");
        SetAnimacaoAtiva(1);
    }
    public void Die()
    {
        Loop = false;
        SetAnimacaoAtiva(2);
    }
    public void Run()
    {
        Loop = true;
        SetAnimacaoAtiva(1);
        Play();
    }
    public void MoveY(int s)
    {
        ImageView.TranslationY += s;
    }
    public double GetY()
    {
        return ImageView.TranslationY;
    }

    public void SetY(double a)
    {
        ImageView.TranslationY = a;
    }
}