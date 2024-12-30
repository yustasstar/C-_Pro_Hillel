using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyCustomControl
{
	/// <summary>
	/// Interaction logic for ColorPicker.xaml
	/// </summary>
	public partial class ColorPicker : UserControl
	{
		public ColorPicker()
		{
			InitializeComponent();
		}

		// Определение статических полей - свойств зависимости ...Property
		public static DependencyProperty ColorProperty;

		// Эти свойства хранят собственные значения, представляющие каждый цвет самостоятельно
		public static DependencyProperty RedProperty;
		public static DependencyProperty GreenProperty;
		public static DependencyProperty BlueProperty;

		// Статический конструктор необходим для регистрации свойств зависимости
		static ColorPicker()
		{
			ColorProperty = DependencyProperty.Register(
				"Color", typeof(Color), typeof(ColorPicker),
				new FrameworkPropertyMetadata(Colors.Black,
					new PropertyChangedCallback(OnColorChanged)));

			RedProperty = DependencyProperty.Register(
				"Red", typeof(byte), typeof(ColorPicker),
				new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
			GreenProperty = DependencyProperty.Register(
				"Green", typeof(byte), typeof(ColorPicker),
				new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
			BlueProperty = DependencyProperty.Register(
				"Blue", typeof(byte), typeof(ColorPicker),
				new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

			// Регистрация события изменения цвета
			ColorChangedEvent = EventManager.RegisterRoutedEvent(
				"ColorChanged",                                 // Имя события
				RoutingStrategy.Bubble,                         // Стратегия маршрутизации
				typeof(RoutedPropertyChangedEventArgs<Color>),  // Делегат маршрутизируемого события, передающий старое и новое значени после изменения свойства
				typeof(ColorPicker));                           // Класс владелец

		}

		// Объявление стандартных свойств, являющихся оболочками для свойств зависимости
		public Color Color
		{
			get { return (Color)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}
		public byte Red
		{
			get { return (byte)GetValue(RedProperty); }
			set { SetValue(RedProperty, value); }
		}
		public byte Green
		{
			get { return (byte)GetValue(GreenProperty); }
			set { SetValue(GreenProperty, value); }
		}
		public byte Blue
		{
			get { return (byte)GetValue(BlueProperty); }
			set { SetValue(BlueProperty, value); }
		}

		// Функция обратного вызова обеспечивающая синхронное изменение 
		// составляющих цвета (Red, Green и Blue) при изменении свойства Color
		private static void OnColorRGBChanged(DependencyObject sender,
			DependencyPropertyChangedEventArgs e)
		{
			ColorPicker picker = (ColorPicker)sender;
			Color color = picker.Color;
			if (e.Property == RedProperty)
				color.R = (byte)e.NewValue;
			else if (e.Property == GreenProperty)
				color.G = (byte)e.NewValue;
			else if (e.Property == BlueProperty)
				color.B = (byte)e.NewValue;

			picker.Color = color;
		}

		// Функция обратного вызова для синхронного изменения свойства Color,
		// при изменении одной из составляющих цвета (Red, Green и Blue)
		private static void OnColorChanged(DependencyObject sender,
			DependencyPropertyChangedEventArgs e)
		{
			ColorPicker picker = (ColorPicker)sender;
			Color oldColor = picker.Color;          // *************************** //
			Color newColor = (Color)e.NewValue;

			picker.Red = newColor.R;
			picker.Green = newColor.G;
			picker.Blue = newColor.B;

			//
			RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldColor, newColor);
			args.RoutedEvent = ColorPicker.ColorChangedEvent;
			picker.RaiseEvent(args);
		}

		//
		// Определение маршрутизируемого события, возбуждаемого при изменении цвета
		//
		public static readonly RoutedEvent ColorChangedEvent;

		// Оболочка для события изменения цвета. Она позволит добавлять и удалять слушателей события
		public event RoutedPropertyChangedEventHandler<Color> ColorChanged
		{
			add { AddHandler(ColorChangedEvent, value); }
			remove { RemoveHandler(ColorChangedEvent, value); }
		}
	}
}
