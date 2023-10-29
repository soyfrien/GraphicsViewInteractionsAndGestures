namespace GraphicsViewInteractionsAndGestures;

public partial class MainPage : ContentPage
{
	private bool _isInteracting;
	private PointF _lastPoint;

	public MainPage() => InitializeComponent();


	private void StartInteraction(object sender, TouchEventArgs e)
	{
		_isInteracting = true;
		_lastPoint.X = e.Touches[^1].X;
		_lastPoint.Y = e.Touches[^1].Y;
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
		if (_isInteracting)
		{
			_lastPoint.X = (float)e.GetPosition(GView).Value.X;
			_lastPoint.Y = (float)e.GetPosition(GView).Value.Y;
			StatusLabel.Text = $"X: {_lastPoint.X:N2} Y: {_lastPoint.Y:N2} (GView_PointerMoved)";
		}
	}


	private void GView_Tapped(object sender, TappedEventArgs e) => 
		StatusLabel.Text = $"X: {_lastPoint.X:N2} Y: {_lastPoint.Y:N2} (GView_Tapped)";
}

