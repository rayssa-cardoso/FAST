using FFImageLoading.Maui;

namespace fast;

public partial class MainPage : ContentPage
{
	bool EstaNoChao = true;
	bool EstaNoAr = false;
	bool IsDied = false;
	bool IsJumping = false;

	int Velocity = 0;
	int Velocity1 = 0;
	int Velocity2 = 0;
	int Velocity3 = 0;
	int Velocity4 = 0;
	int Velocity5 = 0;
	int JumpTime = 0;
	int TempoNoAr = 0;
	int alturaJanela = 0;
	int larguraJanela = 0;
	int TempoPulando = 0;

	const int Gravity = 5;
	const int TimeBeteweenFrames = 25;
	const int JumpForce = 8;
	const int maxJumpTime = 6;
	const int MaxTempoNoAr = 4;

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
			GerenciaCenarios();
			if (!IsJumping && !EstaNoAr)
			{
				AplicaGravidade();
				player.Desenha();
			}
			else
				AplicaPulo();

			await Task.Delay(TimeBeteweenFrames);
		}
	}

	void AplicaGravidade()
	{
		if (player.GetY() < 0)
			player.MoveY(Gravity);

		else if (player.GetY() >= 0)
		{
			player.SetY(0);
			EstaNoChao = true;
		}
	}

	void AplicaPulo()
	{
		EstaNoChao = false;
		if (IsJumping && TempoPulando >= maxJumpTime)
		{
			IsJumping = false;
			EstaNoAr = true;
			TempoNoAr = 0;
		}
		else if (EstaNoAr && TempoNoAr >= maxJumpTime)
		{
			IsJumping = false;
			EstaNoAr = false;
			TempoPulando = 0;
			TempoNoAr = 0;
		}
		else if (IsJumping && TempoPulando < maxJumpTime)
		{
			player.MoveY(-JumpForce);
			TempoPulando++;
		}
		else if (EstaNoAr)
			TempoNoAr++;
	}

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w, h);
		CalculaVelocity(w);
	}

	void OnGridClicked(object sender, TappedEventArgs e)
	{
		if (EstaNoChao)
			IsJumping = true;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();
	}

	void CalculaVelocity(double w)
	{
		Velocity1 = (int)(w * 0.001);
		Velocity2 = (int)(w * 0.002);
		Velocity3 = (int)(w * 0.003);
		Velocity4 = (int)(w * 0.005);
		Velocity5 = (int)(w * 0.008);
		Velocity = (int)(w * 0.01);
	}

	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach (var a in layerUm.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in layerDois.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in layerTres.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in layerQuatro.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in layerCinco.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in layerChao.Children)
			(a as Image).WidthRequest = w;

		layerUm.WidthRequest = w * 1.5;
		layerDois.WidthRequest = w * 1.5;
		layerTres.WidthRequest = w * 1.5;
		layerQuatro.WidthRequest = w * 1.5;
		layerCinco.WidthRequest = w * 1.5;
		layerChao.WidthRequest = w * 1.5;
	}
	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenario(layerUm);
		GerenciaCenario(layerDois);
		GerenciaCenario(layerTres);
		GerenciaCenario(layerQuatro);
		GerenciaCenario(layerCinco);
		GerenciaCenario(layerChao);
	}

	void MoveCenario()
	{
		layerUm.TranslationX -= Velocity1;
		layerDois.TranslationX -= Velocity2;
		layerTres.TranslationX -= Velocity3;
		layerQuatro.TranslationX -= Velocity4;
		layerCinco.TranslationX -= Velocity5;
		layerChao.TranslationX -= Velocity;
	}

	void GerenciaCenario(HorizontalStackLayout hsl)
	{
		var view = (hsl.Children.First() as Image);
		if (view.WidthRequest + hsl.TranslationX < 0)
		{
			hsl.Children.Remove(view);
			hsl.Children.Add(view);
			hsl.TranslationX = view.TranslationX;
		}
	}
}