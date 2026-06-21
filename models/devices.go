package models

import (
	is "oMapBackend/internal_structures"
)

type Device struct {
	ID       int        `json:"id"`
	Name     string     `json:"name"`
	Type     string     `json:"type"`
	Position is.Vector2 `json:"position"`
	Color    string     `json:"color"`
}
