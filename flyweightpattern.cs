using System;

class Program {
	static void Main() {
		Console.WriteLine("hello world");
	}
}

class Vector3 {
	int x, y, z;

	public Vector3(int x, int y, int z) {
		this.x = x;
		this.y = y;
		this.z = z;
	}
}

class Color {
	int r, g, b, a;

	public Color(int r, int g, int b, int a = 0) {
		this.r = r;
		this.g = g;
		this.b = b;
		this.a = a;
	}
}

class Texture {
	string path;

	public Texture(string path) {
		this.path = path;
	}
}

class Mesh {
	string path;

	public Mesh(string path) {
		this.path = path
	}
}

class TreeModel {
	Mesh _mesh;
	Texture _bark, _leaves;
}

class Tree {
	Treemodel _model;
	Vector3 _position;
	Color _barkTint, _leafTint;
	float _height, _thickness;
}
