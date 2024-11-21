using FFImageLoading.Maui;

namespace fast;
public delegate void Callback();
public class Player : Animacao
{
    public Player (CachedImageView uga) : base (uga)
    {
        for (int i = 1; i <= 7; i++)
        {    
            Animacao1.Add ($"veadoframe{i.ToString("D2")}.png");
        } 
        for (int i = 1; i <= 7; i++)
       {     
              Animacao2.Add ($"explosao{i.ToString("D2")}.png");
       }
              SetAnimacaoAtiva(1);
    }
    public void Die()
    {
        Loop = false;
        
    }
    public void Run()
    {
        Loop=true;
        SetAnimacaoAtiva(1);
        Play();
    }
    public void MoveY (int s)
     {
        ImageView.TranslationY += s;
     }
     public double GetY()
     {
        return ImageView.TranslationY;
     }

     public void SetY(double a)
     {
        ImageView.TranslationY=a;
     }
}