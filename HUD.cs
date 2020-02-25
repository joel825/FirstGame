using Godot;
using System;

public class HUD : CanvasLayer
{
	[Signal]
	public delegate void StartGame();
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
public void ShowMessage(string text)
{
	var messageLabel = GetNode<Label>("MessageLabel");
	messageLabel.Text = text;
	messageLabel.Show();

	GetNode<Timer>("MessageTimer").Start();
}
async public void ShowGameOver()
{
	ShowMessage("Game Over");

	var messageTimer = GetNode<Timer>("MessageTimer");
	await ToSignal(messageTimer, "timeout");

	var messageLabel = GetNode<Label>("MessageLabel");
	messageLabel.Text = "Dodge the\nCreeps!";
	messageLabel.Show();

	GetNode<Button>("StartButton").Show();
}
public void UpdateScore(int score)
{
	GetNode<Label>("ScoreLabel").Text = score.ToString();
}
private void OnStartButtonPressed()
{
	GetNode<Button>("StartButton").Hide();
	EmitSignal("StartGame");
}
private void OnMessageTimerTimeout()
{
	GetNode<Label>("MessageLabel").Hide();
}
}






