using FFImageLoading.Maui;

namespace fast;
public delegate void Callback();
public class Player : Animacao
{
    public Player (Image a) : base (a)
    {
        for (int i = 1; i <= 6; i++)
        {    
            Animacao1.Add ($"veadoframe{i.ToString("D2")}.png");
        } 
        for (int i = 1; i <= ; i++)
       {     
              Animacao2.Add ($"{i.ToString("D2")}.png");
              SetAnimacaoAtiva(1);
       }
    }
    public void Die()
    {
        loop = false;
        SetAnimacaoAtiva(2);
    }
    public void Run()
    {
        loop=true;
        SetAnimacaoAtiva(1);
        Play();
    }
}