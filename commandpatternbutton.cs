
using System;
using System.Globalization;
using System.Collections.Generic;

class Program {
	static void Main() {
		Receiver receiver = new Receiver();
		InputHandler inputhandler = new InputHandler();

		inputhandler.SetABttn(new JumpCommand(receiver));
		inputhandler.SetBBttn(new RunCommand(receiver));

		inputhandler.HandleInputs(true);

		Console.ReadKey();
	}
}

class InputHandler {
	private Command AButton;
	private Command BButton;

	public void SetABttn(Command command) {
		this.AButton = command;
	}

	public void SetBBttn(Command command) {
		this.BButton = command;
	}

	public void HandleInputs(bool IfPressed) {
		if(IfPressed) { 
			AButton.Execute();
		} else {
			BButton.Execute();
		}
	}
}
		

abstract class Command {
	protected Receiver receiver;

	public Command(Receiver receiver) {
		this.receiver = receiver;
	}

	public abstract void Execute();
}

class JumpCommand : Command {
	public JumpCommand(Receiver receiver) : base(receiver) 
	{
	}

	public override void Execute() {
		receiver.Jump();
	}
}

class RunCommand : Command {
	public RunCommand(Receiver receiver) : base(receiver)
	{
	}

	public override void Execute() {
		receiver.Run();
	}
}

class Receiver {
	public void Jump() {
		Console.WriteLine("Called receiver.Jump()");
	}

	public void Run() {
		Console.WriteLine("Called receiver.Run()");
	}
}

class Invoker {
	private Command _command;

	public void ExecuteCommand() {
		_command.Execute();
	}

	public void SetCommand(Command command) {
		this._command = command;
	}
}

