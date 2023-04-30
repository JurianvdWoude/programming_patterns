using System;

class Program {
	static void Main() {
		Console.WriteLine("hello world");

		Receiver receiver =  new Receiver(0, 0);
		InputHandler inputhandler = new InputHandler();
		inputhandler.GetSelectedUnit(receiver);
		Command command = inputhandler.HandleInputs("up");
		command.Execute();
		command = inputhandler.HandleInputs("right");
		command.Execute();
		command = inputhandler.HandleInputs("up");
		command.Execute();
		command.Undo();
		command.Execute();
	}
}

class InputHandler {
	Receiver receiver = null;

	public void GetSelectedUnit(Receiver receiver) {
		this.receiver = receiver;
	}

	public Command HandleInputs(string input) {
		int destX;
		int destY;
		int currX = receiver.x;
		int currY = receiver.y;
		switch(input) {
			case "up":
				if (currY == 100) {
					destY = currY;
				}
				else {
					destY = currY + 1;
				}
 				return new MoveCommand(receiver, receiver.x, destY);
			case "down":
				if (currY == 0) {
					destY = currY;
				}
				else {
					destY = currY - 1;
				}
 				return new MoveCommand(receiver, receiver.x, destY);
			case "left":
				if (currX == 0) {
					destX = currX;
				}
				else {
					destX = currX - 1;
				}
 				return new MoveCommand(receiver, destX, receiver.y);
			case "right":
				if (currX == 100) {
					destX = currX;
				}
				else {
					destX = currX + 1;
				}
 				return new MoveCommand(receiver, destX, receiver.y);
			default:
				return new MoveCommand(receiver, receiver.x, receiver.y);
		}
	}
}

abstract class Command {
	protected Receiver receiver;

	public Command(Receiver receiver) {
		this.receiver = receiver;
	}

	public abstract void Execute();

	public abstract void Undo();
}

class MoveCommand : Command {
	private int _x, _y, _xBefore, _yBefore;

	public MoveCommand(Receiver receiver, int x, int y) : base(receiver) 
	{
		this.receiver = receiver;
		this._x = x;
		this._y = y;
		this._xBefore = 0;
		this._yBefore = 0;
	}

	public override void Execute() {
		this._xBefore = receiver.x;
		this._yBefore = receiver.y;
		receiver.MoveTo(_x, _y);
	}

	public override void Undo() {
		this._x = this._xBefore;
		this._y = this._yBefore;
	}
}

class Receiver {
	public int x;
	public int y;

	public Receiver(int x, int y) {
		this.x = x;
		this.y = y;
	}

	public void MoveTo(int x, int y) {
		this.x = x;
		this.y = y;
		Console.WriteLine("{0}, {1}", this.x, this.y);
	}
}
