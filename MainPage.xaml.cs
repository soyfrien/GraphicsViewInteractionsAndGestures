namespace GraphicsViewInteractionsAndGestures;

public partial class MainPage : ContentPage
{
	private bool _isInteracting;
	private PointF _lastPoint;

	public MainPage()
	{
		InitializeComponent();

		/* Workaround for Windows: 
		 * Uncomment to set up gesture recognizers in code, while not having any in XAML.
		 * This will allow the functionality on Windows without interfering with Android. 
#if WINDOWS
		PointerGestureRecognizer pointerGestureRecognizer = new();
		pointerGestureRecognizer.PointerMoved += GView_PointerMoved;
		GView.GestureRecognizers.Add(pointerGestureRecognizer);

		TapGestureRecognizer tapGestureRecognizer = new();
		tapGestureRecognizer.Tapped += GView_Tapped;
		GView.GestureRecognizers.Add(tapGestureRecognizer);
#endif
		*/
	}


	private void StartInteraction(object sender, TouchEventArgs e)
	{
		_isInteracting = true;
		_lastPoint.X = e.Touches[0].X;
		_lastPoint.Y = e.Touches[0].Y;
	}


	private void EndInteraction(object sender, TouchEventArgs e) => _isInteracting = false;


	private void DragInteraction(object sender, TouchEventArgs e)
	{
		if (_isInteracting)
		{
			_lastPoint.X = e.Touches[^1].X;
			_lastPoint.Y = e.Touches[^1].Y;
			StatusLabel.Text = $"X: {_lastPoint.X:N2} Y: {_lastPoint.Y:N2} (DragInteraction)";
		}
	}


	private void GView_PointerMoved(object sender, PointerEventArgs e)
	{
		if (!_isInteracting)
		{
			_lastPoint.X = (float)e.GetPosition(GView).Value.X;
			_lastPoint.Y = (float)e.GetPosition(GView).Value.Y;
			StatusLabel.Text = $"X: {_lastPoint.X:N2} Y: {_lastPoint.Y:N2} (GView_PointerMoved)";
		}
	}


	private void GView_Tapped(object sender, TappedEventArgs e) =>
		StatusLabel.Text = $"X: {_lastPoint.X:N2} Y: {_lastPoint.Y:N2} (GView_Tapped)";
}