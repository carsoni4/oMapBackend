package internalstructures

type Vector2 struct {
	X, Y int
}

func (v Vector2) AddVectors(other Vector2) Vector2 {
	return Vector2{v.X + other.X, v.Y + other.Y}
}

func (v Vector2) SubtractVectors(other Vector2) Vector2 {
	return Vector2{v.X - other.X, v.Y - other.Y}
}
