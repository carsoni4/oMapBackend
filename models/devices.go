package models

import (
	is "oMapBackend/internal_structures"
)

type Device struct {
	ID       int
	Name     string
	Type     string
	Position is.Vector2
	Color    string //Hex String
}
