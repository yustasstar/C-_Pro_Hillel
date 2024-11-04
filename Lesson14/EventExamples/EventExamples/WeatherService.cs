public class WeatherService(string apiKey, string city)
{
	public delegate void WeatherUpdatedHandler(object sender, WeatherEventArgs e);
	public event WeatherUpdatedHandler? WeatherUpdated;

	private readonly HttpClient _httpClient = new HttpClient();
	private readonly string _apiKey = apiKey;
	private readonly string _city = city;
	private System.Timers.Timer? _timer;

	public void Start(int intervalInSeconds)
	{
		_timer = new System.Timers.Timer(intervalInSeconds * 1000);
		_timer.Elapsed += async (sender, e) => await UpdateWeatherAsync();
		_timer.Start();
		Console.WriteLine("Weather updates started.");
	}

	public void Stop()
	{
		_timer?.Stop();
		Console.WriteLine("Weather updates stopped.");
	}

	private async Task UpdateWeatherAsync()
	{
		string url = $"http://api.openweathermap.org/data/2.5/weather?q={_city}&appid={_apiKey}&units=metric";
		try
		{
			HttpResponseMessage response = await _httpClient.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				string data = await response.Content.ReadAsStringAsync();
				OnWeatherUpdated(new WeatherEventArgs(data));
			}
			else
			{
				Console.WriteLine("Error retrieving weather data.");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Exception: {ex.Message}");
		}
	}

	protected virtual void OnWeatherUpdated(WeatherEventArgs e)
	{
		WeatherUpdated?.Invoke(this, e);
	}
}

public class WeatherEventArgs : EventArgs
{
	public string WeatherData { get; }

	public WeatherEventArgs(string data)
	{
		WeatherData = data;
	}
}

public class WeatherDisplay : IDisposable
{
	private readonly string _name;
	private readonly WeatherService _service;
	private bool _disposed = false;

	public WeatherDisplay(string name, WeatherService service)
	{
		_name = name;
		_service = service;
		_service.WeatherUpdated += OnWeatherUpdated;
	}

	private void OnWeatherUpdated(object sender, WeatherEventArgs e)
	{
		Console.WriteLine($"{_name} received update: {e.WeatherData}");
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_service.WeatherUpdated -= OnWeatherUpdated;
			_disposed = true;
			Console.WriteLine($"{_name} unsubscribed from weather updates.");
		}
	}
}

public class WeatherForecast
{
	public static async Task Start()
	{
		string apiKey = "735d1d2f596580fcdbcba97dc3a2fd50"; // Вставьте свой API-ключ OpenWeatherMap
		string city = "London";          // Выберите город

		var weatherService = new WeatherService(apiKey, city);

		// Создаем подписчиков
		using (var display1 = new WeatherDisplay("Display 1", weatherService))
		using (var display2 = new WeatherDisplay("Display 2", weatherService))
		{
			weatherService.Start(10); // Запускаем обновления погоды каждые 10 секунд

			// Даем поработать обновлениям 30 секунд, потом прекращаем
			await Task.Delay(30000);
		}

		weatherService.Stop();
	}
}
