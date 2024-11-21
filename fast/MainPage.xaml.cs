using FFImageLoading.Maui;

namespace fast;

public partial class MainPage : ContentPage
{
	double HeightWindow = 0;
 	int Velocity = 0;
	 int Velocity1 = 0;
	 int Velocity2 = 0;
	 int Velocity3 = 0;
	 int Velocity4 = 0;
	 int Gravity = 5;


	 int TimeBeteweenFrames = 25;

	bool IsDied = true;
	 int JumpForce = 35;
	 int maxJumpTime = 5;
	bool IsJumping = false;
	int JumpTime = 0;
	 int minOpening = 100;
	int Score = 0;

	Player player;

	public MainPage()
	{
		InitializeComponent();
		player = new Player(imgveado);
		player.Run();
	}

	async Task Desenha()
	{
		while (!IsDied)
		{
			
			player.Desenha();
			await Task.Delay(TimeBeteweenFrames);
		}
	}

    protected override void OnSizeAllocated(double w, double h)
    {
        base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w,h);
		CalculaVelocity(w);
    }

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();
	}
	
	void CalculaVelocity(double w)
	{
		Velocity1=(int)(w*0.001);
		Velocity2=(int)(w*0.004);
		Velocity3=(int)(w*0.008);
		Velocity = (int)(w * 0.01);
	}

	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach(var a in layerUm.Children)
		(a as Image ).WidthRequest = w;
		foreach(var a in layerDois.Children)
		(a as Image ).WidthRequest = w;
		foreach(var a in layerTres.Children)
		(a as Image ).WidthRequest = w;
		foreach(var a in layerQuatro.Children)
		(a as Image ).WidthRequest = w;
		foreach( var a in layerAsfalto.Children)
		(a as Image ).WidthRequest = w;

		layerUm.WidthRequest=w*1.5;
		layerDois.WidthRequest=w*1.5;
		layerTres.WidthRequest=w*1.5;
		layerQuatro.WidthRequest=w*1.5;
		

	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenario(layerUm);
		GerenciaCenario(layerDois);
		GerenciaCenario(layerTres);
		GerenciaCenario(layerQuatro);
		
	}

	void MoveCenario()
	{
		layerUm.TranslationX -= Velocity1;
		layerDois.TranslationX -= Velocity2;
		layerTres.TranslationX -= Velocity3;
		layerQuatro.TranslationX -= Velocity4;
		layerAsfalto.TranslationX -= Velocity;
	}
	
	void GerenciaCenario(HorizontalStackLayout hsl)
	{
		var view = (hsl.Children.First() as Image);
		if(view.WidthRequest+hsl.TranslationX<0)
		{
			hsl.Children.Remove(view);
			hsl.Children.Add(view);
			hsl.TranslationX = view.TranslationX;
		}
	}
   }
}